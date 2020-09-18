Imports System.Globalization
Imports System.IO

Friend Module SettingsRoutines

    Friend Sub LoadSettings()

        Flag = False
        Dim tr As Long
        Try
            tr = My.Settings.TimesRun + 1
            My.Settings.TimesRun = tr

            With FrmMain
                .Ttip.SetToolTip(.NumElevation, My.Resources.ttip_elevation)
                .Ttip.SetToolTip(.BtnRunEvents, My.Resources.ttip_btn_runevents)
                .Ttip.SetToolTip(.NumRecordUpdate, My.Resources.ttip_min_val)
                .Ttip.SetToolTip(.NumWbUpdateInt, My.Resources.ttip_min_val)
                .Ttip.SetToolTip(.NumAmbientUpdate, My.Resources.ttip_min_val)
                .Ttip.SetToolTip(.NumArchiveInterval, My.Resources.ttip_sec_val)
                .Ttip.SetToolTip(.TxtStationName, My.Resources.ttip_station_name)
                AppKey = My.Settings.AppKey
                .TxtAmbientAppKey.Text = AppKey

                ApiKey = My.Settings.ApiKey
                .TxtAmbientApiKey.Text = ApiKey

                .TxtWbIP.Text = My.Settings.wbIp
                .TxtWbLogin.Text = My.Settings.wbLogin
                .TxtWbPassword.Text = My.Settings.wbPassword

                .NumElevation.Value = CDec(My.Settings.ElevationFt)
                .NumArchiveInterval.Value = My.Settings.ArcUpDateInt

                'default archive settings to 5 minutes (300 seconds)
                If My.Settings.ArcUpDateInt <= 0 Then
                    My.Settings.ArcUpDateInt = 300
                    .NumArchiveInterval.Value = 300
                End If

                'default record data update to 30 minutes
                .NumRecordUpdate.Value = My.Settings.RecUpDateInt
                If My.Settings.RecUpDateInt <= 0 Then
                    My.Settings.RecUpDateInt = 30
                    .NumRecordUpdate.Value = 30
                End If

                'default Ambient update set to 60 minutes   
                .NumAmbientUpdate.Value = My.Settings.AmbientUpdateInt
                If My.Settings.AmbientUpdateInt <= 0 Then
                    My.Settings.AmbientUpdateInt = 60
                    .NumAmbientUpdate.Value = 60
                End If

                .NumWbUpdateInt.Value = My.Settings.WbUpdateInt
                If My.Settings.WbUpdateInt <= 0 Then
                    My.Settings.WbUpdateInt = 15
                    .NumWbUpdateInt.Value = 15
                End If

                If String.IsNullOrEmpty(My.Settings.AmbientStationName) Then
                    My.Settings.AmbientStationName = "Ambient"
                    My.Settings.Save()
                End If
                .TxtStationName.Text = My.Settings.AmbientStationName
                .TpAmbient.Text = My.Settings.AmbientStationName

                AmbientEnable = My.Settings.EnableAmbient
                .ChkEnableAmbient.Checked = AmbientEnable

                WbEnable = My.Settings.EnableWb
                .ChkEnableWb.Checked = WbEnable

                LogHdrData = My.Settings.LogHdrData
                .ChkLogHdrData.Checked = LogHdrData

                'sets the year that the station was started.  this info is used for the all-time records
                If String.IsNullOrEmpty(My.Settings.YearStarted) Then
                    .TxtYearStarted.Text = $"{Now.Year}"
                    My.Settings.YearStarted = $"{Now.Year}"
                Else
                    .TxtYearStarted.Text = My.Settings.YearStarted
                End If



                If String.IsNullOrEmpty(My.Settings.ApiKey) OrElse String.IsNullOrEmpty(My.Settings.AppKey) OrElse String.IsNullOrEmpty(My.Settings.wbLogin) OrElse String.IsNullOrEmpty(My.Settings.wbPassword) OrElse String.IsNullOrEmpty(My.Settings.wbIp) Then
                    Throw New ArgumentException($"{NameOf(ApiKey)}/{AppKey} cannot be empty.")
                Else
                    Flag = True
                    .BtnRunEvents.Enabled = True
                    '.RunPostEvents()
                End If

            End With
            My.Settings.Save()
        Catch ex As ArgumentException
            FrmMain.TC.SelectedIndex = FrmMain.TC.TabCount - 1
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            My.Settings.Save()
        End Try
    End Sub

    ''' <summary>
    ''' Make sure that all the required folders exist.  
    ''' </summary>
    Public Sub CreateProgramFolders()
        ArcDirYr = Path.Combine(ArcDir, CType(Now.Year, String))
        Dim fName As New List(Of String)({LogDir, TempDir, ImgDir, ArcDir, DataDir, ArcDirYr, RecDir})
        With FrmMain
            For j = 0 To fName.Count - 1
                Try
                    If Not Directory.Exists(fName(j)) Then
                        Directory.CreateDirectory(fName(j))
                    End If
                Catch ex As Exception
                    PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
                Finally
                    'a
                End Try
            Next
        End With
        'If Not Directory.Exists(Now.Year.ToString(CultureInfo.CurrentCulture)) Then
        '    'added if/then 1/1/20
        '    CreateArchiveFolder()
        'End If
    End Sub

    Friend Sub CreateArchiveFolder()
        ArcDirYr = Path.Combine(ArcDir, CType(Now.Year, String))
        Try
            If Not Directory.Exists(ArcDirYr) Then
                Directory.CreateDirectory(ArcDirYr)
                PrintLog($"{ArcDirYr} ==> created.{vbLf}")
            Else
                PrintLog($"{ArcDirYr} --> exists.{vbLf}")
            End If
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            'a
        End Try
    End Sub

End Module
