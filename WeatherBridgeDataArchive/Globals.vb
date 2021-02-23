Imports System.IO

Friend Module Globals

    Public LogDir As String = Path.Combine(Application.StartupPath, "Logs")
    Public TempDir As String = Path.Combine(Application.StartupPath, "$tmp")
    Public DataDir As String = Path.Combine(Application.StartupPath, "Data")
    Public ArcDir As String = Path.Combine(Application.StartupPath, "Archives")
    Public ImgDir As String = Path.Combine(Application.StartupPath, "Images")
    Public RecDir As String = Path.Combine(Application.StartupPath, "Images", "Records")

    Public LogFile, ArcDirYr As String
    Public AppKey, ApiKey As String
    Public Cpy As String = $"©2020-{Now:yyyy} PAROLE Software - all rights reserved."

    'Records update
    Public RecDuration As TimeSpan
    Public RecNextUpdate As Date

    'archive update
    Public ArcDuration As TimeSpan
    Public ArcNextUpdate As Date

    'Ambient update
    Public AmbDuration As TimeSpan
    Public AmbNextUpdate As Date

    'Weatherbridge update
    Public wbDuration As TimeSpan
    Public wbNextUpdate As Date

    'flag to make sure options have been set
    Public Flag As Boolean
    Public AmbientEnable, WbEnable, LogHdrData As Boolean
End Module
