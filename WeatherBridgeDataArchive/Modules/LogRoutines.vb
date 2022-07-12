Imports System.IO
Imports System.Security
Imports System.Text

Friend Module LogRoutines

    Public Sub PrintLog(m As String)
        FrmMain.RtbLog.AppendText($"{m}{vbLf}")
    End Sub

    Friend Sub PrintErr(msg As String, trg As String, stk As String, src As String, Optional gbe As String = "- Empty -", Optional hl As String = "- Blank -", Optional dt As String = "- Empty -")
        Dim em As String =
                $"   Error:{vbLf}{msg}{vbLf}{vbLf}   Location:{vbLf}{trg}{vbLf}{vbLf}   Trace:{vbLf}{stk}{vbLf}{vbLf}   Source:{vbLf}{src}{vbLf}{vbLf}   Base Exception:{ _
                vbLf}{gbe}{vbLf}Help Link:{vbLf}{hl}{vbLf}Data:{vbLf}{dt}{vbLf}"
        FrmMain.RtbLog.AppendText($"{My.Resources.errSeparator}{vbLf}{em}{vbLf}{My.Resources.errSeparator}{vbLf}")
        SaveLogs()
    End Sub

    Public Sub SaveLogs(Optional nt As String = "")
        PrintLog($"{nt}{vbLf}")
        Try
            PrintLog($"¥{vbLf}")
            FrmMain.RtbLog.SaveFile(LogFile, RichTextBoxStreamType.PlainText)
        Catch ex As Exception When TypeOf ex Is ArgumentException OrElse TypeOf ex Is IOException
            MsgBox($"Unable to save logfile: {LogFile}.{vbLf}Error: {ex.Message}{vbLf}{ex.StackTrace}{vbLf}{ex.Source}")
        Finally
            ''a
        End Try
    End Sub

    Friend Sub StartLogFile()
        LogFile = Path.Combine(LogDir, $"wbda_{Now:Mdyy}-{My.Settings.TimesRun}.log")
        PrintLog(GetLogHeader())
    End Sub

    Friend Sub Check4NewLogfile()
        Dim si = LogFile.Substring _
            (LogFile.LastIndexOf("x", StringComparison.Ordinal) + 1,
             (LogFile.LastIndexOf("_", StringComparison.Ordinal) - LogFile.LastIndexOf("x", StringComparison.Ordinal) - 1))
        With FrmMain
            If si <> $"{Now:Mdyyyy}" Then
                Try
                    PrintLog($"Closing log: {Now:F}{vbLf}")
                    ''save old log file
                    .RtbLog.SaveFile(LogFile, RichTextBoxStreamType.PlainText)
                Catch ex As IOException
                    PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
                Finally
                    'a
                End Try
                PrintLog($"-{vbLf}")
                StartNewLogFile()
            Else
                PrintLog($"Check for new log -> File date: {si}  Current Date: { Replace($"{Now:d}", "/", String.Empty)}{vbLf}")
            End If
        End With
    End Sub

    Private Sub StartNewLogFile()
        With FrmMain
            Try
                .RtbLog.Clear()
                ''start the new logfile
                Dim timesrun As Long = My.Settings.TimesRun
                LogFile = Path.Combine(LogDir, $"wbda_{Now:Mdyy}_{My.Settings.TimesRun}.log")
                PrintLog(GetLogHeader())
                'PerformLogMaintenance()
            Catch ex As ArgumentNullException
                PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
            Finally
                'a
            End Try
        End With
        SaveLogs()
    End Sub

    Private Function GetLogHeader() As String
        Dim timesrun As Long = My.Settings.TimesRun
        Dim sb = New StringBuilder($"Log file started: {Now:F}{vbLf}")
        sb.Append($"Program: {Application.ProductName} v{Application.ProductVersion}{vbLf}")
        sb.Append($"Log file: {LogFile}{vbLf}")
        sb.Append($"Times run: {timesrun}{vbLf}")
        sb.Append($"OS Version: {Environment.OSVersion}{vbLf}")
        sb.Append($"Machine Name: {Environment.MachineName}{vbLf}")
        Return sb.ToString()
    End Function

    Public Sub PerformLogMaintenance()
        With FrmMain
            PrintLog($"<{My.Resources.separator}{vbLf}")
            'keep log files this number of days
            Dim intDays = 7
            Dim fc As Integer

            Try
                For Each file In From file1 In New DirectoryInfo(LogDir).GetFiles() Where (Now - file1.LastWriteTime).Days >= intDays
                    fc += 1
                    file.Delete()
                    PrintLog($">> Deleted: {file.FullName}.  Date: {file.CreationTime}{vbLf}")
                Next

                For Each file In From file1 In New DirectoryInfo(TempDir).GetFiles() Where (Now - file1.LastWriteTime).Days >= intDays
                    fc += 1
                    file.Delete()
                    PrintLog($">> Deleted: {file.FullName}.  Date: {file.CreationTime}{vbLf}")
                Next

                For Each file In From file1 In New DirectoryInfo(DataDir).GetFiles("*.*", SearchOption.AllDirectories) Where (Now - file1.LastWriteTime).Days >= intDays
                    fc += 1
                    file.Delete()
                    PrintLog($">> Deleted: {file.FullName}.  Date: {file.CreationTime}{vbLf}")
                Next
            Catch ex As Exception When _
                TypeOf ex Is ArgumentException OrElse TypeOf ex Is ArgumentNullException OrElse TypeOf ex Is SecurityException _
                OrElse TypeOf ex Is DirectoryNotFoundException
                PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
            Finally
                ''trap error
            End Try

            PrintLog($"Log Maintenance performed.{vbLf}Files over {intDays} days old deleted.{vbLf}{fc} files deleted.{vbLf}{My.Resources.separator}>{vbLf}")
        End With
        SaveLogs()
    End Sub

End Module