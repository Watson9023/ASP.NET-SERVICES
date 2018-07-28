using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class Members : System.Web.UI.Page
    {
        // class for saving cookie
        public class Flight
        {
            public string _cityFrom;
            public string _fromCode;
            public string _cityTo;
            public string _toCode;
            public string _duration;
            public string _departure;
            public string _arrival;
            public string _price;
            public string _flight_no;
            public string _airline;
            //ctor for cookie
            public Flight(string cityFrom, string fromCode, string cityTo, string toCode, string duration, string departure, string arrival, string price, string flight_no, string airline)
            {
                _cityFrom = cityFrom;
                _fromCode = fromCode;
                _cityTo = cityTo;
                _toCode = toCode;
                _duration = duration;
                _departure = departure;
                _arrival = arrival;
                _price = price;
                _flight_no = flight_no;
                _airline = airline;
            }

        }
        // when page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            // if there are cookies, display the username at the top of page
            HttpCookie myCookie = Request.Cookies["key"];
            if(myCookie != null)
            {
                Session["Username"] = myCookie["Username"];
                Label1.Text = Session["Username"].ToString();
            }
            // if user saved flights in session, display flight info
            try
            {
                Flight temp = (Flight)Session["flight"];
                Label2.Text = temp._cityFrom;
                Label3.Text =   temp._fromCode;
                Label4.Text =   temp._cityTo;
                Label5.Text =   temp._toCode;
                Label6.Text =   temp._duration;
                Label7.Text =   temp._departure;
                Label8.Text =   temp._arrival;
                Label9.Text =   temp._price;
                Label10.Text =  temp._flight_no;
                Label11.Text = temp._airline;
            }
            catch
            {

            }
        }
        // sign out button
        protected void Button1_Click(object sender, EventArgs e)
        {
            // clear session and set cookie to expire
            Session.Clear();
            HttpCookie myCookie = Request.Cookies["key"];
            if(myCookie != null)
            {
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            // sign out
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // open proxy
            SearchFlights.Service1Client client = new SearchFlights.Service1Client();
            // call operation
            string[] result = client.getCityCodes(TextBox1.Text, TextBox2.Text);
            string[] flight_result = client.searchFlights(result[0], result[1], TextBox3.Text);
            // error
            if (flight_result.Length == 1)
            {
                // first result
                Label2.Text = flight_result[0];
                Label2.Text = "";
                 Label3.Text = result[0];
                 Label4.Text ="";
                 Label5.Text = result[1];
                 Label6.Text ="";
                 Label7.Text ="";
                 Label8.Text ="";
                 Label9.Text ="";
                 Label10.Text="";
                 Label11.Text = "";
            }
            // no error
            else
            {
                Label2.Text = flight_result[0];
                Label3.Text = result[0];
                Label4.Text = flight_result[3];
                Label5.Text = result[1];
                Label6.Text =flight_result[6];
                Label7.Text =flight_result[7];
                Label8.Text =flight_result[8];
                Label9.Text = flight_result[9];
                Label10.Text = flight_result[10];
                Label11.Text = flight_result[11];
                // find hotels at the destination
                HotelService.Service1Client clientel = new HotelService.Service1Client();
                string[] hotel = clientel.findHotel(TextBox2.Text, 3);
                //error handling
                if(hotel.Length == 1)
                {
                    // display error message
                    Label12.Text = hotel[0];
                }
                else
                {
                    // display hotel info
                    Label12.Text = hotel[0] + " located at " + hotel[1] + " rating " + hotel[2];
                }
            }


        }
        // save flight info
        protected void Button3_Click(object sender, EventArgs e)
        {
            // used for ctor
            string cityFrom = Label2.Text;
            string fromCode = Label3.Text;
            string cityTo = Label4.Text;
            string toCode = Label5.Text;
            string duration = Label6.Text;
            string departure = Label7.Text;
            string arrival = Label8.Text;
            string price = Label9.Text;
            string flight_no = Label10.Text;
            string airline = Label11.Text;
            // use ctor and save to session
            Flight aFlight = new Flight(cityFrom, fromCode, cityTo, toCode, duration, departure, arrival, price, flight_no, airline);
            Session["flight"] = aFlight;
        }
        // go home
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }
    }
}