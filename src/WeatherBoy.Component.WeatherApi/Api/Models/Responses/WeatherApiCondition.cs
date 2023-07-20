using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiCondition
{
    public WeatherApiCondition(string text, string icon, int code)
    {
        Text = text;
        Icon = icon;
        Code = code;
    }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("code")]
    public int Code { get; set; }
}