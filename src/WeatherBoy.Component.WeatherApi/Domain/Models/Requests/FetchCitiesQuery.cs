using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;

namespace WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

public class FetchCitiesQuery : IRequest<List<WeatherApiCity>>
{
    public FetchCitiesQuery(string cityName)
    {
        CityName = cityName;
    }

    public string CityName { get; set; }
}