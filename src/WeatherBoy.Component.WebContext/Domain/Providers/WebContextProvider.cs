using WeatherBoy.Component.WebContext.Api.Providers;

namespace WeatherBoy.Component.WebContext.Domain.Providers;

public class WebContextProvider : IWebContextProvider
{
    public string Locale { get; set; } = "en-US";
}