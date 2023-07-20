using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiCurrentWeatherResponseModel
{
    public WeatherApiCurrentWeatherResponseModel(WeatherApiLocation location, WeatherApiCurrent current)
    {
        Location = location;
        Current = current;
    }

    [JsonPropertyName("location")]
    public WeatherApiLocation Location { get; set; }

    [JsonPropertyName("current")]
    public WeatherApiCurrent Current { get; set; }
}