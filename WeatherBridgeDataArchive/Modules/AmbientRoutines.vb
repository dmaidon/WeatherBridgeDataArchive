Imports System.IO
Imports System.Net
Imports System.Security
Imports WeatherBridgeDataArchive.Models.Ambient

Friend Module AmbientRoutines

    Private _awNfo As WxData()
    Private fn As String
    ''https://www.meteobridge.com/wiki/index.php/Home
    ''https://api.ambientweather.net/v1/devices?applicationKey=AAAA%26apiKey=BBBB
    ''https://www.meteobridge.com/wiki/index.php/Templates

    Friend Sub FetchAmbientData()
        If Not AmbientEnable Then
            Return
        End If
        fn = Path.Combine(TempDir, $"amb-{Now:Mdyy}.json")
        Dim ab = (Date2Unix(Now) - Date2Unix(File.GetLastWriteTime(fn))) / 60
        If IsDomainAlive("api.ambientweather.net", 5) Then
            If ab >= 60 Then
                DownloadAmbientData()
            Else
                ParseAmbientData(fn)
            End If
        Else
            If File.Exists(fn) Then
                ParseAmbientData(fn)
            End If
        End If

    End Sub

    Friend Async Sub DownloadAmbientData()

        Dim resp As String

        Dim Use_Agent As String = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.182 Safari/537.36 Edg/88.0.705.74"

        Try
            PrintLog($"Fetching Ambient Weather data @ {Now:T}.{vbLf}")
            Dim request = CType(WebRequest.Create(New Uri($"https://api.ambientweather.net/v1/devices?applicationKey={My.Settings.AppKey}&apiKey={My.Settings.ApiKey}")), HttpWebRequest)
            With request
                .AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
                .Accept = "application/json"
                .Timeout = 120000
                .Headers.Add("Accept-Encoding", "gzip, deflate")
                .UserAgent = Use_Agent
            End With

            Using response = CType(Await request.GetResponseAsync(), HttpWebResponse)
                PrintLog($"{response.StatusCode}{vbLf}{response.StatusDescription}{vbLf}")
                If My.Settings.LogHdrData Then
                    PrintLog($"{My.Resources.separator}{vbLf}AmbientWeather Cache Control:{vbLf}")
                    For j = 0 To response.Headers.Count - 1
                        PrintLog($"   {response.Headers.Keys(j)}: {response.Headers.Item(j)}{vbLf}")
                    Next
                    PrintLog($"{My.Resources.separator}{vbLf}{vbLf}")
                End If
                If response.StatusCode = HttpStatusCode.OK Then
                    Dim dStr = response.GetResponseStream()
                    Using reader = New StreamReader(dStr)
                        resp = (Await reader.ReadToEndAsync()).Replace("dateutc", "da-eutc").Replace("date", "dateZ").Replace("da-eutc", "dateutc")
                        File.WriteAllText(fn, resp)
                        _awNfo = WxData.FromJson(resp)
                    End Using
                    PrintLog($"Ambient Weather Data @ {Now:T}{vbLf}{resp}{vbLf}")
                    WriteAmbientData()
                Else
                    Return
                End If
            End Using
        Catch ex As Exception When _
                        TypeOf ex Is InvalidOperationException OrElse TypeOf ex Is ProtocolViolationException OrElse TypeOf ex Is NotSupportedException _
                        OrElse TypeOf ex Is WebException OrElse TypeOf ex Is ArgumentNullException OrElse TypeOf ex Is SecurityException _
                        OrElse TypeOf ex Is OutOfMemoryException OrElse TypeOf ex Is IOException
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            SaveLogs()
        End Try

    End Sub

    Private Sub WriteAmbientData()
        Try
            PrintLog($"{vbLf}Write Ambient Data to grid.{vbLf}")
            Dim ai = _awNfo(0)
            Dim ald = _awNfo(0).LastData
            With FrmMain.DgvAmbient
                .ColumnCount = 2
                .Columns(0).Width = 175
                .Rows.Clear()
                .Rows.Add("Mac Address", ai.MacAddress)
                .Rows.Add("Device Id", ald.DeviceId)
                .Rows.Add("Station Name", _awNfo(0).Info.Name)
                .Rows.Add("Station Location", _awNfo(0).Info.Location)
                .Rows.Add("UTC Date", Unix2Date(CLng(ald.DateUtc / 1000)))
                .Rows.Add("Wind Direction", $"{ald.WindDir}° ({Deg2Compass(CDbl(ald.WindDir))})")
                .Rows.Add("Wind Speed", $"{ald.WindSpeedMph} mph")
                .Rows.Add("10 Minute Wind Gust", $"{ald.WindGustMph} mph")
                .Rows.Add("Wind Gust Direction", $"{ald.WindGustDir}° ({Deg2Compass(CDbl(ald.WindGustDir))})")
                .Rows.Add("Max Daily Wind Gust", $"{ald.MaxDailyGust} mph")
                .Rows.Add("Wind Speed (2 min avg)", $"{ald.WindSpdMphAvg2M} mph")
                .Rows.Add("Wind Direction (2 min avg)", $"{ald.WindDirAvg2M}° ({Deg2Compass(CDbl(ald.WindDirAvg2M))})")
                .Rows.Add("Wind Speed (10 min avg)", $"{ald.WindSpdMphAvg10M}° ({Deg2Compass(CDbl(ald.WindDirAvg10M))})")
                .Rows.Add("Temperature", $"{ald.TempF}°F")
                .Rows.Add("Hourly Rain", $"{ald.HourlyRainIn} in.")
                .Rows.Add("Rain this Event", $"{ald.EventRainIn} in.")
                .Rows.Add("Daily Rain", $"{ald.DailyRainIn} in.")
                .Rows.Add("Monthly Rain", $"{ald.MonthlyRainIn} in.")
                .Rows.Add("Yearly Rain", $"{ald.YearlyRainIn} in.")
                .Rows.Add("Last Rain", $"{ald.LastRain.ToLocalTime():F}")
                .Rows.Add("Battery: Outdoor", ald.BattOut)
                .Rows.Add("Battery: Indoor", ald.BattIn)
                '.Rows.Add("Total Rain", $"{ald.YearlyRainIn} in.")
                .Rows.Add("Barometric Pressure", $"{ald.BaromRelIn} inHg")
                .Rows.Add("Barometric Pressure (Sea Level)", $"{ald.BaromAbsIn} inHg")
                .Rows.Add("Humidity", $"{ald.Humidity}%")
                .Rows.Add("Indoor Temp", $"{ald.TempInF}°F")
                .Rows.Add("Indoor Humidity", $"{ald.HumidityIn}%")
                .Rows.Add($"UV", $"{ald.Uv}")
                .Rows.Add("Solar Radiation", $"{ald.SolarRadiation} W/m²")
                .Rows.Add("Feels Like", $"{ald.FeelsLike}°F")
                .Rows.Add("Dew Point", $"{ald.DewPoint}°F")
                .Rows.Add("Dew Point Indoors", $"{ald.DewPointIn}°F")
                .Rows.Add("Date UTC Epoch", ald.DateUtc)
                .Rows.Add("Date (Local)", $"{ald.DateZ.ToLocalTime():F}")
                .Rows.Add("Timezone", ald.Tz)

                .Rows.Add($"Information")
                .Rows.Add("Name", ai.Info.Name)
                .Rows.Add("Location", ai.Info.Location)
                .Rows.Add("Coordinates", $"{ai.Info.Coords.Coords.Lat}, {ai.Info.Coords.Coords.Lon}")
                .Rows.Add("Address", ai.Info.Coords.Address)
                .Rows.Add("Location", ai.Info.Coords.Location)
                .Rows.Add("Elevation", ai.Info.Coords.Elevation)
                .Rows.Add("Geo")
                .Rows.Add(NameOf(Type), ai.Info.Coords.Geo.Type)
                .Rows.Add("Coordinates", $"{ai.Info.Coords.Geo.Coordinates(0)}, {ai.Info.Coords.Geo.Coordinates(1)}")
            End With
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            PrintLog($"{My.Resources.separator}{vbLf}{vbLf}")
            SaveLogs()
        End Try

    End Sub

    Private Async Sub ParseAmbientData(fn As String)
        Try
            PrintLog($"{vbLf}Reading Ambient Weather Data from cache @ {Now:T}{vbLf}")
            Dim resp As String
            Using reader = New StreamReader(fn)
                resp = Await reader.ReadToEndAsync()
                _awNfo = WxData.FromJson(resp)
                PrintLog($"[Parsed] Ambient Weather Data @ {Now:T}{vbLf}File: {fn}{vbLf}")
            End Using
            'PrintLog($"{vbLf}-{Now:T}- Parsed Ambient data file  -> [{fn}]{vbLf}")
            WriteAmbientData()
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            'a
        End Try
    End Sub

End Module