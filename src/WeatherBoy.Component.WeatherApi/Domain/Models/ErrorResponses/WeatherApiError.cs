using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Domain.Models.ErrorResponses;

public class WeatherApiError
{
    public WeatherApiError(int code, string message)
    {
        Code = code;
        Message = message;
    }

    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }
}