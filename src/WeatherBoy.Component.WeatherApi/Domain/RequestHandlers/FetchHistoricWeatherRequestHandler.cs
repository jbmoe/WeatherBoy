using System.Globalization;
using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Exceptions;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.Component.WeatherApi.Api.Services;
using WeatherBoy.Component.WeatherApi.Domain.Models.ErrorResponses;
using WeatherBoy.Component.WeatherApi.Domain.Models.Exceptions;
using WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

namespace WeatherBoy.Component.WeatherApi.Domain.RequestHandlers;

public class FetchHistoricWeatherRequestHandler : IRequestHandler<FetchHistoricWeatherQuery, WeatherApiHistoricWeatherResponseModel>
{
    private readonly IWeatherApiClient _weatherApiClient;

    public FetchHistoricWeatherRequestHandler(IWeatherApiClient weatherApiClient)
    {
        _weatherApiClient = weatherApiClient;
    }

    public async Task<WeatherApiHistoricWeatherResponseModel> Handle(FetchHistoricWeatherQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new Dictionary<string, string>
            {
                ["q"] = $"{query.Latitude.ToString(CultureInfo.InvariantCulture)},{query.Longitude.ToString(CultureInfo.InvariantCulture)}",
                ["dt"] = query.Date.ToString("yyyy-MM-dd"),
            };

            return await _weatherApiClient.FetchWeatherApiData<WeatherApiHistoricWeatherResponseModel>("history", parameters);
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