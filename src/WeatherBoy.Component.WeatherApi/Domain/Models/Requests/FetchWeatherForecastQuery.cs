using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;

namespace WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

public class FetchWeatherForecastQuery : IRequest<WeatherApiWeatherForecastResponseModel>
{
    public FetchWeatherForecastQuery(decimal latitude, decimal longitude, int days, bool includeAirQuality, bool includeWeatherAlert)
    {
        Latitude = latitude;
        Longitude = longitude;
        Days = days;
        IncludeAirQuality = includeAirQuality;
        IncludeWeatherAlert = includeWeatherAlert;
    }

    public decimal Latitude { get; }
    public decimal Longitude { get; }
    public int Days { get; }
    public bool IncludeAirQuality { get; }
    public bool IncludeWeatherAlert { get; }
}