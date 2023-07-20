using Microsoft.AspNetCore.Mvc;
using WeatherBoy.Component.WeatherApi.Api.Services;
using WeatherBoy.DataContract.Weather.Api.Models;

namespace WeatherBoy.Runtime.WeatherApi.MinimalApi.Endpoints;

public static class LocationEndpoints
{
    public static WebApplication MapLocationEndpoints(this WebApplication app)
    {
        var group = app
            .MapGroup("/locations")
            .WithGroupName("weatherboy-public");

        group
            .MapGet("/search", async (
                [FromQuery] string term,
                ISearchService searchService) =>
            {
                var cities = await searchService.GetCities(term);

                return Results.Ok(cities);
            })
            .Produces<List<Location>>()
            .WithName("SearchCitiesByName")
            .WithOpenApi();

        return app;
    }
}