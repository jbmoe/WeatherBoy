using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;

namespace WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

public class FetchCurrentWeatherQuery : IRequest<WeatherApiCurrentWeatherResponseModel>
{
    public FetchCurrentWeatherQuery(decimal latitude, decimal longitude, bool includeAirQuality)
    {
        Latitude = latitude;
        Longitude = longitude;
        IncludeAirQualityData = includeAirQuality;
    }

    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public bool IncludeAirQualityData { get; set; }
}