<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WeatherServiceTryIt.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <font size = "25"><a href="http://webstrar56.fulton.asu.edu/index.html">return to main list</a></font><br />
            <br />
            NOTE: GitHub uses local services, not the services stored on ASU webstrar server.<br />
            <br />
            <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Required Services"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Weather Service Try It"></asp:Label>
        </div>
        <asp:Label ID="Label2" runat="server" Text="http://webstrar56.fulton.asu.edu/Page0/Service1.svc?wsdl"></asp:Label>
        <p>
            Description: Takes a zip code and returns a list of strings describing the weather in that location. If invalid zip code is returned, list is empty.</p>
        <p>
            Method: Weather5day</p>
        <p>
            Input: String
        </p>
        <p>
            Output: List&lt;string&gt;</p>
        <p>
            Zip Code:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server">Enter Valid ZIP</asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Invoke" />
        </p>
        <asp:Label ID="Label3" runat="server" Text="Forecast    " Width="100px"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Forecast    " Width="100px"></asp:Label>
        <asp:Label ID="Label5" runat="server" Text="Forecast    " Width="100px"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Forecast    " Width="100px"></asp:Label>
        <asp:Label ID="Label7" runat="server" Text="Forecast  " Width="100px"></asp:Label>
        <p>
            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="X-Large" Text="FindNearestStore Service Try It"></asp:Label>
        </p>
        <p>
            http://webstrar56.fulton.asu.edu/Page1/Service1.svc?wsdl</p>
        <p>
            Description: Takes a zip code and a store name and finds the closest store to that zip code within a 10 mile radius. Returns the address of the nearest store.</p>
        <p>
            Method: findNearestStore</p>
        <p>
            Input: String zipcode &amp; String store name</p>
        <p>
            Output: string address</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server">Enter ZIP Code</asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server">Enter Store Name</asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Invoke" />
        </p>
        <p>
            Address:&nbsp;
            <asp:Label ID="Label9" runat="server" Text="..." Width="350px"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Elective Services "></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="X-Large" Text="FindHotelService Try It"></asp:Label>
        </p>
        <p>
            http://webstrar56.fulton.asu.edu/Page2/Service1.svc?wsdl</p>
        <p>
            Description: Takes a city name and a desired rating and finds the closest store to that zip code within a 10 mile radius. Returns the hotel name, address, and rating</p>
        <p>
            Method: findHotel</p>
        <p>
            Input: String city name &amp; float rating</p>
        <p>
            Output: List of hotels, their address and their rating</p>
        <asp:TextBox ID="TextBox4" runat="server">Enter City Name</asp:TextBox>
        <asp:TextBox ID="TextBox5" runat="server">Enter Rating (0-5)</asp:TextBox>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Invoke" />
        <br />
        Hotel:
        <asp:Label ID="Label11" runat="server" Text="..." Width="350px"></asp:Label>
        Address:<asp:Label ID="Label16" runat="server" Text="..." Width="250px"></asp:Label>
        Rating<asp:Label ID="Label21" runat="server" Text="..."></asp:Label>
        <br />
        Hotel:<asp:Label ID="Label12" runat="server" Text="..." Width="350px"></asp:Label>
&nbsp;Address:<asp:Label ID="Label17" runat="server" Text="..." Width="250px"></asp:Label>
        Rating:<asp:Label ID="Label22" runat="server" Text="..."></asp:Label>
        <br />
        Hotel:<asp:Label ID="Label13" runat="server" Text="..." Width="350px"></asp:Label>
&nbsp;Address:<asp:Label ID="Label18" runat="server" Text="..." Width="250px"></asp:Label>
        Rating:<asp:Label ID="Label23" runat="server" Text="..."></asp:Label>
        <br />
        Hotel:
        <asp:Label ID="Label14" runat="server" Text="..." Width="350px"></asp:Label>
        Address:<asp:Label ID="Label19" runat="server" Text="..." Width="250px"></asp:Label>
        Rating:<asp:Label ID="Label24" runat="server" Text="..."></asp:Label>
        <br />
        Hotel:
        <asp:Label ID="Label15" runat="server" Text="..." Width="350px"></asp:Label>
        Address:<asp:Label ID="Label20" runat="server" Text="..." Width="250px"></asp:Label>
        Rating:<asp:Label ID="Label25" runat="server" Text="..."></asp:Label>
        <p>
            <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Get City Codes Service Try It"></asp:Label>
        </p>
        <p>
            http://webstrar56.fulton.asu.edu/Page3/Service1.svc?wsdl</p>
        <p>
            Description: Takes two city names and returns the appropriate city codes to use in conjunction with the flight search operation</p>
        <p>
            Method: getCityCodes</p>
        <p>
            Input: String origin city name &amp; string destination city name</p>
        <p>
            Output: 2 strings in a list containing approrpiate city codes to be used for the flight search operation</p>
        <asp:TextBox ID="TextBox6" runat="server">Origin City Name</asp:TextBox>
        <asp:TextBox ID="TextBox7" runat="server">Dest City Name</asp:TextBox>
        <asp:Button ID="Button4" runat="server" Text="Invoke" OnClick="Button4_Click1" />
        <br />
        Destination&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label29" runat="server" Text="..."></asp:Label>
        <br />
        Origin:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label30" runat="server" Text="..."></asp:Label>
        <p>
            <asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Search Flights Service Try It"></asp:Label>
        </p>
        <p>
            http://webstrar56.fulton.asu.edu/Page3/Service1.svc?wsdl</p>
        <p>
            Description: Takes two city names and a date in the format mm/dd/yyyy. Searches for direct flights between the two cities during that date and returns flight information. Use city codes from get city codes service in order for service to work. This service will be used in conjunction with the get city codes service when the application logic is implemented.</p>
        <p>
            Method: searchFlights</p>
        <p>
            Input: String origin city name, string destination city name, string date in the form mm/dd/yyyy</p>
        <p>
            Output: List of 3 sets of strings containing: </p>
        <p>
            [0] cityFrom [1] geographic location from [2] flyFrom (airport code) [3] cityTo [4] geographic location to&nbsp; [5] flyTo (airport code) [6] flight duration [7] departure time [8] arrival time [9] price [10] flight no [11] airline name
        </p>
        <p>
            <asp:TextBox ID="TextBox8" runat="server">City Code Origin</asp:TextBox>
            <asp:TextBox ID="TextBox9" runat="server">City Code Dest</asp:TextBox>
            <asp:TextBox ID="TextBox10" runat="server">Date: mm/dd/yyyy</asp:TextBox>
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Invoke" />
        </p>
        <p>
            From:
            <asp:Label ID="Label32" runat="server" Text="..." Width="150px"></asp:Label>
            Code:
            <asp:Label ID="Label33" runat="server" Text="..."></asp:Label>
        </p>
        <p>
            To:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label34" runat="server" Text="..." Width="150px"></asp:Label>
            Code:
            <asp:Label ID="Label35" runat="server" Text="..."></asp:Label>
        </p>
        <p>
            Duration:
            <asp:Label ID="Label36" runat="server" Text="..." Width="100px"></asp:Label>
        </p>
        <p>
            Departure Time:
            <asp:Label ID="Label37" runat="server" Text="..." Width="250px"></asp:Label>
        </p>
        <p>
            Arrival Time:
            <asp:Label ID="Label38" runat="server" Text="..." Width="250px"></asp:Label>
        </p>
        <p>
            Price:
            <asp:Label ID="Label39" runat="server" Text="..." Width="50px"></asp:Label>
        </p>
        <p>
            Flight No:
            <asp:Label ID="Label40" runat="server" Text="..." Width="50px"></asp:Label>
        </p>
        <p>
            Airline:<asp:Label ID="Label41" runat="server" Text="..." Width="350px"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            From:
            <asp:Label ID="Label42" runat="server" Text="..." Width="150px"></asp:Label>
            Code:
            <asp:Label ID="Label43" runat="server" Text="..."></asp:Label>
        </p>
        <p>
            To:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label44" runat="server" Text="..." Width="150px"></asp:Label>
            Code:
            <asp:Label ID="Label45" runat="server" Text="..."></asp:Label>
        </p>
        <p>
            Duration:
            <asp:Label ID="Label46" runat="server" Text="..." Width="100px"></asp:Label>
        </p>
        <p>
            Departure Time:
            <asp:Label ID="Label47" runat="server" Text="..." Width="250px"></asp:Label>
        </p>
        <p>
            Arrival Time:
            <asp:Label ID="Label48" runat="server" Text="..." Width="250px"></asp:Label>
        </p>
        <p>
            Price:
            <asp:Label ID="Label49" runat="server" Text="..." Width="50px"></asp:Label>
        </p>
        <p>
            Flight No:
            <asp:Label ID="Label50" runat="server" Text="..." Width="50px"></asp:Label>
        </p>
        <p>
            Airline:<asp:Label ID="Label51" runat="server" Text="..." Width="350px"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            From:
            <asp:Label ID="Label52" runat="server" Text="..." Width="150px"></asp:Label>
            Code:
            <asp:Label ID="Label53" runat="server" Text="..."></asp:Label>
        </p>
        <p>
            To:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label54" runat="server" Text="..." Width="150px"></asp:Label>
            Code:
            <asp:Label ID="Label55" runat="server" Text="..."></asp:Label>
        </p>
        <p>
            Duration:
            <asp:Label ID="Label56" runat="server" Text="..." Width="100px"></asp:Label>
        </p>
        <p>
            Departure Time:
            <asp:Label ID="Label57" runat="server" Text="..." Width="250px"></asp:Label>
        </p>
        <p>
            Arrival Time:
            <asp:Label ID="Label58" runat="server" Text="..." Width="250px"></asp:Label>
        </p>
        <p>
            Price:
            <asp:Label ID="Label59" runat="server" Text="..." Width="50px"></asp:Label>
        </p>
        <p>
            Flight No:
            <asp:Label ID="Label60" runat="server" Text="..." Width="50px"></asp:Label>
        </p>
        <p>
            Airline:<asp:Label ID="Label61" runat="server" Text="..." Width="350px"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label62" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Restful Service "></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label63" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Temperature Convert Service Try It"></asp:Label>
        </p>
        <p>
            <a href="http://webstrar56.fulton.asu.edu/Page4/Service1.svc">http://webstrar56.fulton.asu.edu/Page4/Service1.svc</a></p>
        <p>
            /convert?cel=x&amp;num=y</p>
        <p>
            Description: Takes two integers, one is used to indicate whether the temperature is in celsius, the other is the temperature that will be converted. Returns the converted temperature (either in celsius or fahrenheit)</p>
        <p>
            Method: tempConvert</p>
        <p>
            Input: int isCelsius int temperature</p>
        <p>
            Output: Temperature</p>
        <p>
            <asp:TextBox ID="TextBox11" runat="server" Width="175px">Is Celsius? (1 = yes, 0 = no)</asp:TextBox>
            <asp:TextBox ID="TextBox12" runat="server">Temperature</asp:TextBox>
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Invoke" />
        </p>
        <p>
            <asp:Label ID="Label64" runat="server" Text="Result"></asp:Label>
        </p>
    </form>
</body>
</html>
