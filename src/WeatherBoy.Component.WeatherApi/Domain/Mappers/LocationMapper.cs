using Mapito.Api.Mappers;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.DataContract.Weather.Api.Models;

namespace WeatherBoy.Component.WeatherApi.Domain.Mappers;

public class LocationMapper : IMapper<WeatherApiLocation, Location>
{
    public Task<Location> Map(WeatherApiLocation source)
    {
        var date = DateTime.Parse(source.Localtime);

        return Task.FromResult(new Location(
            source.Name,
            source.Region,
            source.Country,
            source.Lat,
            source.Lon,
            date));
    }
}