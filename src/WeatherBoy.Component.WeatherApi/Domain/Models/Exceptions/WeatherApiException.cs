namespace WeatherBoy.Component.WeatherApi.Domain.Models.Exceptions;

public class WeatherApiException : Exception
{
    public WeatherApiException(
        string message,
        int statusCode,
        string response)
        : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" +
               response[..(response.Length >= 512 ? 512 : response.Length)])
    {
        StatusCode = statusCode;
        Response = response;
    }

    public int StatusCode { get; }

    public string Response { get; }

    public override string ToString()
    {
        return $"HTTP Response: \n\n{Response}\n\n{base.ToString()}";
    }
}