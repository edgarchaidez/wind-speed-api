using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace WindServiceTryItApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // When coordinates are submitted, the function makes a call to the windService api and
        // outputs the wind speed data from that location.
        protected void Button1_Click(object sender, EventArgs e)
        {
            int latitude = Int32.Parse(TextBox1.Text); // Getting latitude input from textbox 1
            int longitude = Int32.Parse(TextBox2.Text); // Getting longitude from textbox 2

            // Making api call with given address as a parameter
            string url = @"http://localhost:50198/windEnergyService.svc?lat=" + latitude + "&lng=" + longitude;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            WeatherObject weather = JsonConvert.DeserializeObject<WeatherObject>(responsereader);

            TextBox3.Text = weather.city_name + ", " + weather.country_name;

            // Setting text in text boxes to contain the max wind speed, min wind speed, and avg wind speed
            // in miles per hour and format to have a max of 2 decimal places
            TextBox4.Text = String.Format("{0:0.##}", (weather.wind.max_wind_speed * 2.23694)) + " mph";
            TextBox5.Text = String.Format("{0:0.##}", (weather.wind.min_wind_speed * 2.23694)) + " mph";
            TextBox6.Text = String.Format("{0:0.##}", (weather.wind.avg_wind_speed * 2.23694)) + " mph";
            
            // Determining whether wind speed is sufficient enough for wind energy and
            // setting sentence text to label9. If wind speed is below 9 mph it won't be sufficient for wind
            // energy above 9 mph it can power a small turbine, 
            if(weather.wind.avg_wind_speed >= 4)
            {
                Label9.Text = weather.wind.avg_wind_speed >= 9 ? "Great wind speed for wind energy!" :
                   "Enough wind speed to power a small wind turbine!";
            }
            else
            {
               Label9.Text = "Wind speed is not very sufficient for wind energy at this location.";
            }
        }

        public class WeatherObject
        {
            public string city_name { get; set; }
            public string country_name { get; set; }
            public WindObject wind { get; set; }
        }

        public class WindObject
        {
            public double max_wind_speed { get; set; }
            public double min_wind_speed { get; set; }
            public double avg_wind_speed { get; set; }
        }
    }
}