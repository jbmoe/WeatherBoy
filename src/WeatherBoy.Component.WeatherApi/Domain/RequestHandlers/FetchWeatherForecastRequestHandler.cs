using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Exceptions;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.Component.WeatherApi.Api.Services;
using WeatherBoy.Component.WeatherApi.Domain.Models.ErrorResponses;
using WeatherBoy.Component.WeatherApi.Domain.Models.Exceptions;
using WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

namespace WeatherBoy.Component.WeatherApi.Domain.RequestHandlers;

public class FetchWeatherForecastRequestHandler : IRequestHandler<FetchWeatherForecastQuery, WeatherApiWeatherForecastResponseModel>
{
    private readonly IWeatherApiClient _weatherApiClient;

    public FetchWeatherForecastRequestHandler(IWeatherApiClient weatherApiClient)
    {
        _weatherApiClient = weatherApiClient;
    }

    public async Task<WeatherApiWeatherForecastResponseModel> Handle(FetchWeatherForecastQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new Dictionary<string, string>
            {
                ["q"] = $"{query.Latitude},{query.Longitude}",
                ["days"] = query.Days.ToString(),
                ["aqi"] = query.IncludeAirQuality ? "yes" : "no",
                ["alerts"] = query.IncludeWeatherAlert ? "yes" : "no",
            };

            return await _weatherApiClient.FetchWeatherApiData<WeatherApiWeatherForecastResponseModel>("forecast", parameters);
        }
        catch (WeatherApiException e) when (e is WeatherApiExceptionResult<WeatherApiErrorResponse> ex)
        {
            throw ex.Result?.Error.Code switch
            {
                1006 => WeatherForCityNotFoundException.ForCoordinates(query.Latitude, query.Longitude),
                _ => ex,
            };
        }
    }
}