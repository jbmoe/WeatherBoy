using Mapito.Api.Mappers;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;
using WeatherBoy.DataContract.Weather.Api.Models;

namespace WeatherBoy.Component.WeatherApi.Domain.Mappers;

public class WeatherConditionMapper : IMapper<WeatherApiCondition, WeatherCondition>
{
    public Task<WeatherCondition> Map(WeatherApiCondition source)
    {
        return Task.FromResult(new WeatherCondition(source.Text, source.Icon, source.Code));
    }
}