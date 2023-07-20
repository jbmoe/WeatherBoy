namespace WeatherBoy.Component.WeatherApi.Configuration;

public class WeatherApiSettings
{
    public const string Section = "WeatherApiSettings";
    public string ApiKey { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;
}