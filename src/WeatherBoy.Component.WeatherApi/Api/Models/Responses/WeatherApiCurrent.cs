using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiCurrent
{
    public WeatherApiCurrent(
        int lastUpdatedEpoch,
        string lastUpdated,
        double tempC,
        double tempF,
        int isDay,
        WeatherApiCondition condition,
        double windMph,
        double windKph,
        int windDegree,
        string windDir,
        double pressureMb,
        double pressureIn,
        double precipMm,
        double precipIn,
        int humidity,
        int cloud,
        double feelslikeC,
        double feelslikeF,
        double visKm,
        double visMiles,
        double uv,
        double gustMph,
        double gustKph,
        WeatherApiAirQuality? airQuality)
    {
        LastUpdatedEpoch = lastUpdatedEpoch;
        LastUpdated = lastUpdated;
        TempC = tempC;
        TempF = tempF;
        IsDay = isDay;
        Condition = condition;
        WindMph = windMph;
        WindKph = windKph;
        WindDegree = windDegree;
        WindDir = windDir;
        PressureMb = pressureMb;
        PressureIn = pressureIn;
        PrecipMm = precipMm;
        PrecipIn = precipIn;
        Humidity = humidity;
        Cloud = cloud;
        FeelslikeC = feelslikeC;
        FeelslikeF = feelslikeF;
        VisKm = visKm;
        VisMiles = visMiles;
        Uv = uv;
        GustMph = gustMph;
        GustKph = gustKph;
        AirQuality = airQuality;
    }

    [JsonPropertyName("last_updated_epoch")]
    public int LastUpdatedEpoch { get; set; }

    [JsonPropertyName("last_updated")]
    public string LastUpdated { get; set; }

    [JsonPropertyName("temp_c")]
    public double TempC { get; set; }

    [JsonPropertyName("temp_f")]
    public double TempF { get; set; }

    [JsonPropertyName("is_day")]
    public int IsDay { get; set; }

    [JsonPropertyName("condition")]
    public WeatherApiCondition Condition { get; set; }

    [JsonPropertyName("wind_mph")]
    public double WindMph { get; set; }

    [JsonPropertyName("wind_kph")]
    public double WindKph { get; set; }

    [JsonPropertyName("wind_degree")]
    public int WindDegree { get; set; }

    [JsonPropertyName("wind_dir")]
    public string WindDir { get; set; }

    [JsonPropertyName("pressure_mb")]
    public double PressureMb { get; set; }

    [JsonPropertyName("pressure_in")]
    public double PressureIn { get; set; }

    [JsonPropertyName("precip_mm")]
    public double PrecipMm { get; set; }

    [JsonPropertyName("precip_in")]
    public double PrecipIn { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    [JsonPropertyName("cloud")]
    public int Cloud { get; set; }

    [JsonPropertyName("feelslike_c")]
    public double FeelslikeC { get; set; }

    [JsonPropertyName("feelslike_f")]
    public double FeelslikeF { get; set; }

    [JsonPropertyName("vis_km")]
    public double VisKm { get; set; }

    [JsonPropertyName("vis_miles")]
    public double VisMiles { get; set; }

    [JsonPropertyName("uv")]
    public double Uv { get; set; }

    [JsonPropertyName("gust_mph")]
    public double GustMph { get; set; }

    [JsonPropertyName("gust_kph")]
    public double GustKph { get; set; }

    [JsonPropertyName("air_quality")]
    public WeatherApiAirQuality? AirQuality { get; set; }
}