using LoginTestAppV3.Domain;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LoginTestAppV3.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    private static readonly string[] _summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        logger.LogInformation("Weather Forecast Processing Started");
        Log.Information("Serilog: Weather Forecast Processing Started");

        var data = Enumerable.Range(1, 20).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = _summaries[Random.Shared.Next(_summaries.Length)]
        })
           .ToArray();

        logger.LogInformation("Weather Forecast Processing Ended");
        Log.Information("Serilog: Weather Forecast Processing Ended");

        return data;
    }
}
