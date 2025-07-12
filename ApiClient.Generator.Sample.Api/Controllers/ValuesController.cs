using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Generator.Sample.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public Task<int> GetValue()
    {
        var rand = new Random();
        return Task.FromResult(rand.Next(0, int.MaxValue));

    }
}
