Imports System.IO

Public Class LogFile

    Private swLog As StreamWriter
    Public sLogfile As String

    Public Sub New(sAppPath As String) ' Application.ExecutablePath
        Const ErrorNumber As Integer = 1000

        Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(sAppPath)

        sLogfile = String.Format("{0}{1}-{2}-{3}.log", Path.GetTempPath, Path.GetFileNameWithoutExtension(sAppPath), DateTime.Now.ToString("ddMMyyyy-hhmmss"), DateTime.Now.Millisecond)
        Debug.WriteLine("Logfile: " & sLogfile)

        ' Logfile initialisieren
        Try
            swLog = New StreamWriter(sLogfile)
            swLog.AutoFlush = True
        Catch ex As Exception
            MsgBox("Kann das Logfile " & sLogfile & "nicht schreiben: " & ex.Message & ".")
            Err.Raise(vbObjectError + ErrorNumber, "ClassLog.New",
                "Kann das Logfile " & sLogfile & "nicht schreiben: " & ex.Message & ".")

        End Try

        LogPlain("*****************************************************")
        LogPlain("BEGINNE EINE NEUE LOGGING-SITZUNG")
        LogPlain("*****************************************************")
        LogPlain("Logfile: " & sLogfile)
        LogPlain()
        LogPlain("System Details")
        LogPlain("=====================================================")
        LogPlain(String.Format("{0,-24}: {1}", myBuildInfo.ProductName, myBuildInfo.ProductVersion))
        LogPlain(String.Format("{0,-24}: {1}", "Computer(Name)", Environment.MachineName))
        LogPlain(String.Format("{0,-24}: {1}", "Betriebssystem", Environment.OSVersion.ToString))
        'LogDirect()
        'LogDirect("Configuration Options")
        'LogDirect("=====================================================")

    End Sub

    Protected Overrides Sub Finalize()
        'Close file
        'wird anscheinend von alleine geschlossen *shrug*
        'swLog.Close()
        MyBase.Finalize()
    End Sub

    Public Sub log(Optional sString As String = "")
        swLog.WriteLine(String.Format("[{0}] {1}", DateTime.Now, sString))
    End Sub

    Public Sub LogPlain(Optional sString As String = "")
        swLog.WriteLine(sString)
    End Sub

    Public Sub ViewLog()
        Process.Start("notepad.exe", sLogfile)
    End Sub

    Public ReadOnly Property FileName As String
        Get
            Return sLogfile
        End Get
    End Property
End Class
