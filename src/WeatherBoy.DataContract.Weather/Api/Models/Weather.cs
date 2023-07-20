namespace WeatherBoy.DataContract.Weather.Api.Models;

public class Weather
{
    public Weather(DateTime lastUpdated, double tempCelsius, bool isDayTime, WeatherCondition condition, double windSpeedKph, double windGustKph, double windDirectionDegree, double precipitationMm, double pressureMb, double humidity, double feelsLikeCelsius, double visibilityKm, double uv)
    {
        LastUpdated = lastUpdated;
        TempCelsius = tempCelsius;
        IsDayTime = isDayTime;
        Condition = condition;
        WindSpeedKph = windSpeedKph;
        WindGustKph = windGustKph;
        WindDirectionDegree = windDirectionDegree;
        PrecipitationMm = precipitationMm;
        PressureMb = pressureMb;
        Humidity = humidity;
        FeelsLikeCelsius = feelsLikeCelsius;
        VisibilityKm = visibilityKm;
        Uv = uv;
    }

    public DateTime LastUpdated { get; set; }
    public double TempCelsius { get; set; }
    public bool IsDayTime { get; set; }
    public WeatherCondition Condition { get; set; }
    public double WindSpeedKph { get; set; }
    public double WindGustKph { get; set; }
    public double WindDirectionDegree { get; set; }
    public double PrecipitationMm { get; set; }
    public double PressureMb { get; set; }
    public double Humidity { get; set; }
    public double FeelsLikeCelsius { get; set; }
    public double VisibilityKm { get; set; }
    public double Uv { get; set; }
}