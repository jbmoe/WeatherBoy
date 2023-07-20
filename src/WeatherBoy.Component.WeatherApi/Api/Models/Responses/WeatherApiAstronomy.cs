using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiAstronomy
{
    public WeatherApiAstronomy(WeatherApiAstro weatherApiAstro)
    {
        WeatherApiAstro = weatherApiAstro;
    }

    [JsonPropertyName("astro")]
    public WeatherApiAstro WeatherApiAstro { get; set; }
}