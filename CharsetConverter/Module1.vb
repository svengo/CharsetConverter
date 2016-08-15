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

Module Module1

    Public Function IsFile(sFile As String) As Boolean
        If sFile = Nothing Then
            IsFile = False
            Exit Function
        End If

        IsFile = System.IO.File.Exists(sFile)
    End Function

    Public Function IsDirectory(sDirectory As String) As Boolean
        If sDirectory = Nothing Then
            IsDirectory = False
            Exit Function
        End If

        IsDirectory = IO.Directory.Exists(sDirectory)
    End Function

    Public Function GetFiles(sDirectory As String) As ArrayList
        Dim sFile As String
        Dim alFileList As New ArrayList

        For Each sFile In System.IO.Directory.GetFiles(sDirectory)
            alFileList.Add(sFile)
        Next

        GetFiles = alFileList
    End Function

    Public Sub AddFiles(sFileList As String())

        For Each sFile In sFileList
            If IsFile(sFile) Then
                CheckAndAdd(sFile)
            ElseIf IsDirectory(sFile) Then
                For Each sFilesDir As String In GetFiles(sFile)
                    CheckAndAdd(sFilesDir)
                Next
            End If
        Next
    End Sub

    Public Sub AddDirectory(sDirectory As String)

        If IsDirectory(sDirectory) Then
            For Each sFilesDir As String In GetFiles(sDirectory)
                CheckAndAdd(sFilesDir)
            Next
        End If
    End Sub

    Public Sub CheckAndAdd(sFile As String)
        ' Keine Ahnung, also am besten Anwender fragen
        'If Form1.lvFiles.FindItemWithText(sFile) IsNot Nothing Then
        '    If MsgBox("Die Datei """ & sFile & """ ist bereits vorhanden. Soll sie erneut hinzugefügt werden?", _
        '        MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) _
        '        = MsgBoxResult.No Then Exit Sub
        'End If

        ' Und ab dafür
        Form1.lvFiles.Items.Add(sFile)

        ' resize Column
        Form1.lvFiles.Columns(0).Width = -1

    End Sub

    Public Function CountFiles() As Integer
        Dim lviIFile As ListViewItem
        Dim i As Integer = 0

        ' zu konvertierende Dateien zählen
        For Each lviIFile In Form1.lvFiles.Items
            If lviIFile.ImageIndex > -1 Then Continue For
            i = i + 1
        Next

        CountFiles = i

    End Function

End Module
