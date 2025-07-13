using System.Text.Json;

namespace ApiClient.Generator.Sample.Client.Clients;
public partial class ApiHttpBaseClient
{
    private readonly ApiHttpConfiguration _configuration;

    public ApiHttpBaseClient(ApiHttpConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ApiHttpConfiguration Configuration => _configuration;

    public static void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
    {
    }
}
