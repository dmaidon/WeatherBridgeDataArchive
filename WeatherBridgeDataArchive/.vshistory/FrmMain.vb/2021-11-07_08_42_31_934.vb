Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Threading

Imports WeatherBridgeDataArchive.Modules

Public Class FrmMain

    Private _MoEndTime As Date

    'flag for monthly rollover
    Private _moFlag As Boolean

    ''' <summary>
    ''' Automatically upgrade application settings for new versions
    ''' </summary>
    Private Shared Sub UpgradeMySettings()
        'https://stackoverflow.com/questions/1702260/losing-vb-net-my-settings-with-each-new-clickonce-deployment-release
        If My.Settings.MustUpgrade Then
            My.Settings.Upgrade()
            My.Settings.MustUpgrade = False
            My.Settings.Save()
        End If
    End Sub

    Private Sub FrmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.Save()
        'just some debug logging
        'If Flag Then
        '    PrintLog($"Width: {Width}    Height: {Height}{vbLf}")
        '    'With DgvRecords
        '    '    For j = 0 To 7
        '    '        For k = 0 To 5
        '    '            PrintLog($"Row {j}. Cell {k}. Width: { .Rows(j).Cells(k).Size.Width}   Height: { .Rows(j).Cells(k).Size.Height}{vbLf}")
        '    '        Next
        '    '        Application.DoEvents()
        '    '    Next
        '    'End With
        'End If
        SaveLogs()
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpgradeMySettings()
        CreateProgramFolders()

        Text = "WeatherBridge Data Archiver"
        TsslVer.Text = $"{Application.ProductVersion}   "
        TsslCpy.Text = Cpy
        Show()

        'housekeeping
        LoadSettings()
        StartLogFile()
        PerformLogMaintenance()
        'set the midnight timer.  Special events are run at the midnight rollover
        SetMidnightRollover()

        'Flag is set to True or False during the settings routines.
        If Flag Then
            RunPostEvents()
        End If
    End Sub

    Private Sub RunPostEvents()
        CreateRecordsGrid()

        'get our initial record data
        RunRecordUpdateEvents()
        'set timer and countdown display for record updates (Default: 30 minutes)
        RecDuration = New TimeSpan(0, My.Settings.RecUpDateInt, 0)
        RecNextUpdate = Date.Now + RecDuration
        TmrRecUpdate.Interval = TimeSpan.FromMinutes(My.Settings.RecUpDateInt).TotalMilliseconds
        TmrRecUpdate.Start()

        'start archiving data
        WriteCurrentData()
        SetMonthlyRollover()
        'set timer and countdown display for archive updates (Default: 300 seconds (5 minutes))
        ArcDuration = New TimeSpan(0, 0, My.Settings.ArcUpDateInt)
        ArcNextUpdate = Date.Now + ArcDuration
        TmrArcUpdate.Interval = TimeSpan.FromSeconds(My.Settings.ArcUpDateInt).TotalMilliseconds
        TmrArcUpdate.Start()

        'run Ambient update and set timer (Default: 60 minutes)
        If AmbientEnable Then
            AmbDuration = New TimeSpan(0, My.Settings.AmbientUpdateInt, 0)
            AmbNextUpdate = Date.Now + AmbDuration
            TmrAmbUpdate.Interval = TimeSpan.FromMinutes(My.Settings.AmbientUpdateInt).TotalMilliseconds
            TmrAmbUpdate.Start()
            FetchAmbientData()
        End If

        'WeatherBridge data update (Default: 15 minutes)
        If WbEnable Then
            wbDuration = New TimeSpan(0, My.Settings.WbUpdateInt, 0)
            wbNextUpdate = Date.Now + wbDuration
            TmrWbUpdate.Interval = TimeSpan.FromMinutes(My.Settings.WbUpdateInt).TotalMilliseconds
            TmrWbUpdate.Start()
            LoadWbStationData()
        End If

        'start the main clock which runs the countdown
        TmrClock.Start()
    End Sub

    Private Sub SetMonthlyRollover()
        Dim intMo = New Date(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month)).AddHours(23).AddMinutes(59).AddSeconds(58)
        _MoEndTime = New DateTime(intMo.Year, intMo.Month, intMo.Day, intMo.Hour, intMo.Minute, intMo.Second, 0)
        _moFlag = True
        PrintLog($"< == > End of month time set: {intMo}{vbLf}")
    End Sub

    Private Sub TmrClock_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles TmrClock.Elapsed

        TsslRecordUpdate.Text = If _
            (DateDiff(DateInterval.Minute, My.Computer.Clock.LocalTime, RecNextUpdate) < 1, $"{DateDiff(DateInterval.Second, Date.Now, RecNextUpdate):N0}",
                $"{DateDiff(DateInterval.Minute, Date.Now, RecNextUpdate):N0}")

        TsslArchiveUpdate.Text = If _
           (DateDiff(DateInterval.Minute, My.Computer.Clock.LocalTime, ArcNextUpdate) < 1, $"{DateDiff(DateInterval.Second, Date.Now, ArcNextUpdate):N0}",
               $"{DateDiff(DateInterval.Minute, Date.Now, ArcNextUpdate):N0}")

        TsslAmbientUpdate.Text = If _
           (DateDiff(DateInterval.Minute, My.Computer.Clock.LocalTime, AmbNextUpdate) < 1, $"{DateDiff(DateInterval.Second, Date.Now, AmbNextUpdate):N0}",
               $"{DateDiff(DateInterval.Minute, Date.Now, AmbNextUpdate):N0}")

        TsslWbUpdate.Text = If _
           (DateDiff(DateInterval.Minute, My.Computer.Clock.LocalTime, wbNextUpdate) < 1, $"{DateDiff(DateInterval.Second, Date.Now, wbNextUpdate):N0}",
               $"{DateDiff(DateInterval.Minute, Date.Now, wbNextUpdate):N0}")

        Dim t = _MoEndTime.Subtract(Now)
        If _moFlag AndAlso t.TotalDays <= 0 AndAlso t.TotalHours <= 0 AndAlso t.TotalMinutes <= 0 AndAlso t.TotalSeconds <= 0 AndAlso t.TotalMilliseconds <= 0 Then
            WriteMonthlyData()
            ' let's make sure that we are into the next month
            If Now.Day = Date.DaysInMonth(Now.Year, Now.Month) Then
                Thread.Sleep(3000)
            End If
            SetMonthlyRollover()
        End If

    End Sub

#Region "Settings"

    Private Sub NumAmbientUpdate_ValueChanged(sender As Object, e As EventArgs) Handles NumAmbientUpdate.ValueChanged
        My.Settings.AmbientUpdateInt = CInt(NumAmbientUpdate.Value)
        My.Settings.Save()
    End Sub

    Private Sub NumElevation_ValueChanged(sender As Object, e As EventArgs) Handles NumElevation.ValueChanged
        My.Settings.ElevationFt = CInt(NumElevation.Value)
        My.Settings.Save()
    End Sub

    Private Sub NumEnter(sender As Object, e As EventArgs) Handles NumElevation.Enter, NumArchiveInterval.Enter, NumRecordUpdate.Enter, NumAmbientUpdate.Enter, NumWbUpdateInt.Enter
        Dim ct = DirectCast(sender, NumericUpDown)
        ct.Select(0, ct.Text.Length)
    End Sub

    Private Sub NumHrUdt_ValueChanged(sender As Object, e As EventArgs) Handles NumRecordUpdate.ValueChanged
        My.Settings.RecUpDateInt = CInt(NumRecordUpdate.Value)
        My.Settings.Save()
    End Sub

    Private Sub NumWbInterval_ValueChanged(sender As Object, e As EventArgs) Handles NumArchiveInterval.ValueChanged
        My.Settings.ArcUpDateInt = CInt(NumArchiveInterval.Value)
        My.Settings.Save()
    End Sub

    Private Sub NumWbUpdateInt_ValueChanged(sender As Object, e As EventArgs) Handles NumWbUpdateInt.ValueChanged
        My.Settings.WbUpdateInt = CInt(NumWbUpdateInt.Value)
        My.Settings.Save()
    End Sub

    Private Sub ProcessesEnabled(sender As Object, e As EventArgs) Handles ChkEnableAmbient.CheckedChanged, ChkEnableWb.CheckedChanged, ChkLogHdrData.CheckedChanged
        Dim ni = DirectCast(sender, CheckBox)
        Select Case CInt(ni.Tag)
            Case 0
                My.Settings.EnableAmbient = ChkEnableAmbient.Checked
                AmbientEnable = ChkEnableAmbient.Checked
            Case 1
                My.Settings.EnableWb = ChkEnableWb.Checked
                WbEnable = ChkEnableWb.Checked
            Case 2
                My.Settings.LogHdrData = ChkLogHdrData.Checked
                LogHdrData = ChkLogHdrData.Checked
            Case Else
                Return
        End Select
        My.Settings.Save()
    End Sub

    Private Sub WeatherBridgeSettings(sender As Object, e As EventArgs) Handles TxtAmbientApiKey.TextChanged, TxtAmbientAppKey.TextChanged, TxtWbIP.TextChanged, TxtWbLogin.TextChanged, TxtWbPassword.TextChanged, TxtStationName.TextChanged
        Dim ni = DirectCast(sender, TextBox)
        Select Case CInt(ni.Tag)
            Case 0
                My.Settings.ApiKey = TxtAmbientApiKey.Text
            Case 1
                My.Settings.AppKey = TxtAmbientAppKey.Text
            Case 2
                My.Settings.wbIp = TxtWbIP.Text
            Case 3
                My.Settings.wbLogin = TxtWbLogin.Text
            Case 4
                My.Settings.wbPassword = TxtWbPassword.Text
            Case 5
                My.Settings.AmbientStationName = TxtStationName.Text
                TpAmbient.Text = My.Settings.AmbientStationName
            Case Else
                Return
        End Select

        My.Settings.Save()
    End Sub

#End Region

#Region "Midnight"

    Private Sub SetMidnightRollover()
        'set the timer for the midnight event
        Dim st = New DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 1).AddDays(1)
        Dim _int = Date2Unix(st) - Date2Unix(Now)
        TmrMidnight.Interval = TimeSpan.FromSeconds(_int).TotalMilliseconds
        TmrMidnight.Start()
        PrintLog($"=> Set midnight rollover: {st} -> Interval: {_int} seconds{vbLf}")
    End Sub

    Private Sub TmrMidnight_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles TmrMidnight.Elapsed
        TmrMidnight.Stop()
        PrintLog($"=> Midnight timer elapsed and stopped @ {Now:T}.{vbLf}")
        Dim _st = New DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 1).AddDays(1)
        Dim _int = Date2Unix(_st) - Date2Unix(Now)
        TmrMidnight.Interval = TimeSpan.FromSeconds(_int).TotalMilliseconds
        TmrMidnight.Start()
        PrintLog($"<== Midnight timer restarted @ {Now:T}.{vbLf}     Interval: {_int} seconds{vbLf}")

        'save the records for yesterday at the midnight rollover
        Dim yd = Date.Now.AddDays(-1)
        SaveForecastImages(DgvRecords, $"records_{Replace($"{yd:d}", "/", String.Empty)}.png", $"Records for {yd:D}", RecDir)
        'If TweetRecords Then 'tweets.vb
        '    TweetRecordsImage($"records_{Replace($"{yd:d}", "/", String.Empty)}.png", $"Records for {yd:D}. #CarolinaWx #WeatherBridge #DavisInstruments")
        'End If
        Check4NewLogfile()
        'MidnightUpdate()
        WriteYesterdayData()
        If Not Directory.Exists(Now.Year.ToString(CultureInfo.CurrentCulture)) Then
            CreateArchiveFolder()
        End If
        'TweetWeeklyImage()
        SaveLogs()
    End Sub

#End Region

#Region "Update Timers"

    Private Sub BtnRunEvents_Click(sender As Object, e As EventArgs) Handles BtnRunEvents.Click
        RunPostEvents()
    End Sub

    Private Sub RunRecordUpdateEvents()
        'UpdateHourHiLo()
        'UpdateDailyHiLo()
        'UpdateYesterdayHiLo()
        'UpdateMonthHiLo()
        'UpDateYearHiLo()
        'UpdateAllTimeHiLo()
        For j = 0 To 5
            Select Case j
                Case 0
                    UpdateHourHiLo()
                Case 1
                    UpdateDailyHiLo()
                Case 2
                    UpdateYesterdayHiLo()
                Case 3
                    UpdateMonthHiLo()
                Case 4
                    UpDateYearHiLo()
                Case 5
                    UpdateAllTimeHiLo()
                Case Else
                    Return
            End Select
            Application.DoEvents()
        Next
    End Sub

    Private Sub TmrAmbUpdate_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles TmrAmbUpdate.Elapsed
        AmbDuration = New TimeSpan(0, My.Settings.AmbientUpdateInt, 0)
        AmbNextUpdate = Date.Now + AmbDuration
        FetchAmbientData()
    End Sub

    Private Sub TmrArcUpdate_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles TmrArcUpdate.Elapsed
        'reset countdown timer
        ArcDuration = New TimeSpan(0, 0, My.Settings.ArcUpDateInt)
        ArcNextUpdate = Date.Now + ArcDuration
        WriteCurrentData()
    End Sub

    Private Sub TmrRecUpdate_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles TmrRecUpdate.Elapsed
        'reset countdown timer
        RecDuration = New TimeSpan(0, My.Settings.RecUpDateInt, 0)
        RecNextUpdate = Date.Now + RecDuration
        RunRecordUpdateEvents()
        PrintLog($"Records updated @ {Now:F}{vbLf}")
        SaveLogs()
    End Sub

    Private Sub TmrWbUpdate_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles TmrWbUpdate.Elapsed
        wbDuration = New TimeSpan(0, My.Settings.WbUpdateInt, 0)
        wbNextUpdate = Date.Now + wbDuration
        LoadWbStationData()
    End Sub

#End Region

End Class