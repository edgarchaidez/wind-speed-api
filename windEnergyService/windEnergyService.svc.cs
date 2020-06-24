using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace windEnergyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    // This service takes in parameters for longitude and longitude, calls another api to get accurate weather
    // data within a 5 day forecast, and returns a weather object in JSON format 
    // containing various wind speed data that can be used to determine the plausability of installing wind energy at a certain location.
    public class windEnergyService : IService1
    {
        // Method calls a weather api and retrieves wind data from a 5 day forecast of the city 
        // specified in the coordinates given. It then performs calculations to create a weather object with
        // max speed, min speed, and average wind speed fields.
        public WeatherObject getWindData(double lat, double lng)
        {
            // Calling the getWeather function to retrieve weather object from the weather api
            RootObject root = getWeather(lat, lng);

            // Creating a WeatherObject 
            WeatherObject weather = new WeatherObject();

            // Creating a WindObject
            WindObject wind = new WindObject();

            // Retrieving max wind speeds, min wind speeds, and average wind speeds from the RootObject object
            double max_wind = 0, min_wind = 0, avg_wind = 0;
            int count = 0; // Keep track of number of list objects in root.list
            foreach (List list in root.list)
            {
                // Getting wind speed from data
                double wind_speed = list.wind.speed;
                avg_wind += wind_speed;

                // Update min_wind if a new lower wind_speed is found
                if (min_wind == 0) min_wind = wind_speed;
                else if (min_wind > wind_speed) min_wind = wind_speed;

                // Update max_wind if a new higher wind_speed is found
                if (max_wind == 0) max_wind = wind_speed; // Set default to be first wind_speed data
                else if (max_wind < wind_speed) max_wind = wind_speed;

                count++; // Increment count
            }

            // Update fields for WindObject
            wind.avg_wind_speed = avg_wind / count;
            wind.max_wind_speed = max_wind;
            wind.min_wind_speed = min_wind;

            // Update fields for WeatherObject
            weather.wind = wind;
            weather.city_name = root.city.name;
            weather.country_name = root.city.country;

            return weather;
        }

        // Calls the weather api using its parameter fields for latitude and longitude 
        //and retrieves JSON response and returns it as an object.
        public RootObject getWeather(double lat, double lng)
        {
            // Calling weather api using parameters passed to the function and converting JSON response
            // into a string
            string url = @"https://api.openweathermap.org/data/2.5/forecast?lat=" + lat + "&lon=" +
                lng + "&appid=" + "8ac660e39e9d6df6c73a144023ca3f0a";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            // Deserializing string into object
            RootObject weather = JsonConvert.DeserializeObject<RootObject>(responsereader);

            return weather;
        }

    }

    // To call the weather api and retrieve it's data, the following objects are required.
    public class RootObject
    {
        public List<List> list { get; set; }
        public City city { get; set; }
    }

    public class List
    {
        public Main m { get; set; }

        public List<Weather> weather { get; set; }
        public Wind wind { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
    }

    public class Weather
    {
        public double id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public string country { get; set; }
    }
}
