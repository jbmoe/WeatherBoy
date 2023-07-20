using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiAirQuality
{
    public WeatherApiAirQuality(double co, double no2, double o3, double so2, double pm25, double pm10, int usEpaIndex, int gbDefraIndex)
    {
        Co = co;
        No2 = no2;
        O3 = o3;
        So2 = so2;
        Pm25 = pm25;
        Pm10 = pm10;
        UsEpaIndex = usEpaIndex;
        GbDefraIndex = gbDefraIndex;
    }

    [JsonPropertyName("co")]
    public double Co { get; set; }

    [JsonPropertyName("no2")]
    public double No2 { get; set; }

    [JsonPropertyName("o3")]
    public double O3 { get; set; }

    [JsonPropertyName("so2")]
    public double So2 { get; set; }

    [JsonPropertyName("pm2_5")]
    public double Pm25 { get; set; }

    [JsonPropertyName("pm10")]
    public double Pm10 { get; set; }

    [JsonPropertyName("us-epa-index")]
    public int UsEpaIndex { get; set; }

    [JsonPropertyName("gb-defra-index")]
    public int GbDefraIndex { get; set; }
}