namespace WeatherBoy.DataContract.Weather.Api.Models;

public class WeatherForecast
{
    public WeatherForecast(Location location, Weather currentWeather, List<WeatherForecastDay> forecastDays)
    {
        Location = location;
        CurrentWeather = currentWeather;
        ForecastDays = forecastDays;
    }

    public Location Location { get; set; }
    public Weather CurrentWeather { get; set; }
    public List<WeatherForecastDay> ForecastDays { get; set; }
}