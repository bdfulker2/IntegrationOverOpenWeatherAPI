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
    [Route("[controller]")]
    [Route("api.openweather.org/data/2.5/weather?q={city name},{state code},{country code}&appid={/[controller]")]
    [Consumes("application/json", "text/json")]
    public class CurrentWeatherForecastController : ControllerBase
    { 
        private readonly ILogger<CurrentWeatherForecastController> _logger;

        public CurrentWeatherForecastController(ILogger<CurrentWeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<CurrentWeatherForecast> Get()
        {
           
        }
    }
}
