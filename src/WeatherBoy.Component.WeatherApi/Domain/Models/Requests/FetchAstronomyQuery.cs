using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;

namespace WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

public class FetchAstronomyQuery : IRequest<WeatherApiAstronomyResponseModel>
{
    public FetchAstronomyQuery(decimal latitude, decimal longitude, DateOnly date)
    {
        Latitude = latitude;
        Longitude = longitude;
        Date = date;
    }

    public decimal Latitude { get; }
    public decimal Longitude { get; }
    public DateOnly Date { get; }
}