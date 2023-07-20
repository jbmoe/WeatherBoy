namespace WeatherBoy.DataContract.Weather.Api.Models;

public class WeatherCondition
{
    public WeatherCondition(string text, string iconUrl, int code)
    {
        Text = text;
        IconUrl = iconUrl;
        Code = code;
    }

    public string Text { get; set; }
    public string IconUrl { get; set; }
    public int Code { get; set; }
}