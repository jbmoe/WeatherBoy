namespace WeatherBoy.Component.WeatherApi.Api.Services;

public interface IWeatherApiClient
{
    Task<TOutput> FetchWeatherApiData<TOutput>(string type, Dictionary<string, string> parameters);
}