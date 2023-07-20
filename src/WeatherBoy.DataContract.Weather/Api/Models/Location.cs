namespace WeatherBoy.DataContract.Weather.Api.Models;

public class Location
{
    public Location(string name, string region, string country, double latitude, double longitude, DateTime localTime)
    {
        Name = name;
        Region = region;
        Country = country;
        Latitude = latitude;
        Longitude = longitude;
        LocalTime = localTime;
    }

    public string Name { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime LocalTime { get; set; }
}