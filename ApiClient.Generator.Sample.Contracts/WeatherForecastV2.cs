﻿namespace ApiClient.Generator.Sample.Contracts;
public class WeatherForecastV2
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public required string Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
