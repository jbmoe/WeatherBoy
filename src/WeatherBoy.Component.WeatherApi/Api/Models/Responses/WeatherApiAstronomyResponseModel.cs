using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiAstronomyResponseModel
{
    public WeatherApiAstronomyResponseModel(WeatherApiLocation location, WeatherApiAstronomy weatherApiAstronomy)
    {
        Location = location;
        WeatherApiAstronomy = weatherApiAstronomy;
    }

    [JsonPropertyName("location")]
    public WeatherApiLocation Location { get; set; }

    [JsonPropertyName("astronomy")]
    public WeatherApiAstronomy WeatherApiAstronomy { get; set; }
}