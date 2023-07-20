using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiHistoricWeatherResponseModel
{
    public WeatherApiHistoricWeatherResponseModel(WeatherApiLocation location, WeatherApiHistoric historic)
    {
        Location = location;
        Historic = historic;
    }

    [JsonPropertyName("location")]
    public WeatherApiLocation Location { get; set; }

    [JsonPropertyName("forecast")]
    public WeatherApiHistoric Historic { get; set; }
}