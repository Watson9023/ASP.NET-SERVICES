using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;

namespace airportCode
{
    public class Service1 : IService1
    {
        // this service gets valid city codes to be used in conjunction with the airport search operation, without these codes the search is impossible
        public List<string> getCityCodes(string origin, string dest)
        {
            // tream trailing and leading white space
            origin = origin.Trim();
            dest = dest.Trim();
            // url used to get origin city code
            string url = string.Format("https://api.skypicker.com//locations?term={0}&locale=en-US&location_types=city&limit=3&active_only=true", origin);
            // results stored here
            List<string> codes = new List<string>();
            // using web client to access web info
            using (WebClient client = new WebClient())
            {
                // download info from url
                string json = client.DownloadString(url);
                // deserialize
                Rootobject airportCode1 = (new JavaScriptSerializer()).Deserialize<Rootobject>(json);
                // try to access the first location, (checking to see if there are valid results from query)
                try
                {
                    // if success add the code to the list
                    codes.Add(airportCode1.locations[0].code);
                }
                catch
                {
                    // if exception, push error to list and return
                    codes.Add("Error: Invalid Origin");
                    codes.Add("");
                    return codes;
                }
                // url for destination city code, download and deserialize as before
                url = string.Format("https://api.skypicker.com//locations?term={0}&locale=en-US&location_types=city&limit=3&active_only=true", dest);
                json = client.DownloadString(url);
                Rootobject airportCode2 = (new JavaScriptSerializer()).Deserialize<Rootobject>(json);
                try
                {
                    // if there is a vlid location, push to list
                    codes.Add(airportCode2.locations[0].code);
                }
                catch
                {
                    // if exception, push error and return
                    codes.Add("Error: Invalid Destination");
                    return codes;
                }
            }
            // return results
            return codes;
        }
        // searches flights using the city codes from city code operation. Use date to narrow search
        public List<string> searchFlights(string origin, string dest, string date)
        {
            // trim leading and trailing whitespace
            origin = origin.Trim();
            dest = dest.Trim();
            date.Trim();
            // url for api call using origin, destination, and date of desired departure
            string url = string.Format("https://api.skypicker.com/flights?flyFrom={0}&to={1}&dateFrom={2}&dateTo={3}&typeFlight=oneway&adults=1&curr=USD&locale=en&limit=3&directFlights=1", origin, dest, date, date);
            // results returned here
            List<string> result = new List<string>();
            // use webclient to access web data
            using (WebClient client = new WebClient())
            {
                // try to download. If exception, the date is entered incorrectly
                try
                {
                    // download information from url
                    string json = client.DownloadString(url);
                    // deserialize json components
                    searchResponse search = (new JavaScriptSerializer()).Deserialize<searchResponse>(json);
                    // checks if there is data 
                    if (search.data.Length == 0)
                    {
                        // return empty no direct flights found, check the origin and destination
                        result.Add("Error: Either your destination/origin city is not recognized or there are no direct flights between those cities. Please try again");
                        return result;
                    }
                    // itterate the length of json data returned, add flight info
                    for (int i = 0; i < search.data.Length; i++)
                    {
                        // adds city origin data
                        result.Add(search.data[i].cityFrom);
                        result.Add(search.data[i].mapIdfrom);
                        result.Add(search.data[i].route[0].flyFrom);
                        // adds city destination data
                        result.Add(search.data[i].cityTo);
                        result.Add(search.data[i].mapIdto);
                        result.Add(search.data[i].route[0].flyTo);
                        // adds duration of flight
                        result.Add(search.data[i].fly_duration);
                        // adds depature and arrival times, converts from unix 
                        result.Add(convertUnixTime(search.data[i].dTime));
                        result.Add(convertUnixTime(search.data[i].aTime));
                        // adds price of flight
                        result.Add(Convert.ToString(search.data[i].price));
                        //adds flight no
                        result.Add(Convert.ToString(search.data[i].route[0].flight_no));
                        // updates url, the api refers to airlines by 2 characters that must be looked up in their 
                        // api
                        url = string.Format("https://api.skypicker.com/airlines");
                        // download as a string
                        json = client.DownloadString(url);
                        // itterate as a strong, issues downloading into json objects
                        for (int j = 3; j < json.Length; j++)
                        {
                            // if identifying tag = id
                            if (Convert.ToString(json[j]) + Convert.ToString(json[j + 1]) == "id")
                            {
                                // if the id of the current airline matches the airline id from user query
                                if (Convert.ToString(json[j + 6]) + Convert.ToString(json[j + 7]) == search.data[i].route[0].airline)
                                {
                                    //itterate across the name tag and save each char into a string that is then added to results
                                    string temp = "";
                                    for (int k = j + 32; json[k] != '"'; k++)
                                    {
                                        temp += json[k];
                                    }
                                    result.Add(temp);
                                    // airline id has been matched and the full name of the airline has been saved, we can now break
                                    break;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    // if exception, the date was invalid, return
                    result.Add("Error: Invalid Date");
                    return result;
                }
            }
            return result;
        }
        // used to convert unix time
        string convertUnixTime(int unixCode)
        {
            // Format new DateTime object to start at the UNIX Epoch
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            // Add the timestamp to be converted
            dateTime = dateTime.AddSeconds(unixCode);
            return Convert.ToString(dateTime);
        }

    }
}

// city codes classes
public class Rootobject
{
    public Location[] locations { get; set; }
    public Meta meta { get; set; }

    public class Location
    {
        public string id { get; set; }
        public int int_id { get; set; }
        public bool active { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string timezone { get; set; }
    }

    public class Meta
    {
        public Locale locale { get; set; }

        public class Locale
        {
            public string status { get; set; }
        }

    }

}



public class searchResponse
{
    public object[] connections { get; set; }
    public string currency { get; set; }
    public int _results { get; set; }
    public float currency_rate { get; set; }
    public string[] all_stopover_airports { get; set; }
    public Datum[] data { get; set; }
    public object[] ref_tasks { get; set; }
    public object[] refresh { get; set; }
    public int del { get; set; }
    public string[] all_airlines { get; set; }
    public int time { get; set; }
}



public class Seats
{
    public int infants { get; set; }
    public int passengers { get; set; }
    public int adults { get; set; }
    public int children { get; set; }
}



public class Datum
{
    public string mapIdfrom { get; set; }
    public bool has_airport_change { get; set; }
    public int price { get; set; }
    public string cityTo { get; set; }
    public string flyFrom { get; set; }
    public Countryfrom countryFrom { get; set; }
    public string mapIdto { get; set; }
    public int dTime { get; set; }
    public string[] airlines { get; set; }
    public string flyTo { get; set; }
    public int pnr_count { get; set; }
    public string fly_duration { get; set; }
    public string cityFrom { get; set; }
    public int aTime { get; set; }
    public Countryto countryTo { get; set; }
    public Route[] route { get; set; }

}

public class Duration
{
    public int total { get; set; }
    public int _return { get; set; }
    public int departure { get; set; }
}

public class Countryfrom
{
    public string code { get; set; }
    public string name { get; set; }
}

public class Countryto
{
    public string code { get; set; }
    public string name { get; set; }
}

public class Baglimit
{
    public int hand_width { get; set; }
    public int hand_length { get; set; }
    public int hold_weight { get; set; }
    public int hand_height { get; set; }
    public int hand_weight { get; set; }
}

public class Route
{
    public bool bags_recheck_required { get; set; }
    public string mapIdfrom { get; set; }
    public int flight_no { get; set; }
    public int original_return { get; set; }
    public float lngFrom { get; set; }
    public string flyTo { get; set; }
    public bool guarantee { get; set; }
    public string mapIdto { get; set; }
    public string source { get; set; }
    public string combination_id { get; set; }
    public string id { get; set; }
    public float latFrom { get; set; }
    public float lngTo { get; set; }
    public int aTimeUTC { get; set; }
    public int refresh_timestamp { get; set; }
    public int _return { get; set; }
    public int price { get; set; }
    public string cityTo { get; set; }
    public string vehicle_type { get; set; }
    public string flyFrom { get; set; }
    public int dTimeUTC { get; set; }
    public float latTo { get; set; }
    public int dTime { get; set; }
    public string found_on { get; set; }
    public string airline { get; set; }
    public string cityFrom { get; set; }
    public int aTime { get; set; }
}




