using Mapito.Api.Mappers;
using Mapito.Api.Services;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.DataContract.Weather.Api.Models;

namespace WeatherBoy.Component.WeatherApi.Domain.Mappers;

public class WeatherMapper : IMapper<WeatherApiCurrent, Weather>
{
    private readonly IMapito _mapito;

    public WeatherMapper(IMapito mapito)
    {
        _mapito = mapito;
    }

    public async Task<Weather> Map(WeatherApiCurrent source)
    {
        var lastUpdated = DateTime.Parse(source.LastUpdated);

        var condition = await _mapito.Map<WeatherApiCondition, WeatherCondition>(source.Condition);

        var weather = new Weather(
            lastUpdated,
            source.TempC,
            source.IsDay == 1,
            condition,
            source.WindKph,
            source.GustKph,
            source.WindDegree,
            source.PrecipMm,
            source.PressureMb,
            source.Humidity,
            source.FeelslikeC,
            source.VisKm,
            source.Uv);

        return weather;
    }
}