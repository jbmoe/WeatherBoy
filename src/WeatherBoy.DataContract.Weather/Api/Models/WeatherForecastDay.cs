namespace WeatherBoy.DataContract.Weather.Api.Models;

public class WeatherForecastDay
{
    public WeatherForecastDay(DateOnly date, double maxTempCelsius, double minTempCelsius, double avgTempCelsius, double maxWindSpeedKph, double totalPrecipitationMm, double avgVisibilityKm, double avgHumidity, bool itWillRain, int chanceOfRain, bool itWillSnow, int chanceOfSnow, WeatherCondition condition, double uv, TimeOnly sunrise, TimeOnly sunset, List<WeatherForecastHour> hours)
    {
        Date = date;
        MaxTempCelsius = maxTempCelsius;
        MinTempCelsius = minTempCelsius;
        AvgTempCelsius = avgTempCelsius;
        MaxWindSpeedKph = maxWindSpeedKph;
        TotalPrecipitationMm = totalPrecipitationMm;
        AvgVisibilityKm = avgVisibilityKm;
        AvgHumidity = avgHumidity;
        ItWillRain = itWillRain;
        ChanceOfRain = chanceOfRain;
        ItWillSnow = itWillSnow;
        ChanceOfSnow = chanceOfSnow;
        Condition = condition;
        Uv = uv;
        Sunrise = sunrise;
        Sunset = sunset;
        Hours = hours;
    }

    public DateOnly Date { get; set; }
    public double MaxTempCelsius { get; set; }
    public double MinTempCelsius { get; set; }
    public double AvgTempCelsius { get; set; }
    public double MaxWindSpeedKph { get; set; }
    public double TotalPrecipitationMm { get; set; }
    public double AvgVisibilityKm { get; set; }
    public double AvgHumidity { get; set; }
    public bool ItWillRain { get; set; }
    public int ChanceOfRain { get; set; }
    public bool ItWillSnow { get; set; }
    public int ChanceOfSnow { get; set; }
    public WeatherCondition Condition { get; set; }
    public double Uv { get; set; }
    public TimeOnly Sunrise { get; set; }
    public TimeOnly Sunset { get; set; }
    public List<WeatherForecastHour> Hours { get; set; }
}