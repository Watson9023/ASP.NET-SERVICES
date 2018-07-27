using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeatherServiceTryIt
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // button invokes the weather reference method
        protected void Button1_Click(object sender, EventArgs e)
        {
            // open proxy
            WeatherReference.Service1Client client = new WeatherReference.Service1Client();
            // save proxy results into string array
            string[] result = client.Weather5day(TextBox1.Text);
            // if length of array is 0, invalid zip
            if(result.Length == 0)
            {
                // display invalid zip in label, clear other labels
                Label3.Text = "Invalid Zip";
                Label4.Text = "";
                Label5.Text = "";
                Label6.Text = "";
                Label7.Text = "";
            }
            else
            {
                // if zip code accepted without error,
                // display results in labels
                Label3.Text = result[0];
                Label4.Text = result[1];
                Label5.Text = result[2];
                Label6.Text = result[3];
                Label7.Text = result[4];
            }
        }
        // method invokes the find nearest store method
        protected void Button2_Click(object sender, EventArgs e)
        {
            // open proxy
            StoreReference.Service1Client client = new StoreReference.Service1Client();
            // save result of method call to the string result
            string result = client.findNearestStore(TextBox2.Text, TextBox3.Text);
            // display the contents of the string into the label
            Label9.Text = result;
        }
        // method invokes the find hotel service
        protected void Button3_Click(object sender, EventArgs e)
        {
            // open proxy
            HotelReference.Service1Client client = new HotelReference.Service1Client();
            // convert input to float
            float temp = (float)Convert.ToDouble(TextBox5.Text);
            // pass params
            string[] result = client.findHotel(TextBox4.Text, temp);
            // length = 1 means there has been an error, clear all labels and place error in first label
            if(result.Length == 1)
            {
                // first row
                Label11.Text = result[0];
                Label16.Text = "...";
                Label21.Text = "...";
                // second row  
                Label12.Text = "...";
                Label17.Text = "...";
                Label22.Text = "...";
                // third row   
                Label13.Text = "...";
                Label18.Text = "...";
                Label23.Text = "...";
                // fourth row  
                Label14.Text = "...";
                Label19.Text = "...";
                Label24.Text = "...";
                // fifth row   
                Label15.Text = "...";
                Label20.Text = "...";
                Label25.Text = "...";
            }
            // no error, display all info
            else
            {
                // first row
                Label11.Text = result[0];
                Label16.Text = result[1];
                Label21.Text = result[2];
                // second row
                if(result.Length >= 4)
                {
                    Label12.Text = result[3];
                    Label17.Text = result[4];
                    Label22.Text = result[5];
                }
                // third row
                if(result.Length >= 7)
                {
                    Label13.Text = result[6];
                    Label18.Text = result[7];
                    Label23.Text = result[8];
                }
                // fourth row
                if(result.Length >= 10)
                {
                    Label14.Text = result[9];
                    Label19.Text = result[10];
                    Label24.Text = result[11];
                }
                // fifth row
                if(result.Length >= 13)
                {
                    Label15.Text = result[12];
                    Label20.Text = result[13];
                    Label25.Text = result[14];
                }
            }
        }
        // get city codes operation
        protected void Button5_Click(object sender, EventArgs e)
        {
            // open proxy
            FlightReference.Service1Client client = new FlightReference.Service1Client();
            // call operation
            string[] result = client.searchFlights(TextBox8.Text, TextBox9.Text, TextBox10.Text);
            // if length == 1, error. Clear labels and display error message in first label
            if(result.Length == 1)
            {
                // first result
                Label32.Text = result[0];
                Label33.Text = "...";
                Label34.Text = "...";
                Label35.Text = "...";
                Label36.Text = "...";
                Label37.Text = "...";
                Label38.Text = "...";
                Label39.Text = "...";
                Label40.Text = "...";
                Label41.Text = "...";
                // second result
                Label42.Text = result[0];
                Label43.Text = "...";
                Label44.Text = "...";
                Label45.Text = "...";
                Label46.Text = "...";
                Label47.Text = "...";
                Label48.Text = "...";
                Label49.Text = "...";
                Label50.Text = "...";
                Label51.Text = "...";
                // third result
                Label52.Text = result[0];
                Label53.Text = "...";
                Label54.Text = "...";
                Label55.Text = "...";
                Label56.Text = "...";
                Label57.Text = "...";
                Label58.Text = "...";
                Label59.Text = "...";
                Label60.Text = "...";
                Label61.Text = "...";
            }
            else
            {
                // first result
                Label32.Text = result[0];
                Label33.Text = result[2];
                Label34.Text = result[3];
                Label35.Text = result[5];
                Label36.Text = result[6];
                Label37.Text = result[7];
                Label38.Text = result[8];
                Label39.Text = result[9];
                Label40.Text = result[10];
                Label41.Text = result[11];
                // second result
                if(result.Length >= 13)
                {
                    Label42.Text = result[12];
                    Label43.Text = result[14];
                    Label44.Text = result[15];
                    Label45.Text = result[17];
                    Label46.Text = result[18];
                    Label47.Text = result[19];
                    Label48.Text = result[20];
                    Label49.Text = result[21];
                    Label50.Text = result[22];
                    Label51.Text = result[23];
                }

                // third result
                if(result.Length >= 25)
                {
                    Label52.Text = result[24];
                    Label53.Text = result[26];
                    Label54.Text = result[27];
                    Label55.Text = result[29];
                    Label56.Text = result[30];
                    Label57.Text = result[31];
                    Label58.Text = result[32];
                    Label59.Text = result[33];
                    Label60.Text = result[34];
                    Label61.Text = result[35];
                }

            }

        }
        //restful service
        protected void Button6_Click(object sender, EventArgs e)
        {
            // create base uri
            Uri baseUri = new Uri("http://webstrar56.fulton.asu.edu/page4/Service1.svc");
            // set template for binding
            UriTemplate myTemplate = new UriTemplate("convert?cel={celsius}&num={temp}");
            // bind user input
            Uri completeUri = myTemplate.BindByPosition(baseUri, TextBox11.Text, TextBox12.Text);
            // open channel
            WebClient channel = new WebClient();
            // download dataand stream, serialize xml data and save to result
            byte[] abc = channel.DownloadData(completeUri);
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(int));
            int result = (int)obj.ReadObject(strm);
            // print result
            Label64.Text = Convert.ToString(result);
        }
        // city codes operation
        protected void Button4_Click1(object sender, EventArgs e)
        {
            // open proxy
            FlightReference.Service1Client client = new FlightReference.Service1Client();
            // call operation
            string[] result = client.getCityCodes(TextBox6.Text, TextBox7.Text);
            // display data
            Label29.Text = result[0];
            Label30.Text = result[1];
        }
    }
}