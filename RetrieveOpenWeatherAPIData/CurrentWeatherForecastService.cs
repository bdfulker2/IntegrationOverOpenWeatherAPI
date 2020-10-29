using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RetrieveOpenWeatherAPIData
{
    public class CurrentWeatherForecastService : ICurrentWeatherForecastService<CurrentWeatherForecastRoot>
    {
        private readonly ILogger _logger;
        private readonly string _currentWeatherApiKey;// = "b2606ae6893ffc32d31fc1a1eac04365";
        private string CityName { get; set; }
        private string StateCode { get; set; }
        private string CountryCode { get; set; }
        private static CurrentWeatherForecastRoot CurrentForecast { get; set; } 


        public CurrentWeatherForecastService(IConfigLibrarySettings settings, ILogger<CurrentWeatherForecastService> logger)
        {
            _currentWeatherApiKey = settings.CurrentWeatherForecastApiKey;
            _logger = logger;
            // _logger.LogInformation(settings.CurrentWeatherForecastApiKey);
        }

        public CurrentWeatherForecastRoot GetCurrentWeather(string city, string stateCode, string countryCode)
        {
            var response = CurrentWeather(city, stateCode, countryCode);
            response.Wait();
            return CurrentForecast;
        }

        public async Task CurrentWeather(string city, string stateCode, string countryCode)
        {
            CityName = city;
            StateCode = stateCode;
            CountryCode = countryCode;
            var httpClient = HttpClientFactory.Create();

            var url = $"https://api.openweathermap.org/data/2.5/weather?q={CityName},{StateCode},{CountryCode}&appid={_currentWeatherApiKey}";

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await httpClient.GetAsync(url);
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = httpResponse.Content;
                    CurrentForecast =  await responseContent.ReadAsAsync<CurrentWeatherForecastRoot>();

                }
                _logger.LogInformation(httpResponse.StatusCode.ToString());
            }catch(HttpRequestException e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}