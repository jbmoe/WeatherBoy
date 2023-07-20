using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.DataContract.Weather.Api.Models;

namespace WeatherBoy.Component.WeatherApi.Api.Services;

public interface IWeatherService
{
    Task<CurrentWeather> GetCurrentWeather(decimal latitude, decimal longitude, bool includeAirQualityData = false);

    Task<WeatherForecast> GetWeatherForecast(decimal latitude, decimal longitude, int days, bool includeAirQualityData = false, bool includeWeatherAlert = false);

    Task<WeatherApiHistoricWeatherResponseModel> GetHistoricWeather(decimal latitude, decimal longitude, DateOnly date);

    Task<WeatherApiAstronomyResponseModel> GetAstronomy(decimal latitude, decimal longitude, DateOnly date);
}