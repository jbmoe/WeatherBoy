using System.Web;
using WeatherBoy.Component.WeatherApi.Api.Providers;

namespace WeatherBoy.Component.WeatherApi.Domain.Middlewares;

public class WeatherApiLanguageMiddleware : DelegatingHandler
{
    private readonly ICultureProvider _cultureProvider;

    public WeatherApiLanguageMiddleware(ICultureProvider cultureProvider)
    {
        _cultureProvider = cultureProvider;
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
        query["lang"] = _cultureProvider.Culture.TwoLetterISOLanguageName;
        uriBuilder.Query = query.ToString();
        request.RequestUri = uriBuilder.Uri;

        return base.SendAsync(request, cancellationToken);
    }
}