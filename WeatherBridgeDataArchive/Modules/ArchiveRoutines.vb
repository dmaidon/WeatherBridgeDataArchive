Imports System.Globalization
Imports System.IO

Friend Module ArchiveRoutines

    'https://www.meteobridge.com/wiki/index.php/Templates

    Friend Async Sub WriteCurrentData()
        'write information to YYYY folder (Ex: /Archives/2019/12212019.csv)
        Dim DData As New List(Of String)
        Try
            Dim _cd = Path.Combine(ArcDirYr, $"{Now:MMddyyyy}.csv")
            DData.Add($"{Now:HH:mm:ss}")
            DData.Add(Gwd("th*temp-act=F.1:0"))
            DData.Add(Gwd("th*hum-act:*"))
            DData.Add(Gwd("th*dew-act=F.1:0"))
            DData.Add(Gwd("th*heatindex-act=F.1:*"))
            DData.Add(Gwd("thb*press-act:*"))
            DData.Add(Gwd("thb*seapress-act:*"))
            DData.Add(Gwd("wind*wind-act=mph.1:*"))
            DData.Add(Gwd("wind*avgwind-act=mph.1:*"))
            DData.Add(Gwd("wind*dir-act:*"))
            DData.Add(Gwd("wind*chill-act=F.1:*"))
            DData.Add(Gwd("rain*rate-act=in.3:*"))
            DData.Add(Gwd("rain*total-act=in.3:*"))
            DData.Add(Gwd("uv*index-act:0"))
            DData.Add(Gwd("sol*rad-act:0"))
            DData.Add(Gwd("sol*evo-act=in.3:0"))
            DData.Add($"{CalculateCloudBase(CDbl(DData(1)), CDbl(DData(3))):F2}")
            DData.Add(Gwd("rain*total-sumday=in.2:0"))

            Dim aa = ""
            If Not File.Exists(_cd) Then
                aa = $"#Date: {Now:dddd MMMM d yyyy}{vbLf _
                    }Time,Temp,Humidity,Dewpoint,Heat Index,Baro Press,Sea Level Press,Wind Spd,Avg Wind Spd,Wind Dir,Wind Chill,Rain Rate,Rain Total Year,UV Index,SolarRad,Evapo,Cloud Base, Rain Total Today{ _
                    vbLf}"
            End If
            Using w As New StreamWriter(_cd, True)
                Await w.WriteAsync(aa & String.Join(",", DData) & vbLf)
                DData.Clear()
            End Using
            PrintLog($"Wrote current data @ {Now:F}.{vbLf}")
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            'a
        End Try
    End Sub

    Friend Async Sub WriteYesterdayData()
        'write information to yyyy folder (Ex: Archives/2019/Dec2019.csv)
        Dim provider = CultureInfo.InvariantCulture
        Const fmt = "yyyyMMddHHmmss"
        Const f2 = "H:mm"
        Dim a As String
        Dim YData As New List(Of String)

        Try
            Dim _yd = If(Now.Day = 1, Path.Combine(ArcDirYr, $"{Now.AddDays(-1):MMMyyyy}.csv"), Path.Combine(ArcDirYr, $"{Now:MMMyyyy}.csv"))
            YData.Add($"{Now.AddDays(-1):MMM d}")
            YData.Add(Gwd("th*temp-ydmax=F.1:*"))
            a = Gwd("th*temp-ydmaxtime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            YData.Add(a)

            YData.Add(Gwd("th*temp-ydmin=F.1:*"))
            a = Gwd("th*temp-ydmintime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            YData.Add(a)

            YData.Add(Gwd("th*hum-ydmax:*"))
            YData.Add(Gwd("th*hum-ydmin:*"))
            YData.Add(Gwd("th*dew-ydmax=F.1:*"))
            YData.Add(Gwd("th*dew-ydmin=F.1:*"))
            YData.Add(Gwd("th*heatindex-ydmax=F.1:*"))
            a = Gwd("th*heatindex-ydmaxtime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            YData.Add(a)

            YData.Add(Gwd("thb*press-ydmax:*"))
            YData.Add(Gwd("thb*press-ydmin:*"))
            YData.Add(Gwd("thb*seapress-ydmax:*"))
            YData.Add(Gwd("thb*seapress-ydmin:*"))
            YData.Add(Gwd("wind*wind-ydmax=mph.1:*"))
            a = Gwd("wind*wind-ydmaxtime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            YData.Add(a)

            YData.Add(Gwd("wind*avgwind-ydavg=mph.1:*"))
            YData.Add(Gwd("wind*dir-ydavg:*"))
            YData.Add(Gwd("wind*chill-ydmin=F.1:*"))
            a = Gwd("wind*chill-ydmintime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            YData.Add(a)

            YData.Add(Gwd("rain*rate-ydmax=in.3:*"))
            YData.Add(Gwd("rain*total-ydaysum=in.3:*"))
            YData.Add(Gwd("uv*index-ydmax:*"))
            a = Gwd("uv*index-ydmaxtime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            YData.Add(a)

            YData.Add(Gwd("sol*rad-ydmax:*"))
            a = Gwd("sol*rad-ydmaxtime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            YData.Add(a)

            YData.Add(Gwd("rain*total-yearsum=in.2:0"))

            Dim aa = ""
            If Not File.Exists(_yd) Then
                aa = $"#Month: {Now:MMMM yyyy}{vbLf _
                    }Date,High Temp,High Temp Time,Low Temp,Low Temp Time,Max Humidity,Min Humidity,Max Dew Point,Min Dewpoint,Max Heat Index,Max Heat Index Time,Max Baro Press,Min Baro Press,Max Sea Level Press,Min Sea level Press,Max Wind Spd,Max Wind Spd Time,Average Wind Speed,Wind Direction,Min Wind Chill,Min Wind Chill Time,Rain Rate,Rain Total Yesterday,Max UV Index,Max UV Index Time, Max SolarRad,Max SolarRad Time, Rain Total Today{ _
                    vbLf}"
            End If

            Using w As New StreamWriter(_yd, True)
                Await w.WriteAsync(aa & String.Join(",", YData) & vbLf)
                YData.Clear()
            End Using
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            'a
        End Try
    End Sub

    Friend Async Sub WriteMonthlyData()
        'write information to YYYY folder (Ex: /Archives/2019)
        Dim _md = If(Now.Day = 1,
            Path.Combine(ArcDirYr, $"{Now.AddDays(-1):yyyy}.csv"),
            Path.Combine(ArcDirYr, $"{Now:yyyy}.csv"))
        Dim provider = CultureInfo.InvariantCulture
        Const fmt = "yyyyMMddHHmmss"
        Const f2 = "MMM d @ H:mm"
        Dim a As String
        Dim MData As New List(Of String)

        Try
            MData.Add($"{Now:MMMM}")
            MData.Add(Gwd("th*temp-mmax=F.1:0"))
            a = Gwd("th*temp-mmaxtime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            MData.Add(a)

            MData.Add(Gwd("th*temp-mmin=F.1:0"))
            a = Gwd("th*temp-mmintime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            MData.Add(a)

            MData.Add(Gwd("th*hum-mmax:0"))
            MData.Add(Gwd("th*hum-mmin:0"))
            MData.Add(Gwd("th*dew-mmax=F.1:0"))
            MData.Add(Gwd("th*dew-mmin=F.1:0"))
            MData.Add(Gwd("th*heatindex-mmax=F.1:0"))
            a = Gwd("th*heatindex-mmaxtime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            MData.Add(a)

            MData.Add(Gwd("thb*press-mmax:0"))
            MData.Add(Gwd("thb*press-mmin:0"))
            MData.Add(Gwd("thb*seapress-mmax:0"))
            MData.Add(Gwd("thb*seapress-mmin:0"))
            MData.Add(Gwd("wind*wind-mmax=mph.1:0"))
            a = Gwd("wind*wind-mmaxtime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            MData.Add(a)

            MData.Add(Gwd("wind*avgwind-mavg=mph.1:0"))
            MData.Add(Gwd("wind*dir-mavg:0"))
            MData.Add(Gwd("wind*chill-mmin=F.1:0"))
            a = Gwd("wind*chill-mmintime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            MData.Add(a)

            MData.Add(Gwd("rain*total-monthsum=in.2:0"))
            MData.Add(Gwd("rain*total-yearsum=in.2:0"))
            MData.Add(Gwd("uv*index-mmax:0"))
            a = Gwd("uv*index-mmaxtime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            MData.Add(a)

            MData.Add(Gwd("sol*rad-mmax:0"))
            a = Gwd("sol*rad-mmaxtime:*")
            a = If(a = "*", "", $"{Date.ParseExact(a, fmt, provider).ToString(f2, CultureInfo.CurrentCulture)}")
            MData.Add(a)

            Dim aa = ""
            If Not File.Exists(_md) Then
                aa = $"#Year: {Now.AddDays(-1):yyyy}{vbLf _
                    }Month,High Temp,High Temp Date,Low Temp,Low Temp Date,Max Humidity,Min Humidity,Max Dew Point,Min Dewpoint,Max Heat Index,Max Heat Index Date,Max Baro Press,Min Baro Press,Max Sea Level Press,Min Sea level Press,Max Wind Spd,Max Wind Spd Date,Average Wind Speed,Wind Direction,Min Wind Chill,Min Wind Chill Date,Rain Total Month,Rain Total Year,Max UV Index,Max UV Index Date, Max SolarRad,Max SolarRad Date{vbLf}"
            End If
            Using w As New StreamWriter(_md, True)
                Await w.WriteAsync(aa & String.Join(",", MData) & vbLf)
                MData.Clear()
            End Using
            PrintLog($"Monthly data updated @ {Now:T}{vbLf}")
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            'a
        End Try
    End Sub

    ''' <summary>
    ''' </summary>
    ''' <param name="T">temperature</param>
    ''' <param name="dp">dew point</param>
    ''' <returns>altitude in feet</returns>
    Private Function CalculateCloudBase(T As Double, dp As Double) As Double
        Return ((T - dp) / 4.4 * 1000) + My.Settings.ElevationFt
    End Function

End Module