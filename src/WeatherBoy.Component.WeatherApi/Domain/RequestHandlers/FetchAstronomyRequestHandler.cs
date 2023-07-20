using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Exceptions;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.Component.WeatherApi.Api.Services;
using WeatherBoy.Component.WeatherApi.Domain.Models.ErrorResponses;
using WeatherBoy.Component.WeatherApi.Domain.Models.Exceptions;
using WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

namespace WeatherBoy.Component.WeatherApi.Domain.RequestHandlers;

public class FetchAstronomyRequestHandler : IRequestHandler<FetchAstronomyQuery, WeatherApiAstronomyResponseModel>
{
    private readonly IWeatherApiClient _weatherApiClient;

    public FetchAstronomyRequestHandler(IWeatherApiClient weatherApiClient)
    {
        _weatherApiClient = weatherApiClient;
    }

    public async Task<WeatherApiAstronomyResponseModel> Handle(FetchAstronomyQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new Dictionary<string, string>
            {
                ["q"] = $"{query.Latitude},{query.Longitude}",
                ["dt"] = query.Date.ToString("yyyy-MM-dd"),
            };

            return await _weatherApiClient.FetchWeatherApiData<WeatherApiAstronomyResponseModel>("astronomy", parameters);
        }
        catch (WeatherApiException e) when (e is WeatherApiExceptionResult<WeatherApiErrorResponse> ex)
        {
            throw ex.Result?.Error.Code switch
            {
                1006 => WeatherForCityNotFoundException.ForCoordinates(query.Latitude, query.Longitude),
                1008 => DateOutOfRangeException.ForDate(query.Date),
                _ => ex,
            };
        }
    }
}