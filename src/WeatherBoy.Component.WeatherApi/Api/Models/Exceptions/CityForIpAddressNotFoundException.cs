namespace WeatherBoy.Component.WeatherApi.Api.Models.Exceptions;

public class CityForIpAddressNotFoundException : Exception
{
    public CityForIpAddressNotFoundException(string ipAddress)
        : base($"No city found for IP address: {ipAddress}")
    {
    }
}