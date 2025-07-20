using System.Reflection;

namespace ApiClient.Generator.Proxy;

public class Program
{
    public static int Main(string[] args)
    {
        var assembly = Assembly.Load("ApiClient.Generator.Sample.Api");

        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddMvc().AddApplicationPart(assembly);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApiDocument();

        var app = builder.Build();

        return 0;
    }
}
