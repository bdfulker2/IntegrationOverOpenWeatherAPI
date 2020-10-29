using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetrieveOpenWeatherAPIData
{
    public class ConfigLibrarySettings : IConfigLibrarySettings
    {
        public string CurrentWeatherForecastApiKey { get; set; }
    }
    public interface IConfigLibrarySettings
    {
        string CurrentWeatherForecastApiKey { get; set; }
    }
}
