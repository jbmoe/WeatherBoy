using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Domain.Models.ErrorResponses;

public class WeatherApiErrorResponse
{
    public WeatherApiErrorResponse(WeatherApiError error)
    {
        Error = error;
    }

    [JsonPropertyName("error")]
    public WeatherApiError Error { get; set; }
}