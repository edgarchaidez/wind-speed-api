using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace windEnergyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        // This method is invoked when the api is called and takes in two parameters, longitude and latitude as double types,
        // and returns a WeatherObject object with information about the city and country name, as well as the locations
        // wind speeds.
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getWindData?lat={lat}&lng={lng}")]
        WeatherObject getWindData(double lat, double lng);

    }


    // Represents the weather object to be returned in the web service. Contains fields for a city name,
    // country name, and a wind object related to the city.
    [DataContract]
    public class WeatherObject
    {
        [DataMember]

        public string city_name { get; set; }

        [DataMember]
        public string country_name { get; set; }

        [DataMember]
        public WindObject wind { get; set; }

    }

    // Represents the different wind speeds of a given city. Fields include the max wind speed, min wind speed,
    // and avg_wind speed for the five day forecast in meters per second.
    [DataContract]
    public class WindObject
    {
        [DataMember]
        public double max_wind_speed { get; set; }

        [DataMember]
        public double min_wind_speed { get; set; }

        [DataMember]
        public double avg_wind_speed { get; set; }
    }
}
