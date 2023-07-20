using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiAlerts
{
    public WeatherApiAlerts(List<object> alert)
    {
        Alert = alert;
    }

    [JsonPropertyName("alert")]
    public List<object> Alert { get; set; }
}