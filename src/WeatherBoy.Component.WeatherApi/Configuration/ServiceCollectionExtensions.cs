using Mapito.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.Component.WeatherApi.Api.Providers;
using WeatherBoy.Component.WeatherApi.Api.Services;
using WeatherBoy.Component.WeatherApi.Domain.Mappers;
using WeatherBoy.Component.WeatherApi.Domain.Middlewares;
using WeatherBoy.Component.WeatherApi.Domain.Providers;
using WeatherBoy.Component.WeatherApi.Domain.RequestPreProcessors;
using WeatherBoy.Component.WeatherApi.Domain.Services;
using WeatherBoy.DataContract.Weather.Api.Models;

namespace WeatherBoy.Component.WeatherApi.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeatherApi(
        this IServiceCollection services,
        WeatherApiSettings config)
    {
        _services[Services.WeatherApiConfiguration] = ServiceDescriptor.Singleton(config);

        services.AddMapito(mapito =>
        {
            mapito
                .SetMapper<WeatherApiLocation, Location, LocationMapper>()
                .SetMapper<WeatherApiCondition, WeatherCondition, WeatherConditionMapper>()
                .SetMapper<WeatherApiForecast.WeatherApiForecastday, WeatherForecastDay, WeatherForecastDayMapper>()
                .SetMapper<WeatherApiForecast.WeatherApiForecastday.WeatherApiHour, WeatherForecastHour, WeatherForecastHourMapper>()
                .SetMapper<WeatherApiWeatherForecastResponseModel, WeatherForecast, WeatherForecastMapper>()
                .SetMapper<WeatherApiCurrent, Weather, WeatherMapper>()
                .SetMapper<WeatherApiCurrentWeatherResponseModel, CurrentWeather, CurrentWeatherMapper>();
        });

        services
            .Add(_services.Values)
            .AddMediatR(mediator =>
            {
                mediator
                    .RegisterServicesFromAssemblyContaining(typeof(ServiceCollectionExtensions))
                    .AddRequestPreProcessor<ReplaceDanoLettersPreProcessor>();
            })
            .AddHttpClient("WeatherApi.HttpClient", client =>
            {
                client.BaseAddress = new Uri(config.BaseUrl);
            })
            .AddHttpMessageHandler<WeatherApiApiKeyMiddleware>()
            .AddHttpMessageHandler<WeatherApiLanguageMiddleware>();

        return services;
    }

    #region Services

    private enum Services
    {
        WeatherApiConfiguration,
        WeatherApiClient,
        WeatherService,
        SearchService,
        WeatherApiApiKeyMiddleware,
        WeatherApiLanguageMiddleware,
        CultureProvider,
    }

    private static readonly Dictionary<Services, ServiceDescriptor> _services = new()
    {
        [Services.WeatherApiClient] = ServiceDescriptor.Scoped<IWeatherApiClient, WeatherApiClient>(),
        [Services.WeatherService] = ServiceDescriptor.Scoped<IWeatherService, WeatherService>(),
        [Services.SearchService] = ServiceDescriptor.Scoped<ISearchService, SearchService>(),
        [Services.WeatherApiApiKeyMiddleware] = ServiceDescriptor.Transient<WeatherApiApiKeyMiddleware, WeatherApiApiKeyMiddleware>(),
        [Services.WeatherApiLanguageMiddleware] = ServiceDescriptor.Transient<WeatherApiLanguageMiddleware, WeatherApiLanguageMiddleware>(),
        [Services.CultureProvider] = ServiceDescriptor.Scoped<ICultureProvider, CultureProvider>(),
    };

    #endregion
}