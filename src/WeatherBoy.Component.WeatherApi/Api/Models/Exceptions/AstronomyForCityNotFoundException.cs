namespace WeatherBoy.Component.WeatherApi.Api.Models.Exceptions;

public class AstronomyForCityNotFoundException : Exception
{
    public AstronomyForCityNotFoundException(string message)
        : base(message)
    {
    }

    public static AstronomyForCityNotFoundException ForCity(string cityName)
    {
        return new AstronomyForCityNotFoundException($"No astronomy data found for city with name {cityName}");
    }
}