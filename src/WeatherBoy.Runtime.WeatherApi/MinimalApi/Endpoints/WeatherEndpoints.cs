using Microsoft.AspNetCore.Mvc;
using WeatherBoy.Component.WeatherApi.Api.Models.Exceptions;
using WeatherBoy.Component.WeatherApi.Api.Services;
using WeatherBoy.DataContract.Weather.Api.Models;

namespace WeatherBoy.Runtime.WeatherApi.MinimalApi.Endpoints;

public static class WeatherEndpoints
{
    public static WebApplication MapWeatherEndpoints(this WebApplication app)
    {
        var group = app
            .MapGroup("/weather")
            .WithGroupName("weatherboy-public");

        group
            .MapGet("/forecast", async (
                [FromQuery] decimal latitude,
                [FromQuery] decimal longitude,
                IWeatherService weatherService) =>
            {
                try
                {
                    var weatherForecast = await weatherService.GetWeatherForecast(latitude, longitude, 3);

                    return Results.Ok(weatherForecast);
                }
                catch (WeatherForCityNotFoundException e)
                {
                    return Results.NotFound(e);
                }
            })
            .Produces<WeatherForecast>()
            .Produces(statusCode: StatusCodes.Status404NotFound)
            .WithName("GetWeatherForecast")
            .WithOpenApi();

        group
            .MapGet("/current", async (
                [FromQuery] decimal latitude,
                [FromQuery] decimal longitude,
                IWeatherService weatherService) =>
            {
                try
                {
                    var currentWeather = await weatherService.GetCurrentWeather(latitude, longitude);

                    return Results.Ok(currentWeather);
                }
                catch (WeatherForCityNotFoundException e)
                {
                    return Results.NotFound(e);
                }
            })
            .Produces<CurrentWeather>()
            .Produces(statusCode: StatusCodes.Status404NotFound)
            .WithName("GetCurrentWeather")
            .WithOpenApi();

        return app;
    }
}