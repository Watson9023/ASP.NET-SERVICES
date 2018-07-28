<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="WebApplication1.Account.Members" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </h1>
            <p>This is our members only page. From here you can access our services at ease. Please take a look.</p>
            <p>Find the cheapest direct flight available. Simply enter the city you wish to depart from and your destination and we&#39;ll find the cheapest flight available.</p>
            <p>
                <asp:TextBox ID="TextBox1" runat="server">Departure</asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server">Destination</asp:TextBox>
                <asp:TextBox ID="TextBox3" runat="server">Date: MM/DD/YYYY</asp:TextBox>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
            </p>
            <p>From:
                <asp:Label ID="Label2" runat="server" Width="150px"></asp:Label>
                Code:
                <asp:Label ID="Label3" runat="server" Width="150px"></asp:Label>
            </p>
            <p>To:&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Width="150px"></asp:Label>
                Code:
                <asp:Label ID="Label5" runat="server" Width="150px"></asp:Label>
            </p>
            <p>Duration:
                <asp:Label ID="Label6" runat="server" Width="150px"></asp:Label>
            </p>
            <p>Departure Time:
                <asp:Label ID="Label7" runat="server" Width="150px"></asp:Label>
            </p>
            <p>Arrival Time:
                <asp:Label ID="Label8" runat="server" Width="150px"></asp:Label>
            </p>
            <p>Price:
                <asp:Label ID="Label9" runat="server" Width="150px"></asp:Label>
            </p>
            <p>Flight No:
                <asp:Label ID="Label10" runat="server" Width="150px"></asp:Label>
            </p>
            <p>Airline:
                <asp:Label ID="Label11" runat="server" Width="150px"></asp:Label>
            </p>
            <p>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Save Flight Info" />
            </p>
            <p>
                Did you know ...</p>
            <p>
                This hotel has openings in your destination...</p>
            <p>
                <asp:Label ID="Label12" runat="server"></asp:Label>
            </p>
        </div>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Home" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign Out" />
    </form>
</body>
</html>
