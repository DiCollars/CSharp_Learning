using FilterTesting.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace FilterTesting.Controllers
{
    [ApiController]
    //[ResponseHeader("FAO-Key", "343jj5-654k-657kk-222v")]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [ExceptionHandler]
        [HttpGet("GetWeatherForecastWithException")]
        public IEnumerable<WeatherForecast> GetWeatherForecastWithException()
        {
            throw new NotImplementedException();
        }

        [ResultHeader]
        [HttpGet("FineResult")]
        public IActionResult FineResult()
        {
            return Ok("Fine!");
        }

        [ExceptionHandler]
        [ResultHeader]
        [HttpGet("NotFineResult")]
        public IActionResult NotFineResult()
        {
            throw new NotImplementedException();
        }

        [HttpGet("FilterOrder")]
        public IActionResult FilterOrder()
        {
            return Ok("Order!");
        }

        [HttpGet("FilterOrderException")]
        public IActionResult FilterOrderException()
        {
            throw new NotImplementedException();
        }

        [ResponseHeaderAttribute("FAO-Key", "343jj5-654k-657kk-222v", Order = int.MinValue)] //[ResponseHeaderAttribute("FAO-Key", "343jj5-654k-657kk-222v")] 
        [HttpGet("GlobalFilterAttribute")]
        public IActionResult GlobalFilterAttribute()
        {
            return Ok("Order!");
        }
    }
}