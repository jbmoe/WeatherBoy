using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Exceptions;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.Component.WeatherApi.Api.Services;
using WeatherBoy.Component.WeatherApi.Domain.Models.ErrorResponses;
using WeatherBoy.Component.WeatherApi.Domain.Models.Exceptions;
using WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

namespace WeatherBoy.Component.WeatherApi.Domain.RequestHandlers;

public class FetchCurrentWeatherRequestHandler : IRequestHandler<FetchCurrentWeatherQuery, WeatherApiCurrentWeatherResponseModel>
{
    private readonly IWeatherApiClient _weatherApiClient;

    public FetchCurrentWeatherRequestHandler(IWeatherApiClient weatherApiClient)
    {
        _weatherApiClient = weatherApiClient;
    }

    public async Task<WeatherApiCurrentWeatherResponseModel> Handle(FetchCurrentWeatherQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new Dictionary<string, string>
            {
                ["q"] = $"{query.Latitude},{query.Longitude}",
                ["aqi"] = query.IncludeAirQualityData ? "yes" : "no",
            };

            return await _weatherApiClient.FetchWeatherApiData<WeatherApiCurrentWeatherResponseModel>("current", parameters);
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