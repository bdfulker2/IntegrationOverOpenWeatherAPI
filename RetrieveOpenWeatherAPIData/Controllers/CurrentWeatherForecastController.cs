using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RetrieveOpenWeatherAPIData.Controllers
{
    /// <summary>
    /// Controller for making Http Requests to our API
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json", "text/json")]
    public class CurrentWeatherForecastController : ControllerBase
    {
        // Read only access to ICurrentWeatherService<CurrentWeatherForecastRoot>
        private readonly ICurrentWeatherForecastService<CurrentWeatherForecastRoot> _ICurrentWeatherService;
        //Readonly access to ILogger
        private readonly ILogger _logger;

        //Constructor with dependency injection for ICurrentWeatherForecastService and ILogger
        public CurrentWeatherForecastController(ICurrentWeatherForecastService<CurrentWeatherForecastRoot> currentWeatherService, ILogger<CurrentWeatherForecastController> logger)
        {
            _logger = logger;
            _ICurrentWeatherService = currentWeatherService;
        }

        [HttpGet]
        public ActionResult<CurrentWeatherForecastRoot> GetCurrentWeather(string city, string stateCode, string countryCode)
        {
            //https://localhost:44353/api/CurrentWeatherForecast?city=Naples&stateCode=FL&countryCode=US/
            _logger.LogDebug("HTTP request GetCurrentWeather() in CurrentWeatherForecastController");
            return _ICurrentWeatherService.GetCurrentWeather(city, stateCode, countryCode);
        }
    }
}
