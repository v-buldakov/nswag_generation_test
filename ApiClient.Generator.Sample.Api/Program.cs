using ApiClient.Generator.Sample.Api;

using Asp.Versioning;

using NSwag;
using NSwag.Generation.AspNetCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        builder.Services.AddControllers();
        builder.Services.AddProblemDetails();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSingleton<VersionTaggingOperationProcessor>();
        builder.Services
                .AddOpenApiDocument(configure =>
                {
                    BaseConfigure(configure, "v1");
                })
                .AddOpenApiDocument(configure =>
                {
                    BaseConfigure(configure, "v2");
                })
                .AddOpenApiDocument((configure, serviceProvider) =>
                {
                    BaseConfigure(configure, "vall", new[] { "v1", "v2" });
                    configure.OperationProcessors.Add(serviceProvider.GetService<VersionTaggingOperationProcessor>());
                });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }

    private static void BaseConfigure(AspNetCoreOpenApiDocumentGeneratorSettings configure, string docName, string[] apiGroupNames)
    {
        configure.DocumentName = docName;
        configure.ApiGroupNames = apiGroupNames;

        configure.PostProcess = document =>
        {
            document.Info.Version = docName;
            document.Info.Title = "App API";
            document.Info.Description = "A simple ASP.NET Core web API";
            document.Info.TermsOfService = "None";
            document.Info.Contact = new OpenApiContact
            {
                Name = "Test Author",
                Email = string.Empty,
                Url = "some medium"
            };
            document.Tags = apiGroupNames.Select(x => new OpenApiTag { Name = x }).ToList();
        };

    }
    private static void BaseConfigure(AspNetCoreOpenApiDocumentGeneratorSettings configure, string docName)
    {
        BaseConfigure(configure, docName, new[] { docName });
    }

}
