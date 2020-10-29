using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RetrieveOpenWeatherAPIData;

namespace RetrieveOpenWeatherAPIData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json", "text/json")]
    public class CurrentWeatherForecastController : ControllerBase
    {
        private readonly ICurrentWeatherForecastService<CurrentWeatherForecastRoot> _ICurrentWeatherService;
        private readonly ILogger _logger;

        public CurrentWeatherForecastController(ICurrentWeatherForecastService<CurrentWeatherForecastRoot> currentWeatherService, ILogger<CurrentWeatherForecastController> logger)
        {
            _logger = logger;
            _ICurrentWeatherService = currentWeatherService;
        }

        [HttpGet]
        public ActionResult<CurrentWeatherForecastRoot> GetCurrentWeather(string city, string stateCode, string countryCode)
        {
            //https://localhost:44353/api/CurrentWeatherForecast ?city=Naples&stateCode=FL&countryCode=US/
            _logger.LogDebug("HTTP request GetCurrentWeather() in CurrentWeatherForecastController");
            return _ICurrentWeatherService.GetCurrentWeather(city, stateCode, countryCode);
            //return _ICurrentWeatherService.GetCurrentWeather("Naples", "FL", "US");

        }
    }
}
