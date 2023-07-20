using MediatR.Pipeline;
using WeatherBoy.Component.WeatherApi.Domain.Helpers;
using WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

namespace WeatherBoy.Component.WeatherApi.Domain.RequestPreProcessors;

public class ReplaceDanoLettersPreProcessor : IRequestPreProcessor<FetchCitiesQuery>
{
    public Task Process(FetchCitiesQuery request, CancellationToken cancellationToken)
    {
        request.CityName = LetterSubstituteHelper.ReplaceDanoLetters(request.CityName);
        return Task.CompletedTask;
    }
}