using ApiClient.Generator.Sample.Contracts;

using Asp.Versioning;

using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Generator.Sample.Api.Controllers;

/// <summary>
/// 
/// </summary>
[Route("v{version:apiVersion}/weather-forecast")]
[ApiController]
[ApiVersion("1.0")]
public class WeatherForecastController : ControllerBase
{
    private readonly string[] summaries = { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [MapToApiVersion("1.0")]
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
}
