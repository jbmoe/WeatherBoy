using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.Component.WeatherApi.Api.Services;
using WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

namespace WeatherBoy.Component.WeatherApi.Domain.Services;

public class SearchService : ISearchService
{
    private readonly IMediator _mediator;

    public SearchService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<List<WeatherApiCity>> GetCities(string cityName)
    {
        return _mediator.Send(new FetchCitiesQuery(cityName));
    }

    public Task<WeatherApiIpInformation> GetIpInformation(string ipAddress)
    {
        return _mediator.Send(new FetchIpInformationQuery(ipAddress));
    }
}