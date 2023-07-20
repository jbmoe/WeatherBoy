using System.Globalization;

namespace WeatherBoy.Component.WeatherApi.Api.Providers;

public interface ICultureProvider
{
    CultureInfo Culture { get; set; }
}