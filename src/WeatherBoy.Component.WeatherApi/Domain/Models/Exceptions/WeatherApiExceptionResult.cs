namespace WeatherBoy.Component.WeatherApi.Domain.Models.Exceptions;

public class WeatherApiExceptionResult<TResult> : WeatherApiException
{
    public WeatherApiExceptionResult(string message, int statusCode, string response, TResult? result)
        : base(message, statusCode, response)
    {
        Result = result;
    }

    public TResult? Result { get; }
}