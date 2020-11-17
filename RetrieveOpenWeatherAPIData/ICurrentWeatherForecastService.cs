using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetrieveOpenWeatherAPIData
{
    /// <summary>
    /// Interface for CurrentWeatherForecastService
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICurrentWeatherForecastService<T> where T : class
    {
        /// <summary>
        /// Interface for current weather forecast  
        /// </summary>
        /// <param name="city">string for weather forecast city</param>
        /// <param name="stateCode">state code for US states only</param>
        /// <param name="countryCode">country code</param>
        T GetCurrentWeather(string city, string stateCode, string countryCode);
    }
}
