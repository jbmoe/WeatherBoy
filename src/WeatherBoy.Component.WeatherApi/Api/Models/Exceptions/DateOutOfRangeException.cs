namespace WeatherBoy.Component.WeatherApi.Api.Models.Exceptions;

public class DateOutOfRangeException : Exception
{
    public DateOutOfRangeException(string message)
        : base(message)
    {
    }

    public static DateOutOfRangeException ForDate(DateOnly date)
    {
        return new DateOutOfRangeException($"No weather data returned for date {date} as date is out of range");
    }
}