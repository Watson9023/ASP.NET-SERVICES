<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>CSE 445</h1>
        <p class="lead">Assignment 5:</p>
        <p class="lead">Service Directory can be found on the about page.</p>
        <p class="lead">Staff login:</p>
        <p class="lead">username: Amy Password:123</p>
        <p class="lead">Admin login:</p>
        <p class="lead">username: Jon Password: 123</p>
        <p class="lead">Either of these credentials may be used to access the Staff pages. </p>
        <p class="lead">Use the buttons below to self-register. From the members page, the user may access the </p>
        <p class="lead">Trip planning services.</p>
        <p class="lead">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Member Register" />
            <asp:Button ID="Button2" runat="server" Text="Member Login" OnClick="Button2_Click" />
        </p>
        <p class="lead">
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Staff Page" Width="182px" />
            <asp:Button ID="Button4" runat="server" OnClick="Button3_Click" Text="Staff Login" Width="153px" />
        </p>
    </div>
</asp:Content>
