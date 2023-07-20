namespace WeatherBoy.DataContract.Weather.Api.Models;

public class WeatherForecastHour
{
    public WeatherForecastHour(DateTime time, double tempCelsius, bool isDayTime, WeatherCondition condition, double windSpeedKph, double windGustKph, double windDirectionDegree, double pressureMb, double precipitationMm, double humidity, double feelsLikeCelsius, double heatIndexCelsius, double dewPointCelsius, bool itWillRain, int chanceOfRain, bool itWillSnow, int chanceOfSnow, double visibilityKm, double uv)
    {
        Time = time;
        TempCelsius = tempCelsius;
        IsDayTime = isDayTime;
        Condition = condition;
        WindSpeedKph = windSpeedKph;
        WindGustKph = windGustKph;
        WindDirectionDegree = windDirectionDegree;
        PressureMb = pressureMb;
        PrecipitationMm = precipitationMm;
        Humidity = humidity;
        FeelsLikeCelsius = feelsLikeCelsius;
        HeatIndexCelsius = heatIndexCelsius;
        DewPointCelsius = dewPointCelsius;
        ItWillRain = itWillRain;
        ChanceOfRain = chanceOfRain;
        ItWillSnow = itWillSnow;
        ChanceOfSnow = chanceOfSnow;
        VisibilityKm = visibilityKm;
        UV = uv;
    }

    public DateTime Time { get; set; }
    public double TempCelsius { get; set; }
    public bool IsDayTime { get; set; }
    public WeatherCondition Condition { get; set; }
    public double WindSpeedKph { get; set; }
    public double WindGustKph { get; set; }
    public double WindDirectionDegree { get; set; }
    public double PressureMb { get; set; }
    public double PrecipitationMm { get; set; }
    public double Humidity { get; set; }
    public double FeelsLikeCelsius { get; set; }
    public double HeatIndexCelsius { get; set; }
    public double DewPointCelsius { get; set; }
    public bool ItWillRain { get; set; }
    public int ChanceOfRain { get; set; }
    public bool ItWillSnow { get; set; }
    public int ChanceOfSnow { get; set; }
    public double VisibilityKm { get; set; }
    public double UV { get; set; }
}