using Mapito.Api.Mappers;
using Mapito.Api.Services;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.DataContract.Weather.Api.Models;

namespace WeatherBoy.Component.WeatherApi.Domain.Mappers;

public class WeatherForecastDayMapper : IMapper<WeatherApiForecast.WeatherApiForecastday, WeatherForecastDay>
{
    private readonly IMapito _mapito;

    public WeatherForecastDayMapper(IMapito mapito)
    {
        _mapito = mapito;
    }

    public async Task<WeatherForecastDay> Map(WeatherApiForecast.WeatherApiForecastday source)
    {
        var date = DateOnly.Parse(source.Date);
        var sunrise = TimeOnly.Parse(source.Astro.Sunrise);
        var sunset = TimeOnly.Parse(source.Astro.Sunset);

        var condition = _mapito.Map<WeatherApiCondition, WeatherCondition>(source.Day.Condition);
        var forecastHours = _mapito.Map<WeatherApiForecast.WeatherApiForecastday.WeatherApiHour, WeatherForecastHour>(source.Hour);

        await Task.WhenAll(condition, forecastHours);

        var forecastDay = new WeatherForecastDay(
            date,
            source.Day.MaxtempC,
            source.Day.MintempC,
            source.Day.AvgtempC,
            source.Day.MaxwindKph,
            source.Day.TotalprecipMm,
            source.Day.AvgvisKm,
            source.Day.Avghumidity,
            source.Day.DailyWillItRain == 1,
            source.Day.DailyChanceOfRain,
            source.Day.DailyWillItSnow == 1,
            source.Day.DailyChanceOfSnow,
            condition.Result,
            source.Day.Uv,
            sunrise,
            sunset,
            forecastHours.Result.ToList());

        return forecastDay;
    }
}