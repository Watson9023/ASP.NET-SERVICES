using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;

namespace WeatherService
{
    public class Service1 : IService1
    {
        public List<string> Weather5day(string zipcode)
        {
            // trim zipcode to remove whitespace
            zipcode = zipcode.Trim();
            // result that will be returned stored here
            List<string> result = new List<string>();
            // API key used to access data
            string api_key = "4095ef3427ebce19025bab68337f8130";
            // formatted string used to download data
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast?zip={0}&units=imperial&APPID={1}", zipcode, api_key);
            using (WebClient client = new WebClient())
            {
                // download data
                // try downloading json info, if exception return empty List
                try
                {
                    // download data into string
                    string json = client.DownloadString(url);
                    // deserialize into weatherInfo
                    Rootobject weatherInfo = (new JavaScriptSerializer()).Deserialize<Rootobject>(json);
                    // API provides 5 day forecasts. Each day is split into 3 hour blocks. 
                    // For loop finds the times centered at 3:00 pm and adds the weather forecast 
                    // at that time to the final result
                    for (int i = 0; i < weatherInfo.list.Length; i++)
                    {
                        // save  the dt_txt at positions 11-12 corresponding to the time in hours
                        string time = Convert.ToString(weatherInfo.list[i].dt_txt[11]);
                        time += Convert.ToString(weatherInfo.list[i].dt_txt[12]);
                        // compare current block of time to the desired block of time at 3 pm
                        if (time == "15")
                        {
                            // add weather description if the time is at 3 pm
                            result.Add(weatherInfo.list[i].weather[0].description);
                        }
                    }
                    // return list
                    return result;
                }
                // invalid zip code
                catch
                {
                    // returns empty list
                    return result;
                }
            }
        }
    }


    // root of classes used to extract json data
    // extra classes are left intact incase info needed later
    public class Rootobject
    {
        public List[] list { get; set; }

        public class List
        {
            public int dt { get; set; }
            public Main main { get; set; }
            public Weather[] weather { get; set; }
            public string dt_txt { get; set; }

            public class Main
            {
                public float temp { get; set; }
                public float temp_min { get; set; }
                public float temp_max { get; set; }
                public float pressure { get; set; }
                public float sea_level { get; set; }
                public float grnd_level { get; set; }
                public int humidity { get; set; }
                public float temp_kf { get; set; }
            }

            public class Weather
            {
                public int id { get; set; }
                public string main { get; set; }
                public string description { get; set; }
                public string icon { get; set; }
            }
        }
    }
}
