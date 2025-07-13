using ApiClient.Generator.Sample.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Generator.Sample.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly string[] summaries = { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

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
}
