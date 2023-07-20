using WeatherBoy.Component.WeatherApi.Api.Models.Responses;

namespace WeatherBoy.Component.WeatherApi.Api.Services;

public interface ISearchService
{
    Task<List<WeatherApiCity>> GetCities(string cityName);
    Task<WeatherApiIpInformation> GetIpInformation(string ipAddress);
}