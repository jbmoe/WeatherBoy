using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiLocation
{
    public WeatherApiLocation(string name, string region, string country, double lat, double lon, string tzId, int localtimeEpoch, string localtime)
    {
        Name = name;
        Region = region;
        Country = country;
        Lat = lat;
        Lon = lon;
        TzId = tzId;
        LocaltimeEpoch = localtimeEpoch;
        Localtime = localtime;
    }

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

    [JsonPropertyName("tz_id")]
    public string TzId { get; set; }

    [JsonPropertyName("localtime_epoch")]
    public int LocaltimeEpoch { get; set; }

    [JsonPropertyName("localtime")]
    public string Localtime { get; set; }
}