using System.CommandLine;
using System.CommandLine.Parsing;
using System.Reflection;
using System.Runtime.Loader;

using NSwag;
using NSwag.Generation;

internal class Program
{
    private static int Main(string[] args)
    {
        var assemblyPathOption = new Option<string>("--assemblyPath")
        {
            Required = true,
            Description = "Full path to assembly"
        };
        assemblyPathOption.Validators.Add(result =>
        {
            if (string.IsNullOrEmpty(result.GetValue(assemblyPathOption)))
            {
                result.AddError("Full path to assembly must be specified");
            }
        });
        var outputDirOption = new Option<string>("--outputDir")
        {
            Required = true,
            Description = "Path to directory where to save swagger.json"
        };
        outputDirOption.Validators.Add(result =>
        {
            if (string.IsNullOrEmpty(result.GetValue(outputDirOption)))
            {
                result.AddError("Path to output directory must be specified");
            }
        });
        var rootCommand = new RootCommand("Create swagger.json withou assambly bootstrap") { assemblyPathOption, outputDirOption };

        var _exitCode = 0;
        rootCommand.SetAction(parsedResult => CreateFile(args, parsedResult.GetValue(assemblyPathOption)!, parsedResult.GetValue(outputDirOption)!, out _exitCode));

        var parseResult = rootCommand.Parse(args);

        if (parseResult.Errors.Count > 0)
        {
            foreach (ParseError parseError in parseResult.Errors)
            {
                Console.Error.WriteLine(parseError.Message);
            }
            return 1;
        }

        var result = parseResult.Invoke();
        Console.WriteLine($"Application exit with code {_exitCode}");
        return _exitCode;
    }

    private static void CreateFile(string[] args, string assemblyPathOption, string outputDirOption, out int _exitCode)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddEnvironmentVariables();

            var services = builder.Services;

            var loadContext = new PluginLoadContext(assemblyPathOption);
            var assembly = loadContext.LoadFromAssemblyName(AssemblyName.GetAssemblyName(assemblyPathOption));
            services.AddMvc().AddApplicationPart(assembly);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddOpenApiDocument(options =>
            {
                options.PostProcess = document =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "ToDo API",
                        Description = "An ASP.NET Core Web API for managing ToDo items",
                        TermsOfService = "https://example.com/terms",
                        Contact = new OpenApiContact
                        {
                            Name = "Example Contact",
                            Url = "https://example.com/contact"
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Example License",
                            Url = "https://example.com/license"
                        }
                    };
                };
            });

            using var app = builder.Build();

            app.Services.SaveSwaggerJson(outputDirOption);
            Console.WriteLine("File was created");
            _exitCode = 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            _exitCode = 99;
        }
    }
}

internal static class SwaggerExtensions
{
    public static void SaveSwaggerJson(this IServiceProvider provider, string directory)
    {
        IOpenApiDocumentGenerator sw = provider.GetRequiredService<IOpenApiDocumentGenerator>();
        var doc = sw.GenerateAsync("v1").GetAwaiter().GetResult();
        string swaggerFile = doc.ToJson();
        if (!Path.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        File.WriteAllText($"{directory}/swagger.json", swaggerFile);
    }
}

internal class PluginLoadContext : AssemblyLoadContext
{
    private readonly AssemblyDependencyResolver _resolver;

    public PluginLoadContext(string pluginPath)
    {
        _resolver = new AssemblyDependencyResolver(pluginPath);
    }

    protected override Assembly Load(AssemblyName assemblyName)
    {
        var assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
        if (assemblyPath != null)
        {
            return LoadFromAssemblyPath(assemblyPath);
        }

#pragma warning disable CS8603 // Possible null reference return.
        return null;
#pragma warning restore CS8603 // Possible null reference return.
    }

    protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
    {
        var libraryPath = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
        if (libraryPath != null)
        {
            return LoadUnmanagedDllFromPath(libraryPath);
        }

        return IntPtr.Zero;
    }
}