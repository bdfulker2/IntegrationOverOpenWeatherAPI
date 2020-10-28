using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetrieveOpenWeatherAPIData
{
    public class CurrentWeatherForecastService
    {
        public string city;
        public string stateCode;
        public string countryCode;
        public string currentWeatherApiKey = 
        public string path = $"https://api.openweathermap.org/data/2.5/weather?q={cityName},{stateCode},{countryCode}&appid={currentWeatherApiKey}";
        
           //http://api.openweathermap.org/data/2.5/weather?q=Naples,FL,US&appid=b2606ae6893ffc32d31fc1a1eac04365
            //https://api.openweathermap.org/data/2.5/weather?q=Naples,FL,US&appid=b2606ae6893ffc32d31fc1a1eac04365


    }
}