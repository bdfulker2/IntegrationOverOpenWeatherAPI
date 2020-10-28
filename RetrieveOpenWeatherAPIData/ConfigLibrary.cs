using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetrieveOpenWeatherAPIData
{
    public class ConfigLibrary
    {
        public string CurrentWeatherApiKey { get; set; }
    }
    public interface IConfigLibarry
    {
        public string CurrentWeatherApiKey { get; set; }
    }
}
