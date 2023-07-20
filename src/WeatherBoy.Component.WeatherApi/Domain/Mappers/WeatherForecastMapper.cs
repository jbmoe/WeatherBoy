using Mapito.Api.Mappers;
using Mapito.Api.Services;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.DataContract.Weather.Api.Models;

namespace WeatherBoy.Component.WeatherApi.Domain.Mappers;

public class WeatherForecastMapper : IMapper<WeatherApiWeatherForecastResponseModel, WeatherForecast>
{
    private readonly IMapito _mapito;

    public WeatherForecastMapper(IMapito mapito)
    {
        _mapito = mapito;
    }

    public async Task<WeatherForecast> Map(WeatherApiWeatherForecastResponseModel source)
    {
        var location = _mapito.Map<WeatherApiLocation, Location>(source.Location);
        var currentWeather = _mapito.Map<WeatherApiCurrent, Weather>(source.Current);
        var forecastDays = _mapito.Map<WeatherApiForecast.WeatherApiForecastday, WeatherForecastDay>(source.Forecast.Forecastday);

        await Task.WhenAll(location, currentWeather, forecastDays);

        var forecast = new WeatherForecast(location.Result, currentWeather.Result, forecastDays.Result.ToList());

        return forecast;
    }
}