using Microsoft.AspNetCore.Mvc;
using TechFolio.Server.Services;

namespace TechFolio.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _forecastService;

        public WeatherForecastController(WeatherForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _forecastService.GetForecast();
        }
    }
}
