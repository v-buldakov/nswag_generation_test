using ApiClient.Generator.Sample.Client.Clients;
using ApiClient.Generator.Sample.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Generator.Sample.Usage.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherClient _weatherClient;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherClient weatherClient)
    {
        _logger = logger;
        _weatherClient = weatherClient;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get() => await _weatherClient.GetForecastsAsync();
}
