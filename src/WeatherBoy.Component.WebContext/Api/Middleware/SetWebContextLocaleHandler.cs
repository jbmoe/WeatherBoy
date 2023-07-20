using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using WeatherBoy.Component.WebContext.Api.Providers;

namespace WeatherBoy.Component.WebContext.Api.Middleware;

public class SetWebContextLocaleHandler
{
    private readonly RequestDelegate _next;

    public SetWebContextLocaleHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IWebContextProvider webContextProvider)
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
            var locales = values
                .Where(x => x != null && Regex.IsMatch(x, "^[A-Za-z]{2}-[A-Za-z]{2}$"))
                .ToList();
            if (locales.Any())
            {
                // Set web context to use first locale
                webContextProvider.Locale = locales.First()!;
            }
        }

        await _next(context);
    }
}