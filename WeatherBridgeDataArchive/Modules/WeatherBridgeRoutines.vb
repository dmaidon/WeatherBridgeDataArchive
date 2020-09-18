Imports System.Net

Friend Module WeatherBridgeRoutines

    Friend Sub LoadWbStationData()
        PrintLog($"Loading Weatherbridge Station Data @ {Now:T}{vbLf}")
        With FrmMain
            'mbsystem
            Dim wbNfo As New List(Of String)({"mac", "swversion", "buildnum", "platform", "station", "stationnum", "language", "timezone", "altitude", "latitude", "longitude", "uptime", "cpuload1m", "cpuload5m", "cpuload15m", "ip", "lanip", "wlanip", "lastdata", "lastgooddata", "solarmax", "lunarage", "lunarpercent", "lunarsegment", "daylength", "daylengthmin", "daylengthmax", "civildaylength", "civildaylengthmin", "civildaylengthmax", "nauticaldaylength", "nauticaldaylengthmin", "nauticaldaylengthmax", "sunrise", "sunset", "civilsunrise", "civilsunset", "nauticalsunrise", "nauticalsunset", "daynightflag", "isday", "isnight", "moonrise", "moonset", "graphA", "graphB", "graphC", "graphD", "graphE", "graphF", "graphG", "graphH", "primarysensors", "noprimarysensors"})

            Dim wbLbl As New List(Of String)({"Mac Address", "Software Ver", "Build #", "Platform", "Station", "Station #", "Language", "Time zone", "Altitude", "Latitude", "Longitude", "Up time", "CPU load 1 min", "CPU load 5 min", "CPU load 15 min", "IP", "Lan IP", "WLAN IP", "Last Data", "Last good data", "Solar max", "Lunar age", "Lunar percent", "Lunar segment", "Day length", "Day length min", "Day length max", "Civil day length", "Civil day length min", "Civil day length max", "Nautical day length", "Nautical day length min", "Nautical day length max", "Sunrise", "Sunset", "Civil sunrise", "Civil sunset", "Nautical sunrise", "Nautical sunset", "Day/Night flag", "Isday", "Isnight", "Moonrise", "Moonset", "Graph A", "Graph B", "Graph C", "Graph D", "Graph E", "Graph F", "Graph G", "Graph H", "Primary sensors", "No primary sensors"})

            'forecast
            Dim wbFnfo As New List(Of String)({"rule", "text", "textde", "textdeiso", "textdehtml", "textit", "textnl", "textest", "texthr", "textcz", "texteshtml"})
            Dim wbFlbl As New List(Of String)({"Rule", "English", "German (UTF-8)", "German (ISO-8859)", "German (HTML)", "Italian", "Dutch", "Estonian (UTF-8)", "Hungarian (HTML)", "Czech (UTF-8)", "Spanish (HTML)"})

            With FrmMain.DgvWb
                .BorderStyle = BorderStyle.None
                .ColumnCount = 2
                .Rows.Clear()
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(0).Width = 125
                .DefaultCellStyle.SelectionBackColor = .DefaultCellStyle.BackColor
                .DefaultCellStyle.SelectionForeColor = .DefaultCellStyle.ForeColor
                For j = 0 To wbNfo.Count - 1
                    Try
                        Using wc As New WebClient With {
                            .UseDefaultCredentials = True,
                            .Credentials = New NetworkCredential(My.Settings.wbLogin, My.Settings.wbPassword)
                            }
                            .Rows.Add _
                                (wbLbl(j),
                                 wc.DownloadString(New Uri($"http://{My.Settings.wbIp}/cgi-bin/template.cgi?template=[mbsystem-{wbNfo(j)}]&contenttype=text/plain;charset=iso-8859-1")))
                            If j = 8 Then
                                Dim ab = M2Ft(CDbl(wc.DownloadString(New Uri($"http://{My.Settings.wbIp}/cgi-bin/template.cgi?template=[mbsystem-{wbNfo(j)}]&contenttype=text/plain;charset=iso-8859-1"))))
                                FrmMain.NumElevation.Value = CDec(ab)
                                My.Settings.ElevationFt = ab

                            End If
                        End Using
                    Catch ex As WebException
                        PrintLog($"{ex.InnerException}{vbLf}")
                        PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
                    Catch ex As Exception
                        PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
                    Finally
                        'a
                    End Try
                    Application.DoEvents()
                Next

                For j = 0 To wbFnfo.Count - 1
                    Try
                        Using wc As New WebClient With {
                            .UseDefaultCredentials = True,
                            .Credentials = New NetworkCredential(My.Settings.wbLogin, My.Settings.wbPassword)
                            }
                            .Rows.Add _
                                (wbFlbl(j),
                                 wc.DownloadString(New Uri($"http://{My.Settings.wbIp}/cgi-bin/template.cgi?template=[forecast-{wbFnfo(j)}]&contenttype=text/plain;charset=iso-8859-1")))
                        End Using
                    Catch ex As WebException
                        PrintLog($"{ex.InnerException}{vbLf}")
                        PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
                    Catch ex As Exception
                        PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
                    Finally
                        'a
                    End Try
                    Application.DoEvents()
                Next
            End With
            PrintLog($"Weatherbridge Station Data completed @ {Now:T}{vbLf}")
        End With
    End Sub

End Module