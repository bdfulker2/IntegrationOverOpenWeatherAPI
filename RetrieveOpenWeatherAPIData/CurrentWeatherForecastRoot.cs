using System;
using System.Collections.Generic;

namespace RetrieveOpenWeatherAPIData
{
    /// <summary>
    /// Provides Coordinates latitude and longitude for city
    /// </summary>
    public class Coord
    {
        /// <summary>
        /// Longitude for specified city
        /// </summary>
        public double Lon { get; set; }
        /// <summary>
        /// Latitude for specified city
        /// </summary>
        public double Lat { get; set; }
    }

    /// <summary>
    /// Object for obtaining weather information
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Property for Id number
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Property for Id number
        /// </summary>
        public string Main { get; set; }
        /// <summary>
        /// Property for Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Property for Icon
        /// </summary>
        public string Icon { get; set; }
    }

    /// <summary>
    /// Object for accessing main information set
    /// </summary>
    public class Main
    {
        /// <summary>
        /// Property for Temperature
        /// </summary>
        public double Temp { get; set; }
        /// <summary>
        /// Property for Feels_Like
        /// </summary>
        public double Feels_Like { get; set; }
        /// <summary>
        /// Property for Temp_Min
        /// </summary>
        public double Temp_Min { get; set; }
        /// <summary>
        /// Property for Temp_Max
        /// </summary>
        public double Temp_Max { get; set; }
        /// <summary>
        /// Property for Pressure
        /// </summary>
        public int Pressure { get; set; }
        /// <summary>
        /// Property for Humidity
        /// </summary>
        public int Humidity { get; set; }
    }

    /// <summary>
    /// Object for accessing Wind Properties
    /// </summary>
    public class Wind
    {
        /// <summary>
        /// Property for Wind Speed
        /// </summary>
        public double Speed { get; set; }
        /// <summary>
        /// Property for Direction of wind in degrees
        /// </summary>
        public int Deg { get; set; }
    }

    /// <summary>
    /// Object for accessing cloud properties of the weather
    /// </summary>
    public class Clouds
    {
        /// <summary>
        /// Property for All
        /// </summary>
        public int All { get; set; }
    }

    /// <summary>
    /// Object for accessing System properties
    /// </summary>
    public class Sys
    {
        /// <summary>
        /// Property for Type
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// Property Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Property for Message
        /// </summary>
        public double Message { get; set; }
        /// <summary>
        /// Property for Country Code
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Property for Sunrise time
        /// </summary>
        public int Sunrise { get; set; }
        /// <summary>
        /// Property for Sunset time
        /// </summary>
        public int Sunset { get; set; }
    }

    /// <summary>
    /// Root object for accessing all other weather objects and properties
    /// </summary>
    public class CurrentWeatherForecastRoot
    {
        /// <summary>
        /// Property for accessing Coordinates object
        /// </summary>
        public Coord Coord { get; set; }
        /// <summary>
        /// Property for accessing Weather Object
        /// </summary>
        public List<Weather> Weather { get; set; }
        /// <summary>
        /// Project for Accessing @Base
        /// </summary>
        public string @Base { get; set; }
        /// <summary>
        /// Property for accessing Main object
        /// </summary>
        public Main Main { get; set; }

        /// <summary>
        /// Property for accessing Visibility
        /// </summary>
        public int Visibility { get; set; }
        /// <summary>
        /// Property for accessing Wind object
        /// </summary>
        public Wind Wind { get; set; }
        /// <summary>
        /// Property for Clouds object
        /// </summary>
        public Clouds Clouds { get; set; }
        /// <summary>
        /// Property for Dt
        /// </summary>
        public int Dt { get; set; }
        /// <summary>
        /// Property for accessing Sys object
        /// </summary>
        public Sys Sys { get; set; }
        /// <summary>
        /// Property for Timezone
        /// </summary>
        public int Timezone { get; set; }
        /// <summary>
        /// Property for Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Property for Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property for Cod
        /// </summary>
        public int Cod { get; set; }
    }
}
