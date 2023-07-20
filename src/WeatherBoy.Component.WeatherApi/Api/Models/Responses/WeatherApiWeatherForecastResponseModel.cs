using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiWeatherForecastResponseModel
{
    public WeatherApiWeatherForecastResponseModel(
        WeatherApiLocation location,
        WeatherApiCurrent current,
        WeatherApiForecast forecast,
        WeatherApiAlerts? alerts)
    {
        Location = location;
        Current = current;
        Forecast = forecast;
        Alerts = alerts;
    }

    [JsonPropertyName("location")]
    public WeatherApiLocation Location { get; set; }

    [JsonPropertyName("current")]
    public WeatherApiCurrent Current { get; set; }

    [JsonPropertyName("forecast")]
    public WeatherApiForecast Forecast { get; set; }

    [JsonPropertyName("alerts")]
    public WeatherApiAlerts? Alerts { get; set; }
}