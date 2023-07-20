using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiAstro
{
    public WeatherApiAstro(
        string sunrise,
        string sunset,
        string moonrise,
        string moonset,
        string moonPhase,
        string moonIllumination)
    {
        Sunrise = sunrise;
        Sunset = sunset;
        Moonrise = moonrise;
        Moonset = moonset;
        MoonPhase = moonPhase;
        MoonIllumination = moonIllumination;
    }

    [JsonPropertyName("sunrise")]
    public string Sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public string Sunset { get; set; }

    [JsonPropertyName("moonrise")]
    public string Moonrise { get; set; }

    [JsonPropertyName("moonset")]
    public string Moonset { get; set; }

    [JsonPropertyName("moon_phase")]
    public string MoonPhase { get; set; }

    [JsonPropertyName("moon_illumination")]
    public string MoonIllumination { get; set; }
}