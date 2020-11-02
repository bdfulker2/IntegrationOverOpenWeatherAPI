using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetrieveOpenWeatherAPIData
{
    /// <summary>
    /// Configuration Library Settings used for accessing appsetting.json
    /// </summary>
    public class ConfigLibrarySettings : IConfigLibrarySettings
    {
        /// <summary>
        /// Property for accessing the Current Weather Api Key
        /// </summary>
        public string CurrentWeatherForecastApiKey { get; set; }
    }

    /// <summary>
    /// Configuration Library Settings used for accessing appsetting.json
    /// </summary>
    public interface IConfigLibrarySettings
    {
        /// <summary>
        /// Property for accessing the Current Weather Api Key
        /// </summary>
        string CurrentWeatherForecastApiKey { get; set; }
    }
}
