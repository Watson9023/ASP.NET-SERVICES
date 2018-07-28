<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Jonathan Reyes' Travel App.</h2>
    <h3>Service Directory:</h3>
    <p>The application allows users to search for flights between 2 destinations on some given future date. Once a flight is found, the application will suggest a hotel in the destination that might be appealing. </p>
    <p>The user must register to use this service. Registration can be accessed from the MemberRegistration page which is easily accesible from the Default (main-page)</p>
    Additionally, the staff and members page allows a staff or member to look at a list of self-registered members and staff/admin profiles respectively.
    <style>
	.demo {
		width:100%;
		border:1px solid #C0C0C0;
		border-collapse:collapse;
		padding:5px;
	}
	.demo th {
		border:1px solid #C0C0C0;
		padding:5px;
		background:#F0F0F0;
	}
	.demo td {
		border:1px solid #C0C0C0;
		padding:5px;
	}
</style>
<table class="demo">
	<caption></caption>	<caption>Project Developed by: Jonathan Reyes</caption>
	<thead>
	<tr>
		<th>Provider Name</th>
		<th>Service name<br>i/o types</th>
		<th>Service Description</th>
		<th>Resources Used to Implement</th>
		<th>Try It</th>
	</tr>	</thead>	<tbody>
	<tr>
		<td>&nbsp;Jonathan Reyes</td>
		<td>Find Hotel Service<br>In:<br>String City Name, String Rating<br>Out:<br>String List of Hotel names,<br>addresses, ratings</td>
		<td>&nbsp;Finds 5 hotels within a 10 mile radius of a city's center that&nbsp;<br>&nbsp;are at least the same rating inputted by the user or higher.<br>Returns their address, name, and rating for viewing.</td>
		<td>&nbsp;https://maps.googleapis.com/maps/api/geocode<br>https://maps.googleapis.com/maps/api/place<br></td>
		<td>App Logic</td>
	</tr>
	<tr>
		<td>&nbsp;Jonathan Reyes</td>
		<td>Get City Codes<br>In: <br>String origin &amp; dest city name<br>Out:<br>String List containing 2 members<br>The string codes of both cities.</td>
		<td>&nbsp;User inputs the names of 2 cities and the service will find their<br>&nbsp;corresponding code to use with the api. The api requires city&nbsp;<br>codes match its internal system so this service is intended for<br>use in conjunction with the searchFlight service.</td>
		<td>&nbsp;https://api.skypicker.com//locations?</td>
		<td>App Logic</td>
	</tr>
	<tr>
		<td>&nbsp;Jonathan Reyes</td>
		<td>searchFlights Service<br>In:&nbsp;<br>String Origin City's Code<br>String Dest City's Code<br>String Date<br>Out:<br>String list of cheapest flights<br>available that date to the given&nbsp;<br>location.</td>
		<td>&nbsp;The user takes the city codes returned by the city codes service,<br>&nbsp;and inputs them alongside a date. The service will search for the<br>cheapest available direct flights between the two cities and return<br>accompanying information about those flights.</td>
		<td>&nbsp;https://api.skypicker.com/flights?</td>
		<td>App Logic</td>
	</tr>
        	<tr>
		<td>&nbsp;Jonathan Reyes</td>
		<td>VerifierString<br>In:&nbsp;<br>String length<br>Out:<br>String random string of given&nbsp;<br>length<br />
            Stream GetImage(string mystring)<br />
            out: URI of image containing input string<br />
            .</td>
		<td>&nbsp;The user generates a random string using the verifier string.<br />
            <br />
            The user takes the verifier string return string and uses it to get an image</td>
		<td><a href="http://neptune.fulton.ad.asu.edu/WSRepository/">http://neptune.fulton.ad.asu.edu/WSRepository/</a><br />
            Services/ImageVerifierSvc/TryIt.aspx</td>
		<td>&nbsp;<a href="http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifierSvc/TryIt.aspx">TryIt</a></td>
	</tr>
               	<tr>
		<td>&nbsp;Jonathan Reyes</td>
		<td>Cryption:<br />
            String Encrypt(string)<br />
            String Decrypt(string<br />
            .</td>
		<td>Encrypts and Decrypts a string. The input string will be transformed accordingly</td>
		<td><a href="http://neptune.fulton.ad.asu.edu/WSRepository/">http://neptune.fulton.ad.asu.edu/WSRepository"</a><br />
            Services/EncryptionTryIt/Sender.aspx</td>
		<td>&nbsp;<a href="http://neptune.fulton.ad.asu.edu/WSRepository/Services/EncryptionTryIt/Sender.aspx">TryIt</a></td>
	</tr>
	<tbody>
</table>
</asp:Content>
