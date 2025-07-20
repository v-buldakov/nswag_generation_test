using ApiClient.Generator.Sample.Contracts;

using Asp.Versioning;

using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Generator.Sample.Api.Controllers.V2;
/// <summary>
/// 
/// </summary>
[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/weather-forecast")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task<WeatherForecast[]> GetForecasts()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
               new WeatherForecast
               (
                   DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                   Random.Shared.Next(-20, 55),
                   summaries[Random.Shared.Next(summaries.Length)]
               ))
               .ToArray();
        return Task.FromResult(forecast ?? []);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("generic-response")]
    public IEnumerable<WeatherForecastV2> GenericResponse()
    {
        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastV2
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = summaries[rng.Next(summaries.Length)]
        })
        .ToArray();
    }
}
