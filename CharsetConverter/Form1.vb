' Project: CharsetConverter
' URL:     https://charsetconverter.codeplex.com/
' Author:  Sven Gottwald
' 
' Copyright (c) 2012, Sven Gottwald
' All rights reserved.
' 
' Redistribution and use in source and binary forms, with or without modification, 
' are permitted provided that the following conditions are met:
' 
' * Redistributions of source code must retain the above copyright notice, this 
' list of conditions and the following disclaimer.
' 
' * Redistributions in binary form must reproduce the above copyright notice, this 
' list of conditions and the following disclaimer in the documentation and/or 
' other materials provided with the distribution.
' 
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
' ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
' IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
' INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
' BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, 
' DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF 
' LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE 
' OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED 
' OF THE POSSIBILITY OF SUCH DAMAGE.

' TODO: Zeichsätze vor dem einfügen prüfen (im init)

' Info: Text File Encoding Conversion in C# http://forums.asp.net/t/1173381.aspx/1
' Info: Encoding Converter Windows Application (C#.NET) http://are.ehibou.com/encoding-converter-windows-applicatioan-cnet/

Imports LogFile

Public Class Form1

    ' globale variablen
    Dim lfLog As New LogFile.LogFile(Application.ExecutablePath)

    ' Konstanten
    Const cBackupPath As String = "CharsetConverterBackups"
    'ausgewählte Encodings
    'Const cpIbm850 As Integer = 850
    'Const cpWindows1252 As Integer = 1252
    'Const cpISO885915 As Integer = 28605
    'Const cpUTF8 As Integer = 65001
    'Const cpUTF16 As Integer = 1200

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            AddFiles(OpenFileDialog1.FileNames)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lvFiles_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lvFiles.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub lvFiles_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lvFiles.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            AddFiles(e.Data.GetData(DataFormats.FileDrop))
        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Dim sInputFile As String
        Dim fs As FileStream
        Dim fs1 As FileStream
        Dim ReadFile As StreamReader
        Dim WriteFile As StreamWriter
        Dim sLine As String
        Dim lviIFile As ListViewItem
        Dim iFehlerZaehler As Integer = 0

        lfLog.LogPlain()
        lfLog.LogPlain("=====================================================")

        ' Datei da?
        If CountFiles() = 0 Then
            MsgBox("Keine Datei zum konvertieren vorhanden!", MsgBoxStyle.Exclamation)
            lfLog.log("FEHLER: Keine Datei zum konvertieren vorhanden")
            Exit Sub
        End If

        ' Encoding abprüfen
        If cbInput.SelectedIndex = -1 Or cbOutput.SelectedIndex = -1 Or _
                cbInput.Text = "-----------------" Or cbOutput.Text = "-----------------" Then
            MsgBox("Bitte zunächst sowohl die Eingangs- und Ausgangskodierung auswählen!", MsgBoxStyle.Exclamation)
            lfLog.log("FEHLER: Keine Eingangs und/oder Ausgangskodierung ausgewählt")
            Exit Sub
        End If

        ' Wenn kein Backup angekreuut: NACHFRAGEN!
        If Not cbBackup.Checked Then
            If MsgBox("Wirklich fortfahren? Die Originaldateien werden ohne Backup überschrieben!", _
                      MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2) _
                      = MsgBoxResult.Cancel Then Exit Sub
            lfLog.log("WARNUNG: Es wird kein Backup erstellt")
        End If

        lfLog.log("Es werden " & CountFiles() & " Dateien konvertiert")

        ' Encodings setzen
        Dim sTemp() As String
        sTemp = Split(cbInput.Text, " ")
        Dim InputEncoding As String = sTemp(0)
        lfLog.log("InputEncoding:  " & InputEncoding)
        sTemp = Split(cbOutput.Text, " ")
        Dim OutputEncoding As String = sTemp(0)
        lfLog.log("OutputEncoding: " & OutputEncoding)

        ' convert Files
        For Each lviIFile In lvFiles.Items

            ' Ist mit Dir schon was passiert? Wenn ja, dann weiter...
            If lviIFile.ImageIndex > -1 Then Continue For

            ' Counter um eins erhöhen
            iFehlerZaehler = iFehlerZaehler + 1

            ' Icon setzen
            lviIFile.ImageIndex = 2

            sInputFile = lviIFile.Text

            lfLog.LogPlain()
            lfLog.LogPlain("------------Starte Konvertierung von " & sInputFile)
            lfLog.log("InputEncoding:  " & InputEncoding)
            lfLog.log("OutputEncoding: " & OutputEncoding)

            If cbBackup.Checked Then
                ' Backup im Unterverzeichnis "backup" erstellen
                Dim sBackupFile As String = Path.Combine(Path.GetDirectoryName(sInputFile), My.Settings.BackupPath, Path.GetFileName(sInputFile))
                lfLog.log("erstelle Backup: " & sBackupFile)
                ' Legt Verzeichnis an
                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(sBackupFile))

                Try
                    System.IO.File.Copy(sInputFile, sBackupFile)
                Catch copyError As IOException
                    lfLog.log("FEHLER: Kann Backup nicht anlegen: " & copyError.Message)
                    lviIFile.ImageIndex = 0
                    lviIFile.ToolTipText = "FEHLER: Kann Backup nicht anlegen: " & copyError.Message
                    Continue For
                End Try
            End If 'cbBackup.Checked

            ' Quelldatei öffnen
            Try
                fs = New FileStream(sInputFile, FileMode.Open, FileAccess.ReadWrite)
                ReadFile = New StreamReader(fs, Encoding.GetEncoding(InputEncoding))
            Catch ex As Exception
                lfLog.log("FEHLER: Kann " & sInputFile & "nicht lesen: " & ex.Message)
                lviIFile.ImageIndex = 0
                lviIFile.ToolTipText = "FEHLER: Kann " & sInputFile & "nicht lesen: " & ex.Message
                Continue For
            End Try

            ' Als Ausgabe eine temporäre Datei verwenden
            Dim sTempfile As String = Path.GetTempFileName
            lfLog.log("Temporäre Datei: " & sTempfile)

            ' Tempfile anlegen
            ' Zieldatei öffnen
            Try
                fs1 = New FileStream(sTempfile, FileMode.Create, FileAccess.Write)
                WriteFile = New StreamWriter(fs1, Encoding.GetEncoding(OutputEncoding))
            Catch ex As Exception
                lfLog.log("FEHLER: Kann " & sTempfile & "nicht schreiben: " & ex.Message)
                lviIFile.ImageIndex = 0
                lviIFile.ToolTipText = "Kann " & sTempfile & "nicht schreiben: " & ex.Message
                Continue For
            End Try

            lfLog.log("Konvertiere temporäre Datei...")

            ' Zeilenweise konvertieren
            While ReadFile.Peek() > -1
                sLine = ReadFile.ReadLine()
                WriteFile.WriteLine(sLine)
            End While

            ' Dateihandles wieder schließen
            ReadFile.Close()
            WriteFile.Close()

            lfLog.log("Kopiere temporäre Datei nach " & sInputFile)

            ' in Ursprungsdatei kopieren
            Try
                System.IO.File.Copy(sTempfile, sInputFile, True)
            Catch copyError As IOException
                lfLog.log("FEHLER: Kann konvertierte Datei nicht schreiben: " & copyError.Message)
                lviIFile.ImageIndex = 0
                lviIFile.ToolTipText = "FEHLER: Kann konvertierte Datei nicht schreiben: " & copyError.Message
                Continue For
            End Try

            ' tempfile löschen
            Try
                System.IO.File.Delete(sTempfile)
                lfLog.log("Temporäre Datei gelöscht")
            Catch ex As Exception
                lfLog.log("WARNUNG: Kann " & sTempfile & " nicht löschen. " & ex.Message)
                lviIFile.ImageIndex = 0
                lviIFile.ToolTipText = "WARNUNG: Kann " & sTempfile & "nicht löschen: " & ex.Message
            End Try


            ' Alles gut gegangen
            ' Counter wieder runter setzen
            iFehlerZaehler = iFehlerZaehler - 1

            lfLog.log("ERFOLG: " & sInputFile & " erfolgreich konvertiert")
            lviIFile.ImageIndex = 1
            lviIFile.ToolTipText = "Datei erfolgreich konvertiert: " & InputEncoding & " > " & OutputEncoding
        Next

        lfLog.LogPlain()

        'Wenn der Counter > 0 ist, ist zwischendrin ein Fehler aufgetreten
        If iFehlerZaehler > 0 Then
            If MsgBox("Es sind " & iFehlerZaehler & " Fehler während des Vorgangs festgestellt worden. Möchten Sie sich die Log-Datei anzeigen lassen?", _
                      MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton1) _
                      = MsgBoxResult.Yes Then
                lfLog.log("Es sind " & iFehlerZaehler & " Fehler während des Vorgangs aufgetreten")
                lfLog.ViewLog()
            End If
        Else
            lfLog.log("Keine Fehler aufgetreten")
        End If

    End Sub

    Private Sub btnDel_Click(sender As System.Object, e As System.EventArgs) Handles btnDel.Click
        While (lvFiles.SelectedItems.Count > 0)
            lvFiles.Items.Remove(lvFiles.SelectedItems(0))
        End While
    End Sub

    Private Sub btnDelAll_Click(sender As System.Object, e As System.EventArgs) Handles btnDelAll.Click
        lvFiles.Items.Clear()
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim ei As EncodingInfo
        'Dim e1 As Encoding

        ' Comboboxen füllen
        ' Zeichencodierung in .NET Framework
        ' http://msdn.microsoft.com/de-de/library/ms404377.aspx

        ' Bei Fehlern einfach weiter machen...
        On Error Resume Next

        Dim s As String
        For Each s In {"windows-1252 / Westeuropäisch (Windows)", "iso-8859-15 / Lateinisch 9 (ISO)", "ibm850 / Westeuropäisch (DOS)", "utf-8 / Unicode (UTF-8)", "utf-16 / Unicode (UTF-16)"}
            cbInput.Items.Add(s)
            cbOutput.Items.Add(s)
        Next

        'Dim i As Integer
        'For Each i In {cpIbm850, cpWindows1252, cpISO885915, cpUTF8, cpUTF16}
        '    'e1 = Encoding.GetEncoding(i)
        '    ei = Encoding.GetEncoding(i)

        '    cbInput. Items.Add(

        'Next

        cbInput.Items.Add("-----------------")
        cbOutput.Items.Add("-----------------")

        For Each ei In Encoding.GetEncodings()
            If Not (ei.Name = "ibm850" Or ei.Name = "windows-1252" Or ei.Name = "iso-8859-15" Or ei.Name = "utf-8" Or ei.Name = "utf-16") Then
                cbInput.Items.Add(ei.Name & " / " & ei.DisplayName)
                cbOutput.Items.Add(ei.Name & " / " & ei.DisplayName)
            End If
        Next

        ' Default setzen
        cbInput.SelectedIndex = 0
        cbOutput.SelectedIndex = 0

    End Sub

    Private Sub Form1_HelpButtonClicked(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
        Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
        Dim messageBoxVB As New System.Text.StringBuilder()

        ' cancel help function
        e.Cancel = True

        messageBoxVB.AppendLine("Project: " & myBuildInfo.ProductName)
        messageBoxVB.AppendLine("Version: " & myBuildInfo.ProductVersion)
        messageBoxVB.AppendLine("Project home: http://charsetconverter.codeplex.com/")
        messageBoxVB.AppendLine()
        messageBoxVB.AppendLine("Copyright (c) 2012, Sven Gottwald")
        messageBoxVB.AppendLine("All rights reserved.")
        messageBoxVB.AppendLine()
        messageBoxVB.AppendLine("Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:")
        messageBoxVB.AppendLine()
        messageBoxVB.AppendLine("* Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.")
        messageBoxVB.AppendLine()
        messageBoxVB.AppendLine("* Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.")
        messageBoxVB.AppendLine()
        messageBoxVB.AppendLine("THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS ""AS IS"" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.")

        MessageBox.Show(messageBoxVB.ToString(), "About " & myBuildInfo.ProductName)
    End Sub

    Private Sub btnDirectory_Click(sender As System.Object, e As System.EventArgs) Handles btnDirectory.Click
        If FolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            AddDirectory(FolderBrowserDialog1.SelectedPath)
        End If
    End Sub

    Private Sub cbBackup_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbBackup.CheckedChanged
        'Sicherheitsabfrage
        If Not cbBackup.Checked Then
            If MsgBox("Sollen Backups wirklich deaktiviert werden? " & _
                   "Das Erstellen von Backups wird DRINGED empfohlen.", MsgBoxStyle.Exclamation _
                   + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then cbBackup.Checked = True
        End If
    End Sub

    Private Sub lvFiles_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles lvFiles.KeyDown
        If e.KeyCode = Keys.Delete Then
            While (lvFiles.SelectedItems.Count > 0)
                lvFiles.Items.Remove(lvFiles.SelectedItems(0))
            End While
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If CountFiles() > 1 Then
            If MsgBox("Es stehen noch Dateien zum konvertieren an. " & _
                   "Programm wirklich beenden?", MsgBoxStyle.Question _
                   + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then e.Cancel = True
        End If
    End Sub

End Class
