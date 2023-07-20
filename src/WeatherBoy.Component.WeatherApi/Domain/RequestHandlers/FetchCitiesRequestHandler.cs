using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.Component.WeatherApi.Api.Services;
using WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

namespace WeatherBoy.Component.WeatherApi.Domain.RequestHandlers;

public class FetchCitiesRequestHandler : IRequestHandler<FetchCitiesQuery, List<WeatherApiCity>>
{
    private readonly IWeatherApiClient _weatherApiClient;

    public FetchCitiesRequestHandler(IWeatherApiClient weatherApiClient)
    {
        _weatherApiClient = weatherApiClient;
    }

    public Task<List<WeatherApiCity>> Handle(FetchCitiesQuery query, CancellationToken cancellationToken)
    {
        var parameters = new Dictionary<string, string>
        {
            ["q"] = query.CityName,
        };

        return _weatherApiClient.FetchWeatherApiData<List<WeatherApiCity>>("search", parameters);
    }
}