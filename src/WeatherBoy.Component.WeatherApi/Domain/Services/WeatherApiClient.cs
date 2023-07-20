using System.Text.Json;
using WeatherBoy.Component.WeatherApi.Api.Services;
using WeatherBoy.Component.WeatherApi.Domain.Models.ErrorResponses;
using WeatherBoy.Component.WeatherApi.Domain.Models.Exceptions;

namespace WeatherBoy.Component.WeatherApi.Domain.Services;

public class WeatherApiClient : IWeatherApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherApiClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<TOutput> FetchWeatherApiData<TOutput>(string type, Dictionary<string, string> parameters)
    {
        var parametersString = string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));

        var client = _httpClientFactory.CreateClient("WeatherApi.HttpClient");
        var response = await client.GetAsync($"/v1/{type}.json?{parametersString}");
        var responseText = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var entities = JsonSerializer.Deserialize<TOutput>(responseText);
            return entities == null
                ? throw new WeatherApiException(
                    "Response was null which was not expected.",
                    (int)response.StatusCode,
                    responseText)
                : entities;
        }

        var error = JsonSerializer.Deserialize<WeatherApiErrorResponse>(responseText);

        throw new WeatherApiExceptionResult<WeatherApiErrorResponse>(
            "An error occurred.",
            (int)response.StatusCode,
            responseText,
            error);
    }
}