﻿using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RetrieveOpenWeatherAPIData
{
    public class CurrentWeatherForecastService : ICurrentWeatherForecastService<CurrentWeatherForecastRoot>
    {
        //Read-only access to ILogger
        private readonly ILogger _logger;

        //read-only access to _currentWeatherApiKey
        private readonly string _currentWeatherApiKey;

        //Property for CurrentForecast
        private static CurrentWeatherForecastRoot CurrentForecast { get; set; }

        /// <summary>
        /// Constructor with dependency injection of IConfigLibrarySettings and ILogger
        /// </summary>
        /// <param name="settings">provides access to CurrentWeatherForecastApiKey through dependency injection</param>
        /// <param name="logger">provides access to ILogger through dependency injection</param>
        public CurrentWeatherForecastService(IConfigLibrarySettings settings, ILogger<CurrentWeatherForecastService> logger)
        {
            _currentWeatherApiKey = settings.CurrentWeatherForecastApiKey;
            _logger = logger;
        }

        /// <summary>
        /// Calls asynchronous task for calling openWeatherAPI for accessing their current weather forecast.
        /// </summary>
        /// <param name="city">city name for weather forecast</param>
        /// <param name="stateCode">state code for US only. Ignored if countryCode isn't "US"</param>
        /// <param name="countryCode">two digit country code follows ISO 3166</param>
        /// <returns>CurrentWeatherForecastRoot object from the external URL  api call</returns>
        public CurrentWeatherForecastRoot GetCurrentWeather(string city, string stateCode, string countryCode)
        {
            var response = CurrentWeather(city, stateCode, countryCode);
            response.Wait();
            return CurrentForecast;
        }

        /// <summary>
        /// Asynchronous task for access OpenWeatherAPI.org current weather for one city
        /// </summary>
        /// <param name="city">city name for weather forecast</param>
        /// <param name="stateCode">state code for US only. Ignored if countryCode isn't "US"</param>
        /// <param name="countryCode">two digit country code follows ISO 3166</param>
        /// <returns>returns Task</returns>
        public async Task CurrentWeather(string city, string stateCode, string countryCode)
        {
            var httpClient = HttpClientFactory.Create();

            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city},{stateCode},{countryCode}&appid={_currentWeatherApiKey}";

            HttpResponseMessage httpResponse;

            try
            {
                httpResponse = await httpClient.GetAsync(url).ConfigureAwait(false);
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = httpResponse.Content;
                    CurrentForecast =  await responseContent.ReadAsAsync<CurrentWeatherForecastRoot>().ConfigureAwait(false);
                }
                _logger.LogInformation(httpResponse.StatusCode.ToString());
            }catch(HttpRequestException e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}