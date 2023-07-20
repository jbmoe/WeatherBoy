namespace WeatherBoy.Component.WeatherApi.Api.Models.Exceptions;

public class WeatherForCityNotFoundException : Exception
{
    public WeatherForCityNotFoundException(string message)
        : base(message)
    {
    }

    public static WeatherForCityNotFoundException ForCity(string cityName)
    {
        return new WeatherForCityNotFoundException($"No weather data found for city with name {cityName}");
    }

    public static WeatherForCityNotFoundException ForCoordinates(decimal latitude, decimal longitude)
    {
        return new WeatherForCityNotFoundException($"No weather data found for coordinates {latitude},{longitude}");
    }
}