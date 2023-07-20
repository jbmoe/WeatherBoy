using Mapito.Api.Mappers;
using Mapito.Api.Services;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.DataContract.Weather.Api.Models;

namespace WeatherBoy.Component.WeatherApi.Domain.Mappers;

public class CurrentWeatherMapper : IMapper<WeatherApiCurrentWeatherResponseModel, CurrentWeather>
{
    private readonly IMapito _mapito;

    public CurrentWeatherMapper(IMapito mapito)
    {
        _mapito = mapito;
    }

    public async Task<CurrentWeather> Map(WeatherApiCurrentWeatherResponseModel source)
    {
        var current = _mapito.Map<WeatherApiCurrent, Weather>(source.Current);
        var location = _mapito.Map<WeatherApiLocation, Location>(source.Location);

        await Task.WhenAll(current, location);

        var currentWeather = new CurrentWeather(current.Result, location.Result);

        return currentWeather;
    }
}