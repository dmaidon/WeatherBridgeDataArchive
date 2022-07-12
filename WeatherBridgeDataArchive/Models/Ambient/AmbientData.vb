Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.CompilerServices

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Converters

Namespace Models.Ambient

    Partial Public Class WxData
        'https://github.com/ambient-weather/api-docs/wiki/Device-Data-Specs

        <JsonProperty("macAddress", NullValueHandling:=NullValueHandling.Ignore)> Public Property MacAddress() As String

        <JsonProperty("lastData", NullValueHandling:=NullValueHandling.Ignore)> Public Property LastData() As Lastdata

        <JsonProperty("info", NullValueHandling:=NullValueHandling.Ignore)> Public Property Info() As Info
    End Class

    Partial Public Class Lastdata
        <JsonProperty("dateutc", NullValueHandling:=NullValueHandling.Ignore)> Public Property DateUtc As Long

        <JsonProperty("winddir", NullValueHandling:=NullValueHandling.Ignore)> Public Property WindDir As Double?

        <JsonProperty("windspeedmph", NullValueHandling:=NullValueHandling.Ignore)> Public Property WindSpeedMph As Double?

        <JsonProperty("windgustmph", NullValueHandling:=NullValueHandling.Ignore)> Public Property WindGustMph As Double?

        <JsonProperty("maxdailygust", NullValueHandling:=NullValueHandling.Ignore)> Public Property MaxDailyGust As Double?

        <JsonProperty("windgustdir", NullValueHandling:=NullValueHandling.Ignore)> Public Property WindGustDir As Double?

        <JsonProperty("winddir_avg2m", NullValueHandling:=NullValueHandling.Ignore)> Public Property WindDirAvg2M As Double?

        <JsonProperty("windspdmph_avg2m", NullValueHandling:=NullValueHandling.Ignore)> Public Property WindSpdMphAvg2M As Double?

        <JsonProperty("winddir_avg10m", NullValueHandling:=NullValueHandling.Ignore)> Public Property WindDirAvg10M As Double?

        <DefaultValue(0)> <JsonProperty("windspdmph_avg10m", DefaultValueHandling:=DefaultValueHandling.Populate)> Public Property WindSpdMphAvg10M As Double?

        <JsonProperty("tempf", NullValueHandling:=NullValueHandling.Ignore)> Public Property TempF As Double?

        <JsonProperty("humidity", NullValueHandling:=NullValueHandling.Ignore)> Public Property Humidity As Double?

        <JsonProperty("solarradiation", NullValueHandling:=NullValueHandling.Ignore)> Public Property SolarRadiation As Double?

        <JsonProperty("uv", NullValueHandling:=NullValueHandling.Ignore)> Public Property Uv As Integer

        <JsonProperty("co2", NullValueHandling:=NullValueHandling.Ignore)> Public Property Co2 As Integer

        <JsonProperty("pm25_24h", NullValueHandling:=NullValueHandling.Ignore)> Public Property Pm2524Hr As Double?

        <JsonProperty("pm25", NullValueHandling:=NullValueHandling.Ignore)> Public Property Pm25 As Integer

        <JsonProperty("pm25_in_24h", NullValueHandling:=NullValueHandling.Ignore)> Public Property Pm25In24Hr As Double?

        <JsonProperty("pm25_in", NullValueHandling:=NullValueHandling.Ignore)> Public Property Pm25In As Integer

        <JsonProperty("baromrelin", NullValueHandling:=NullValueHandling.Ignore)> Public Property BaromRelIn As Double?

        <JsonProperty("baromabsin", NullValueHandling:=NullValueHandling.Ignore)> Public Property BaromAbsIn As Double?

        <JsonProperty("tempinf", NullValueHandling:=NullValueHandling.Ignore)> Public Property TempInF As Double?

        <JsonProperty("humidityin", NullValueHandling:=NullValueHandling.Ignore)> Public Property HumidityIn As Double?

        <JsonProperty("hourlyrainin", NullValueHandling:=NullValueHandling.Ignore)> Public Property HourlyRainIn As Double?

        <JsonProperty("dailyrainin", NullValueHandling:=NullValueHandling.Ignore)> Public Property DailyRainIn As Double?

        <JsonProperty("monthlyrainin", NullValueHandling:=NullValueHandling.Ignore)> Public Property MonthlyRainIn As Double?

        <JsonProperty("yearlyrainin", NullValueHandling:=NullValueHandling.Ignore)> Public Property YearlyRainIn As Double?

        <JsonProperty("eventrainin", NullValueHandling:=NullValueHandling.Ignore)> Public Property EventRainIn As Double?

        <JsonProperty("totalrainin", NullValueHandling:=NullValueHandling.Ignore)> Public Property TotalRainIn As Double?

        <JsonProperty("battin", NullValueHandling:=NullValueHandling.Ignore)> Public Property BattIn As Integer

        <JsonProperty("battout", NullValueHandling:=NullValueHandling.Ignore)> Public Property BattOut As Integer

        <JsonProperty("feelsLike", NullValueHandling:=NullValueHandling.Ignore)> Public Property FeelsLike As Double?

        <JsonProperty("feelsLikein", NullValueHandling:=NullValueHandling.Ignore)> Public Property FeelsLikeIn As Double?

        <JsonProperty("dewPoint", NullValueHandling:=NullValueHandling.Ignore)> Public Property DewPoint As Double?

        <JsonProperty("dewPointin", NullValueHandling:=NullValueHandling.Ignore)> Public Property DewPointIn As Double?

        <JsonProperty("lastRain", NullValueHandling:=NullValueHandling.Ignore)> Public Property LastRain As DateTimeOffset

        <JsonProperty("tz", NullValueHandling:=NullValueHandling.Ignore)> Public Property Tz As String

        <JsonProperty("dateZ", NullValueHandling:=NullValueHandling.Ignore)> Public Property DateZ As DateTimeOffset

        <JsonProperty("date", NullValueHandling:=NullValueHandling.Ignore)> Public Property FDate As DateTimeOffset

        <JsonProperty("deviceId", NullValueHandling:=NullValueHandling.Ignore)> Public Property DeviceId As String
    End Class

    Partial Public Class Info
        <JsonProperty("name", NullValueHandling:=NullValueHandling.Ignore)> Public Property Name As String

        <JsonProperty("location", NullValueHandling:=NullValueHandling.Ignore)> Public Property Location As String

        <JsonProperty("coords", NullValueHandling:=NullValueHandling.Ignore)> Public Property Coords As InfoCoords
    End Class

    Partial Public Class InfoCoords
        <JsonProperty("coords", NullValueHandling:=NullValueHandling.Ignore)> Public Property Coords As CoordsCoords

        <JsonProperty("address", NullValueHandling:=NullValueHandling.Ignore)> Public Property Address As String

        <JsonProperty("location", NullValueHandling:=NullValueHandling.Ignore)> Public Property Location As String

        <JsonProperty("elevation", NullValueHandling:=NullValueHandling.Ignore)> Public Property Elevation As Double?

        <JsonProperty("geo", NullValueHandling:=NullValueHandling.Ignore)> Public Property Geo As Geo
    End Class

    Partial Public Class CoordsCoords
        <JsonProperty("lat", NullValueHandling:=NullValueHandling.Ignore)> Public Property Lat As Double?

        <JsonProperty("lon", NullValueHandling:=NullValueHandling.Ignore)> Public Property Lon As Double?
    End Class

    Partial Public Class Geo
        <JsonProperty("type", NullValueHandling:=NullValueHandling.Ignore)> Public Property Type As String

        <JsonProperty("coordinates", NullValueHandling:=NullValueHandling.Ignore)> Public Property Coordinates() As Double()
    End Class

    Partial Public Class WxData

        Friend Shared Function FromJson(json As String) As WxData()
            Return JsonConvert.DeserializeObject(Of WxData())(json, Settings)
        End Function

    End Class

    Module Serialize

        <Extension> Function ToJson(self() As WxData) As String
            Return JsonConvert.SerializeObject(self, Settings)
        End Function

    End Module

    Friend Module Converter

        Public ReadOnly Settings As New JsonSerializerSettings With {
            .MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            .DateParseHandling = DateParseHandling.None,
            .Converters = {New IsoDateTimeConverter With {.DateTimeStyles = DateTimeStyles.AssumeUniversal}}
            }

    End Module

End Namespace