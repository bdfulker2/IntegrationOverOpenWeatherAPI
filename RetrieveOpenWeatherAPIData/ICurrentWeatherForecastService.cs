using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetrieveOpenWeatherAPIData
{
    public interface ICurrentWeatherForecastService<T> where T : class
    {
        T GetCurrentWeather(string city, string stateCode, string countryCode);
    }
}
