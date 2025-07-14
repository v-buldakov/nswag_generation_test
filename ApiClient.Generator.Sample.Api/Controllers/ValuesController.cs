using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Generator.Sample.Api.Controllers;

/// <summary>
/// 
/// </summary>
[Route("[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    /// <summary>
    /// get random value
    /// </summary>
    /// <returns>int</returns>
    [HttpGet]
    public Task<int> GetValue()
    {
        var rand = new Random();
        return Task.FromResult(rand.Next(0, int.MaxValue));

    }
}
