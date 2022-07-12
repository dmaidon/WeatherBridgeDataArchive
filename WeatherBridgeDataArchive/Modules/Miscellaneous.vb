Imports System.Globalization
Imports System.Net
Imports System.Net.Sockets

Friend Module Miscellaneous

    Friend Function Date2Unix(dateTime As Date) As Long
        Try
            Return CLng(Fix(dateTime.Subtract(New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds))
        Catch ex As ArgumentOutOfRangeException
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
            Return 0
        Finally
            ''a
        End Try
    End Function

    Friend Function Unix2Date(strUnixTime As Long) As Date
        Try
            Dim nDateTime = New DateTime(1970, 1, 1, 0, 0, 0, 0)
            Return nDateTime.AddSeconds(CDbl(strUnixTime.ToString(CultureInfo.CurrentCulture)))
        Catch ex As ArgumentOutOfRangeException
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
            Return New DateTime(Now.ToFileTimeUtc())
        Finally
            ''a
        End Try
    End Function

    Friend Function Gwd(ds As String) As String
        Try
            Using wc As New WebClient With {
                    .UseDefaultCredentials = True,
                    .Credentials = New NetworkCredential(My.Settings.wbLogin, My.Settings.wbPassword)
                    }
                Return wc.DownloadString(New Uri($"http://{My.Settings.wbIp}/cgi-bin/template.cgi?template=[{ds}]&contenttype=text/plain;charset=iso-8859-1"))
            End Using
        Catch ex As Exception When TypeOf ex Is ArgumentNullException OrElse TypeOf ex Is WebException OrElse TypeOf ex Is NotSupportedException
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
            Return "*"
        Finally
            'a
        End Try
    End Function

    Friend Function Deg2Compass(num As Double) As String
        ''https://stackoverflow.com/questions/7490660/converting-wind-direction-in-angles-to-text-words
        num *= 10
        Dim cardinals As New List(Of String)({"N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N"})
        Return cardinals(CInt(Math.Truncate(Math.Round((num Mod 3600) / 225))))
    End Function

    Friend Function IsDomainAlive(aDomain As String, aTimeoutSeconds As Integer) As Boolean
        'https://stackoverflow.com/questions/1500955/adjusting-httpwebrequest-connection-timeout-in-c-sharp
        Try
            Using client As New TcpClient()
                Dim result = client.BeginConnect(aDomain, 80, Nothing, Nothing)
                Dim success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(aTimeoutSeconds))
                If Not success Then
                    PrintLog($"{aDomain} Active: False{vbLf}")
                    Return False
                End If

                ' we have connected
                client.EndConnect(result)
                PrintLog($"{aDomain} Domain Active: True{vbLf}")
                Return True
            End Using
        Catch ex As Exception
            PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
        End Try
        PrintLog($"Domain {aDomain}: false{vbLf}")
        Return False
    End Function

    Friend Function Mm2In(v As Double) As Double
        Return v / 25.4
    End Function

    Friend Function M2Ft(v As Double) As Double
        Return v * 3.2808399
    End Function

End Module