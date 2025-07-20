using ApiClient.Generator.Sample.Client.Clients;
using ApiClient.Generator.Sample.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Generator.Sample.Usage.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastClient _weatherClient;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastClient weatherClient)
    {
        _logger = logger;
        _weatherClient = weatherClient;
    }

    [HttpGet("~/getWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get() => await _weatherClient.GetForecastsAsync();


    [HttpGet("~/getWeatherForecastV2")]
    public async Task<IEnumerable<WeatherForecast>> GetV2() => await _weatherClient.GetForecasts2Async();
}
