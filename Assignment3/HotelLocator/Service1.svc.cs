using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace HotelLocator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<string> findHotel(string city, float rating)
        {
            // trim leading and trailing whitespace
            city = city.Trim();
            // api key for google services, connected to my creditcard, please be kind :(
            string api_key = "AIzaSyBdq_oSqZuIU52qxSRaC8gHAPBtEafDAWM";
            // formatted url for downloading json data
            string url = string.Format("https://maps.googleapis.com/maps/api/geocode/json?components=locality:{0}&key={1}", city, api_key);
            // var declaration used to call second service
            string latAndlon;
            // results list that will be returned
            List<string> result = new List<string>();
            using (WebClient client = new WebClient())
            {
                //download data into string
                string json = client.DownloadString(url);
                // deserialize into zip object
                geoCodeObject city_coordinates = (new JavaScriptSerializer()).Deserialize<geoCodeObject>(json);
                // if zip received is valid
                if (city_coordinates.status == "OK")
                {
                    // save lat and long returned from api call into local var
                    latAndlon = city_coordinates.results[0].geometry.location.lat.ToString() + ',' + city_coordinates.results[0].geometry.location.lng.ToString();
                    // use latAndlon var containing coordinates to make second api call
                    url = string.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0}&radius=16093&keyword=hotel&key={1}", latAndlon, api_key);
                    // download results
                    json = client.DownloadString(url);
                    // save all json info into store object
                    rootObject hotelSearch = (new JavaScriptSerializer()).Deserialize<rootObject>(json);
                    // if store is found
                    if (hotelSearch.status == "OK")
                    {
                        // find 5 hotels
                        int count = 0;
                        // itterates across the results found
                        for (int i = 0; i < hotelSearch.results.Length; i++)
                        {
                            // check if rating is equivalent to user input
                            if(hotelSearch.results[i].rating >= rating)
                            {
                                // add name, address, and rating to results
                                result.Add(hotelSearch.results[i].name);
                                result.Add(hotelSearch.results[i].vicinity);
                                result.Add(Convert.ToString(hotelSearch.results[i].rating));
                                // increment counter
                                count++;
                            }
                            // exit for loop once 5 hotels added to results list
                            if (count == 5) break;
                        }
                        // if response valid, but no hotels that match given rating
                        if(count == 0)
                        {
                            result.Add("Error: No hotels of given rating found");
                            return result;
                        }
                    }
                    // no stores were found
                    else
                    {
                        result.Add(string.Format("Error: There were no hotels found in {0}", city));
                        return result;
                    }
                    return result;

                }
                // invalid zipcode
                else
                {
                    result.Add(String.Format("Error: {0} was not found", city));
                    return result;
                }
            }
        }
    }
}

public class geoCodeObject
{
    public Result[] results { get; set; }
    public string status { get; set; }

    public class Result
    {
        public Geometry geometry { get; set; }

        public class Geometry
        {
            public Location location { get; set; }

            public class Location
            {
                public float lat { get; set; }
                public float lng { get; set; }
            }
        }
    }
}

// class used to make find place api call
public class rootObject
{
    public Result[] results { get; set; }
    public string status { get; set; }

    public class Result
    {
        public Geometry geometry { get; set; }
        public string name { get; set; }
        public string[] types { get; set; }
        public string vicinity { get; set; }
        public float rating { get; set; }



        public class Geometry
        {
            public Location location { get; set; }

            public class Location
            {
                public float lat { get; set; }
                public float lng { get; set; }
            }
        }
    }
}