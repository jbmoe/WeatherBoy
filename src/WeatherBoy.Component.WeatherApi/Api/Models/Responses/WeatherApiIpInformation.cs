using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiIpInformation
{
    public WeatherApiIpInformation(
        string ip,
        string type,
        string continentCode,
        string continentName,
        string countryCode,
        string countryName,
        string isEu,
        int geonameId,
        string city,
        string region,
        double lat,
        double lon,
        string tzId,
        int localtimeEpoch,
        string localtime)
    {
        Ip = ip;
        Type = type;
        ContinentCode = continentCode;
        ContinentName = continentName;
        CountryCode = countryCode;
        CountryName = countryName;
        IsEu = isEu;
        GeonameId = geonameId;
        City = city;
        Region = region;
        Lat = lat;
        Lon = lon;
        TzId = tzId;
        LocaltimeEpoch = localtimeEpoch;
        Localtime = localtime;
    }

    [JsonPropertyName("ip")]
    public string Ip { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("continent_code")]
    public string ContinentCode { get; set; }

    [JsonPropertyName("continent_name")]
    public string ContinentName { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [JsonPropertyName("country_name")]
    public string CountryName { get; set; }

    [JsonPropertyName("is_eu")]
    public string IsEu { get; set; }

    [JsonPropertyName("geoname_id")]
    public int GeonameId { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

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