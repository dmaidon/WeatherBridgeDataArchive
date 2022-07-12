Imports System.Drawing.Imaging
Imports System.IO

Namespace Modules
    Friend Module ImageRoutines

        ''' <summary>
        ''' Saves Control to PNG image
        ''' </summary>
        ''' <param name="ctl">Control name</param>
        ''' <param name="fn">file name</param>
        ''' <param name="str">log string</param>
        Friend Sub SaveForecastImages(ctl As Control, fn As String, str As String, sDir As String)
            ''https://www.aspsnippets.com/Articles/Convert-Export-DataGridView-to-Bitmap-PNG-Image-in-Windows-Forms-WinForms-Application-using-C-and-VBNet.aspx
            'Dim ax As String = Path.Combine(Application.StartupPath, sDir, fn)
            Dim ax As String = Path.Combine(sDir, fn)
            If File.Exists(ax) Then
                Try
                    File.Delete(ax)
                    PrintLog($"{vbLf}{My.Resources.separator}{vbLf}Deleted {str} Image: {ax}{vbLf}")
                Catch ex As Exception When TypeOf ex Is ArgumentException _
                                           OrElse TypeOf ex Is ArgumentNullException _
                                           OrElse TypeOf ex Is DirectoryNotFoundException _
                                          OrElse TypeOf ex Is NotSupportedException _
                                           OrElse TypeOf ex Is PathTooLongException
                    PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
                Catch ex As Exception When TypeOf ex Is UnauthorizedAccessException OrElse TypeOf ex Is IOException
                    '1/1/20
                    'PrintLog($"{ax} does not exist.{vbLf}{vbLf}")
                    Return
                Finally
                    'a
                End Try
            End If

            Try
                'Create a Bitmap and draw the control on it.
                Using bitmap = New Bitmap(ctl.Width, ctl.Height)
                    ctl.DrawToBitmap(bitmap, New Rectangle(0, 0, ctl.Width, ctl.Height))
                    bitmap.Save(ax, ImageFormat.Png)
                    PrintLog($"Saved {str} Image: {ax}{vbLf}{vbLf}{My.Resources.separator}{vbLf}")
                End Using
            Catch ex As Exception
                'PrintErr(ex.Message, ex.TargetSite.ToString, ex.StackTrace, ex.GetBaseException().ToString(), ex.HelpLink, ex.Data.ToString)
                '1/1/20
                Return
            Finally
                SaveLogs()
            End Try
        End Sub

#Region "ResizeImage"

        ''https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net
        ''Public Function ResizeImage(SourceImage As Drawing.Image, TargetWidth As Int32, TargetHeight As Int32) As Drawing.Bitmap
        ''    Using bmSource As New Bitmap(SourceImage)
        ''        Return ResizeImage(bmSource, TargetWidth, TargetHeight)
        ''    End Using
        ''End Function

        'Friend Function ResizeImage(bmSource As Drawing.Bitmap, TargetWidth As Int32, TargetHeight As Int32) As Drawing.Bitmap
        '    Using bmDest As New Bitmap(TargetWidth, TargetHeight, Drawing.Imaging.PixelFormat.Format32bppArgb)

        '        Dim nSourceAspectRatio = bmSource.Width / bmSource.Height
        '        Dim nDestAspectRatio = bmDest.Width / bmDest.Height

        '        Dim NewX = 0
        '        Dim NewY = 0
        '        Dim NewWidth = bmDest.Width
        '        Dim NewHeight = bmDest.Height

        '        If nDestAspectRatio = nSourceAspectRatio Then
        '            'same ratio
        '        ElseIf nDestAspectRatio > nSourceAspectRatio Then
        '            'Source is taller
        '            NewWidth = Convert.ToInt32(Math.Floor(nSourceAspectRatio * NewHeight))
        '            NewX = Convert.ToInt32(Math.Floor((bmDest.Width - NewWidth) / 2))
        '        Else
        '            'Source is wider
        '            NewHeight = Convert.ToInt32(Math.Floor((1 / nSourceAspectRatio) * NewWidth))
        '            NewY = Convert.ToInt32(Math.Floor((bmDest.Height - NewHeight) / 2))
        '        End If

        '        Using grDest = Drawing.Graphics.FromImage(bmDest)
        '            With grDest
        '                .CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
        '                .InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        '                .PixelOffsetMode = Drawing.Drawing2D.PixelOffsetMode.HighQuality
        '                '.SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias
        '                .CompositingMode = Drawing.Drawing2D.CompositingMode.SourceCopy
        '                .DrawImage(bmSource, NewX, NewY, NewWidth, NewHeight)
        '            End With
        '        End Using

        '        Return bmDest
        '    End Using
        'End Function

#End Region

    End Module
End Namespace