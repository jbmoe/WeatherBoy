using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WeatherBoy.Component.WebContext.Api.Providers;
using WeatherBoy.Component.WebContext.Domain.Providers;

namespace WeatherBoy.Component.WebContext.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebContext(this IServiceCollection services)
    {
        services.Add(_providers.Values);

        return services;
    }

    #region Providers

    internal enum Providers
    {
        WebContextProvider,
    }

    private static readonly Dictionary<Providers, ServiceDescriptor> _providers = new()
    {
        [Providers.WebContextProvider] = ServiceDescriptor.Scoped<IWebContextProvider, WebContextProvider>(),
    };

    #endregion Providers
}