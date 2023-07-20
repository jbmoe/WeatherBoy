using Mapito.Api.Mappers;
using Mapito.Api.Services;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.DataContract.Weather.Api.Models;

namespace WeatherBoy.Component.WeatherApi.Domain.Mappers;

public class WeatherForecastHourMapper : IMapper<WeatherApiForecast.WeatherApiForecastday.WeatherApiHour, WeatherForecastHour>
{
    private readonly IMapito _mapito;

    public WeatherForecastHourMapper(IMapito mapito)
    {
        _mapito = mapito;
    }

    public async Task<WeatherForecastHour> Map(WeatherApiForecast.WeatherApiForecastday.WeatherApiHour source)
    {
        var time = DateTime.Parse(source.Time);

        var condition = await _mapito.Map<WeatherApiCondition, WeatherCondition>(source.Condition);

        var hour = new WeatherForecastHour(
            time,
            source.TempC,
            source.IsDay == 1,
            condition,
            source.WindKph,
            source.GustKph,
            source.WindDegree,
            source.PressureMb,
            source.PrecipMm,
            source.Humidity,
            source.FeelslikeC,
            source.HeatindexC,
            source.DewpointC,
            source.WillItRain == 1,
            source.ChanceOfRain,
            source.WillItSnow == 1,
            source.ChanceOfSnow,
            source.VisKm,
            source.Uv);

        return hour;
    }
}