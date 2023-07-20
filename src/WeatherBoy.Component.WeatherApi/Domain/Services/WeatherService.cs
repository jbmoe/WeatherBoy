using Mapito.Api.Services;
using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.Component.WeatherApi.Api.Services;
using WeatherBoy.Component.WeatherApi.Domain.Models.Requests;
using WeatherBoy.DataContract.Weather.Api.Models;

namespace WeatherBoy.Component.WeatherApi.Domain.Services;

public class WeatherService : IWeatherService
{
    private readonly IMediator _mediator;
    private readonly IMapito _mapito;

    public WeatherService(IMediator mediator, IMapito mapito)
    {
        _mediator = mediator;
        _mapito = mapito;
    }

    public async Task<CurrentWeather> GetCurrentWeather(
        decimal latitude,
        decimal longitude,
        bool includeAirQualityData)
    {
        var weather = await _mediator.Send(new FetchCurrentWeatherQuery(latitude, longitude, includeAirQualityData));

        var result = await _mapito.Map<WeatherApiCurrentWeatherResponseModel, CurrentWeather>(weather);

        return result;
    }

    public async Task<WeatherForecast> GetWeatherForecast(
        decimal latitude,
        decimal longitude,
        int days,
        bool includeAirQualityData,
        bool includeWeatherAlert)
    {
        var forecast = await _mediator.Send(new FetchWeatherForecastQuery(latitude, longitude, days, includeAirQualityData, includeWeatherAlert));

        var result = await _mapito.Map<WeatherApiWeatherForecastResponseModel, WeatherForecast>(forecast);

        return result;
    }

    public async Task<WeatherApiHistoricWeatherResponseModel> GetHistoricWeather(decimal latitude, decimal longitude, DateOnly date)
    {
        return await _mediator.Send(new FetchHistoricWeatherQuery(latitude, longitude, date));
    }

    public async Task<WeatherApiAstronomyResponseModel> GetAstronomy(decimal latitude, decimal longitude, DateOnly date)
    {
        return await _mediator.Send(new FetchAstronomyQuery(latitude, longitude, date));
    }
}