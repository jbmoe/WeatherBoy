using System.Globalization;
using WeatherBoy.Component.WeatherApi.Api.Providers;

namespace WeatherBoy.Component.WeatherApi.Domain.Providers;

public class CultureProvider : ICultureProvider
{
    public CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;
}