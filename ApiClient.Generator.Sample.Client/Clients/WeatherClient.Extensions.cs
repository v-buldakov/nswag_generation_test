namespace ApiClient.Generator.Sample.Client.Clients;

public partial class WeatherClient
{
    partial void Initialize()
    {
        _instanceSettings = Configuration.JsonSerializerOptions;
    }
}
