using Microsoft.AspNetCore.Http;
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

        /// Route: /api/CurrentWeatherForecast?city={cityName}&stateCode={stateCode}&countryCode={ISO 3166 country code}
        /// <summary>
        /// Retrieves current weather for one city
        /// </summary>
        /// <remarks>
        /// Returns Current weather of specified city. 
        /// </remarks>
        /// <param name="city">String name of city</param>
        /// <param name="stateCode">State code only needed if US is the country code</param>
        /// <param name="countryCode">Two digit country code using ISO 3166</param>
        /// <returns>Returns all buildStatus document is collection</returns>
        /// <response code = "200">Success list of records found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrentWeatherForecastRoot))]
        public ActionResult<CurrentWeatherForecastRoot> GetCurrentWeather(string city, string stateCode, string countryCode)
        {
            //https://localhost:44353/api/CurrentWeatherForecast?city=Naples&stateCode=FL&countryCode=US/
            _logger.LogDebug("HTTP request GetCurrentWeather() in CurrentWeatherForecastController");
            return _ICurrentWeatherService.GetCurrentWeather(city, stateCode, countryCode);
        }
    }
}
