using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;

namespace StoreLocator
{
    public class Service1 : IService1
    {
        public string findNearestStore(string zipcode, string storeName)
        {
            // trim leading and trailing whitespace
            zipcode = zipcode.Trim();
            storeName = storeName.Trim();
            // check if empty
            if(String.IsNullOrWhiteSpace(zipcode) || String.IsNullOrWhiteSpace(storeName))
            {
                return "Error: Check Inputs";
            }
            // api key for google services, connected to my creditcard, please be kind :(
            string api_key = "AIzaSyBdq_oSqZuIU52qxSRaC8gHAPBtEafDAWM";
            // formatted url for downloading json data
            string url = string.Format("https://maps.googleapis.com/maps/api/geocode/json?components=postal_code:{0}&key={1}", zipcode, api_key);
            // var declaration used to call second service
            string latAndlon;
            using (WebClient client = new WebClient())
            {
                //download data into string
                string json = client.DownloadString(url);
                // deserialize into zip object
                ZipObject zip_coordinates = (new JavaScriptSerializer()).Deserialize<ZipObject>(json);
                // if zip received is valid
                if (zip_coordinates.status == "OK")
                {
                    // save lat and long returned from api call into local var
                    latAndlon = zip_coordinates.results[0].geometry.location.lat.ToString() + ',' + zip_coordinates.results[0].geometry.location.lng.ToString();
                    // use latAndlon var containing coordinates to make second api call
                    url = string.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0}&radius=16093&keyword={1}&key={2}", latAndlon, storeName, api_key);
                    // download results
                    json = client.DownloadString(url);
                    // save all json info into store object
                    StoreObject store_info = (new JavaScriptSerializer()).Deserialize<StoreObject>(json);
                    // if store is found
                    if (store_info.status == "OK")
                    {
                        // itterates across the results found
                        for(int i = 0; i < store_info.results.Length; i++)
                        {
                            // checks to see if there is an element in types == store
                            // ensures that the place searched for is indeed a store
                            for(int j = 0; j < store_info.results[i].types.Length; j++)
                            {
                                // if there is a store
                                if(store_info.results[i].types[j] == "store")
                                {
                                    return store_info.results[i].vicinity;
                                }
                            }
                        }
                        // if storename is not classified as a store, return this 
                        return String.Format("Error: {0} is not a store", storeName);
                    }
                    // no stores were found
                    else
                    {
                        return String.Format("Error: There was no store by the name {0} found", storeName);
                    }

                }
                // invalid zipcode
                else
                {
                    return String.Format("Error: {0} is an invalid ZIP Code", zipcode);
                }
            }
        }
    }

    // classes for finding lat and lon from zipcode (geocoding)
    public class ZipObject
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
    public class StoreObject
    {
        public Result[] results { get; set; }
        public string status { get; set; }

        public class Result
        {
            public Geometry geometry { get; set; }
            public string name { get; set; }
            public string[] types { get; set; }
            public string vicinity { get; set; }

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
}
