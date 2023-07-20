using System.Web;
using WeatherBoy.Component.WeatherApi.Configuration;

namespace WeatherBoy.Component.WeatherApi.Domain.Middlewares;

public class WeatherApiApiKeyMiddleware : DelegatingHandler
{
    private readonly WeatherApiSettings _weatherApiSettings;

    public WeatherApiApiKeyMiddleware(WeatherApiSettings weatherApiSettings)
    {
        _weatherApiSettings = weatherApiSettings;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.RequestUri == null)
        {
            return base.SendAsync(request, cancellationToken);
        }

        // Add the query parameter to the request URI
        var uriBuilder = new UriBuilder(request.RequestUri);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["key"] = _weatherApiSettings.ApiKey;
        uriBuilder.Query = query.ToString();
        request.RequestUri = uriBuilder.Uri;

        return base.SendAsync(request, cancellationToken);
    }
}