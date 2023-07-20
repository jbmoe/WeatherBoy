using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.Component.WeatherApi.Api.Services;
using WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

namespace WeatherBoy.Component.WeatherApi.Domain.RequestHandlers;

public class FetchIpInformationRequestHandler : IRequestHandler<FetchIpInformationQuery, WeatherApiIpInformation>
{
    private readonly IWeatherApiClient _weatherApiClient;

    public FetchIpInformationRequestHandler(IWeatherApiClient weatherApiClient)
    {
        _weatherApiClient = weatherApiClient;
    }

    public Task<WeatherApiIpInformation> Handle(FetchIpInformationQuery query, CancellationToken cancellationToken)
    {
        var parameters = new Dictionary<string, string>
        {
            ["q"] = query.IpAddress,
        };

        return _weatherApiClient.FetchWeatherApiData<WeatherApiIpInformation>("ip", parameters);
    }
}