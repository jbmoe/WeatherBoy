using MediatR;
using WeatherBoy.Component.WeatherApi.Api.Models.Responses;

namespace WeatherBoy.Component.WeatherApi.Domain.Models.Requests;

public class FetchIpInformationQuery : IRequest<WeatherApiIpInformation>
{
    public FetchIpInformationQuery(string ipAddress)
    {
        IpAddress = ipAddress;
    }

    public string IpAddress { get; set; }
}
