using Microsoft.OpenApi.Models;
using WeatherBoy.Component.WeatherApi.Configuration;
using WeatherBoy.Runtime.WeatherApi.Api.Middleware;
using WeatherBoy.Runtime.WeatherApi.MinimalApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(
        "appsettings.json", // Load base settings
        false,
        true)
    .AddJsonFile(
        "appsettings.local.json", // Load local settings
        true,
        true)
    .AddEnvironmentVariables(); // Load environment variables

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(options =>
    {
        options.SwaggerDoc("weatherboy-public", new OpenApiInfo
        {
            Title = "Weather Boy Weather API",
            Version = "v1",
        });
    })
    .AddWeatherApi(builder.Configuration.GetSection(WeatherApiSettings.Section).Get<WeatherApiSettings>()!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app
        .UseSwagger()
        .UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("weatherboy-public/swagger.json", "Weather Boy Weather API");
        });
}

app.UseMiddleware<SetCultureProviderCultureHandler>();

app.UseHttpsRedirection();

app
    .MapWeatherEndpoints()
    .MapLocationEndpoints();

app.Run();