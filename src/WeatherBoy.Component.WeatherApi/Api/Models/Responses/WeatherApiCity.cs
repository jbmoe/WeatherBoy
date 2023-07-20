using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiCity
{
    public WeatherApiCity(int id, string name, string region, string country, double lat, double lon, string url)
    {
        Id = id;
        Name = name;
        Region = region;
        Country = country;
        Lat = lat;
        Lon = lon;
        Url = url;
    }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}