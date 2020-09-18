Imports System.Globalization
Imports System.Net
Imports System.Text

Friend Module RecordsRoutines

    Private Const fmt1 = "yyyyMMddHHmmss"
    Private Const fmt2 = "H:mm"
    Private Const fmt3 = "M/d/yy"

    Friend Sub CreateRecordsGrid()
        With FrmMain.DgvRecords
            Dim atTxt As String
            If CInt(My.Settings.YearStarted) = Now.Year Then
                atTxt = $"{Now:yyyy}"
            Else
                atTxt = $"{My.Settings.YearStarted}-{Now:yy}"
            End If
            .Rows.Add("", atTxt, Now.Year, $"{Now:MMMM}", $"{Date.Now.AddDays(-1):MMM d}", $"{Now:MMM d}", $"{Now:t}")
            .Rows.Add($"High{vbLf}Temperature")
            .Rows.Add($"Low{vbLf}Temperature")
            .Rows.Add($"Wind{vbLf}Maximum")
            .Rows.Add($"Rain")
            .Rows.Add($"Windchill{vbLf}Low")
            .Rows.Add($"Heat Index{vbLf}High")
            .Rows.Add($"Barometric{vbLf}Pressure")
            .Rows(0).Height = 19
            .Rows(0).DefaultCellStyle.BackColor = Color.Gainsboro
            .Rows(0).DefaultCellStyle.ForeColor = Color.MidnightBlue
            For j = 0 To 7
                .Rows(j).Cells(0).Style.ForeColor = Color.Maroon
                .Rows(j).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Rows(j).DefaultCellStyle.Font = New Font("", 7, FontStyle.Bold)
                .Rows(j).Cells(0).Style.BackColor = Color.Gainsboro
                Application.DoEvents()
            Next
        End With
    End Sub



    Friend Sub UpdateHourHiLo()
        Try
            With FrmMain.DgvRecords
                Dim provider As CultureInfo = CultureInfo.InvariantCulture
                Dim a As String
                .Rows(0).Cells(6).Value = $"{Now:h:mm tt}"
                .Rows(0).Cells(6).ToolTipText = $"{Now:F}"
                .Rows(1).Cells(6).Value = $"{Gwd("th*temp-hmax=F.1:*")}°F"
                .Rows(2).Cells(6).Value = $"{Gwd("th*temp-hmin=F.1:*")}°F"

                a = Gwd("wind*wind-hmaxtime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt2, CultureInfo.CurrentCulture)})")
                .Rows(3).Cells(6).Value = $"{Gwd("wind*wind-hmax=mph.1:*")} mph{vbLf}{a}"
                .Rows(4).Cells(6).Value = $"{Gwd("rain*total-hoursum=in.2:*")} in"

                .Rows(5).Cells(6).Value = $"{Gwd("wind*chill-hmin=F.1:*")}°F"
                .Rows(6).Cells(6).Value = $"{Gwd("th*heatindex-hmax=F.1:*")}°F"
                .Rows(7).Cells(6).Value = $"Hi: {Gwd("thb*press-hmax=inHg.2:*")} in{vbLf}Lo: {Gwd("thb*press-hmin=inHg.2:*")} in"

                PrintLog($"Updated Records @ {Now:F}{vbLf}")
            End With
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            'a
        End Try

    End Sub

    Friend Sub UpdateDailyHiLo()
        Try
            With FrmMain.DgvRecords
                Dim provider As CultureInfo = CultureInfo.InvariantCulture
                Dim a As String
                Dim b As String

                a = Gwd("th*temp-dmaxtime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt2, CultureInfo.CurrentCulture)})")
                b = Gwd("th*temp-dmintime:*")
                b = If(b = "*", "", $"({Date.ParseExact(b, fmt1, provider).ToString(fmt2, CultureInfo.CurrentCulture)})")

                .Rows(0).Cells(5).Value = $"{Now:MMM d}"
                .Rows(0).Cells(5).ToolTipText = $"{Now:F}"
                .Rows(1).Cells(5).Value = $"{Gwd("th*temp-dmax=F.1:*")}°F{vbLf}{a}"
                .Rows(2).Cells(5).Value = $"{Gwd("th*temp-dmin=F.1:*")}°F{vbLf}{b}"

                a = Gwd("wind*wind-dmaxtime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt2, CultureInfo.CurrentCulture)})")

                .Rows(3).Cells(5).Value = $"{Gwd("wind*wind-dmax=mph.1:*")} mph{vbLf}{a}"
                .Rows(4).Cells(5).Value = $"{Gwd("rain*total-daysum=in.2:*")} in"

                a = Gwd("wind*chill-dmintime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt2, CultureInfo.CurrentCulture)})")
                b = Gwd("th*heatindex-dmaxtime:*")
                b = If(b = "*", "", $"({Date.ParseExact(b, fmt1, provider).ToString(fmt2, CultureInfo.CurrentCulture)})")

                .Rows(5).Cells(5).Value = $"{Gwd("wind*chill-dmin=F.1:*")}°F{vbLf}{a}"
                .Rows(6).Cells(5).Value = $"{Gwd("th*heatindex-dmax=F.1:*")}°F{vbLf}{b}"
                .Rows(7).Cells(5).Value = $"Hi: {Gwd("thb*press-dmax=inHg.2:*")} in{vbLf}Lo: {Gwd("thb*press-hmin=inHg.2:*")} in"

            End With
        Catch ex As Exception When TypeOf ex Is ArgumentNullException OrElse TypeOf ex Is FormatException OrElse TypeOf ex Is ArgumentOutOfRangeException
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            'a
        End Try

    End Sub

    Friend Sub UpdateYesterdayHiLo()
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim a As String
            Dim b As String
            With FrmMain.DgvRecords
                a = Gwd("th*temp-ydmaxtime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt2, CultureInfo.CurrentCulture)})")
                b = Gwd("th*temp-ydmintime:*")
                b = If(b = "*", "", $"({Date.ParseExact(b, fmt1, provider).ToString(fmt2, CultureInfo.CurrentCulture)})")
                .Rows(0).Cells(4).Value = $"{Now.AddDays(-1):MMM d}"
                .Rows(0).Cells(4).ToolTipText = $"{Now:F}"
                .Rows(1).Cells(4).Value = $"{Gwd("th*temp-ydmax=F.1:*")}°F{vbLf}{a}"
                .Rows(2).Cells(4).Value = $"{Gwd("th*temp-ydmin=F.1:*")}°F{vbLf}{b}"

                a = Gwd("wind*wind-ydmaxtime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt2, CultureInfo.CurrentCulture)})")
                .Rows(3).Cells(4).Value = $"{Gwd("wind*wind-ydmax=mph.1:*")} mph{vbLf}{a}"
                .Rows(4).Cells(4).Value = $"{Gwd("rain*total-ydaysum=in.2:*")} in"

                Try
                    a = Gwd("wind*chill-ydmintime:*")
                    a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt2, CultureInfo.CurrentCulture)})")
                    b = Gwd("th*heatindex-ydmaxtime:*")
                    b = If(b = "*", "", $"({Date.ParseExact(b, fmt1, provider).ToString(fmt2, CultureInfo.CurrentCulture)})")
                Catch ex As Exception
                    PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
                Finally
                    'a
                End Try

                .Rows(5).Cells(4).Value = $"{Gwd("wind*chill-ydmin=F.1:*")}°F{vbLf}{a}"
                .Rows(6).Cells(4).Value = $"{Gwd("th*heatindex-ydmax=F.1:*")}°F{vbLf}{b}"
                .Rows(7).Cells(4).Value = $"Hi: {Gwd("thb*press-ydmax=inHg.2:*")} in{vbLf}Lo: {Gwd("thb*press-hmin=inHg.2:*")} in"
            End With
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            'a
        End Try

    End Sub

    Friend Sub UpdateMonthHiLo()
        Try
            With FrmMain.DgvRecords
                Dim provider As CultureInfo = CultureInfo.InvariantCulture
                Dim a As String
                Dim b As String
                a = Gwd("th*temp-mmaxtime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")
                b = Gwd("th*temp-mmintime:*")
                b = If(b = "*", "", $"({Date.ParseExact(b, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")

                Dim sb As New StringBuilder()
                .Rows(0).Cells(3).Value = $"{Now:MMMM}"
                .Rows(0).Cells(3).ToolTipText = $"{Now:F}"
                .Rows(1).Cells(3).Value = $"{Gwd("th*temp-mmax=F.1:*")}°F{vbLf}{a}"
                .Rows(2).Cells(3).Value = $"{Gwd("th*temp-mmin=F.1:*")}°F{vbLf}{b}"

                a = Gwd("wind*wind-mmaxtime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")
                .Rows(3).Cells(3).Value = $"{Gwd("wind*wind-mmax=mph.1:*")} mph{vbLf}{a}"
                .Rows(4).Cells(3).Value = $"{Gwd("rain*total-monthsum=in.2:*")} in"

                a = Gwd("wind*chill-mmintime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")
                b = Gwd("th*heatindex-mmaxtime:*")
                b = If(b = "*", "", $"({Date.ParseExact(b, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")

                .Rows(5).Cells(3).Value = $"{Gwd("wind*chill-mmin=F.1:*")}°F{vbLf}{a}"
                .Rows(6).Cells(3).Value = $"{Gwd("th*heatindex-mmax=F.1:*")}°F{vbLf}{b}"
                .Rows(7).Cells(3).Value = $"Hi: {Gwd("thb*press-mmax=inHg.2:*")} in{vbLf}Lo: {Gwd("thb*press-hmin=inHg.2:*")} in"
            End With
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            'a
        End Try

    End Sub

    Friend Sub UpDateYearHiLo()
        Try
            With FrmMain.DgvRecords
                Dim provider As CultureInfo = CultureInfo.InvariantCulture
                Dim a As String
                Dim b As String
                a = Gwd("th*temp-ymaxtime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")
                b = Gwd("th*temp-ymintime:*")
                b = If(b = "*", "", $"({Date.ParseExact(b, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")

                .Rows(0).Cells(2).Value = $"{Now.Year}"
                .Rows(0).Cells(2).ToolTipText = $"{Now:F}"
                .Rows(1).Cells(2).Value = $"{Gwd("th*temp-ymax=F.1:*")}°F{vbLf}{a}"
                .Rows(2).Cells(2).Value = $"{Gwd("th*temp-ymin=F.1:*")}°F{vbLf}{b}"

                a = Gwd("wind*wind-ymaxtime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")
                .Rows(3).Cells(2).Value = $"{Gwd("wind*wind-ymax=mph.1:*")} mph{vbLf}{a}"
                .Rows(4).Cells(2).Value = $"{Gwd("rain*total-yearsum=in.2:*")} in"

                a = Gwd("wind*chill-ymintime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")
                b = Gwd("th*heatindex-ymaxtime:*")
                b = If(b = "*", "", $"({Date.ParseExact(b, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")

                .Rows(5).Cells(2).Value = $"{Gwd("wind*chill-ymin=F.1:*")}°F{vbLf}{a}"
                .Rows(6).Cells(2).Value = $"{Gwd("th*heatindex-ymax=F.1:*")}°F{vbLf}{b}"
                .Rows(7).Cells(2).Value = $"Hi: {Gwd("thb*press-ymax=inHg.2:*")} in{vbLf}Lo: {Gwd("thb*press-hmin=inHg.2:*")} in"
            End With
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            'a
        End Try
    End Sub

    Friend Sub UpdateAllTimeHiLo()
        Try
            With FrmMain.DgvRecords
                Dim provider As CultureInfo = CultureInfo.InvariantCulture
                Dim a As String
                Dim b As String
                a = Gwd("th*temp-amaxtime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")
                b = Gwd("th*temp-amintime:*")
                b = If(b = "*", "", $"({Date.ParseExact(b, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")

                'added this so that if the Year Started is changed in the options, the cell will change on next update
                Dim atTxt As String
                If CInt(My.Settings.YearStarted) = Now.Year Then
                    atTxt = $"{Now:yyyy}"
                Else
                    atTxt = $"{My.Settings.YearStarted}-{Now:yy}"
                End If

                .Rows(0).Cells(1).Value = atTxt
                .Rows(1).Cells(1).Value = $"{Gwd("th*temp-amax=F.1:*")}°F{vbLf}{a}"
                .Rows(2).Cells(1).Value = $"{Gwd("th*temp-amin=F.1:*")}°F{vbLf}{b}"

                a = Gwd("wind*wind-ymaxtime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")
                .Rows(3).Cells(1).Value = $"{Gwd("wind*wind-amax=mph.1:*")} mph{vbLf}{a}"
                .Rows(4).Cells(1).Value = $"{Gwd("rain*total-allsum=in.2:*")} in"

                a = Gwd("wind*chill-amintime:*")
                a = If(a = "*", "", $"({Date.ParseExact(a, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")
                b = Gwd("th*heatindex-amaxtime:*")
                b = If(b = "*", "", $"({Date.ParseExact(b, fmt1, provider).ToString(fmt3, CultureInfo.CurrentCulture)})")

                .Rows(5).Cells(1).Value = $"{Gwd("wind*chill-amin=F.1:*")}°F{vbLf}{a}"
                .Rows(6).Cells(1).Value = $"{Gwd("th*heatindex-amax=F.1:*")}°F{vbLf}{b}"
                .Rows(7).Cells(1).Value = $"Hi: {Gwd("thb*press-amax=inHg.2:*")} in{vbLf}Lo: {Gwd("thb*press-hmin=inHg.2:*")} in"
            End With
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        Finally
            'a
        End Try
    End Sub
End Module
