namespace ApiClient.Generator.Sample.Client.Clients;

///<remarks>
/// Для корректной инициализации клиента необходимо для каждого создать partial class с partial методом Initialize в котором необходимо прописать порядок инициализации клиента и его настроек. Так необходимо сделать для каждого клиента который будет использоваться в приложении.
/// </remarks>
public partial class WeatherForecastClient
{
    partial void Initialize()
    {
        _instanceSettings = Configuration.JsonSerializerOptions;
    }
}
