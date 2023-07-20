namespace WeatherBoy.DataContract.Weather.Api.Models;

public class CurrentWeather
{
    public CurrentWeather(Weather current, Location location)
    {
        Current = current;
        Location = location;
    }

    public Location Location { get; set; }
    public Weather Current { get; set; }
}