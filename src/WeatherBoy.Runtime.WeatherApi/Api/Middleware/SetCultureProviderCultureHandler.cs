using System.Globalization;
using System.Text.RegularExpressions;
using WeatherBoy.Component.WeatherApi.Api.Providers;

namespace WeatherBoy.Runtime.WeatherApi.Api.Middleware;

public class SetCultureProviderCultureHandler
{
    private readonly RequestDelegate _next;

    public SetCultureProviderCultureHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ICultureProvider cultureProvider)
    {
        // Select the first locale in the Accept-Language header
        if (context.Request.Headers.TryGetValue("Accept-Language", out var headerAcceptLanguage))
        {
            // Parse the value to tokens: 'en-US,en;q=0.7,da;q=0.3' -> 'en-US', 'en', 'da'
            var values = headerAcceptLanguage.FirstOrDefault()?.Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(";", StringSplitOptions.RemoveEmptyEntries).FirstOrDefault())
                .Where(x => x != null)
                .ToList() ?? new List<string?>();

            // Extract locales, eg. en-US, da-DK
            var locale = values.FirstOrDefault(x => x != null && Regex.IsMatch(x, "^[A-Za-z]{2}-[A-Za-z]{2}$"));

            if (!string.IsNullOrWhiteSpace(locale))
            {
                // Set web context to use first locale
                cultureProvider.Culture = CultureInfo.GetCultureInfo(locale);
            }
        }

        await _next(context);
    }
}