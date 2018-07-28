<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Account.Register" %>
<%@ Register TagPrefix = "verify" TagName="ImageVerifyControl" src="ucImage.ascx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Member Registration</h1>
            <p>Username:
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </p>
            <p>Password:
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </p>
            <asp:Panel ID="Panel1" runat="server">
                <verify:ImageVerifyControl ID="ImageVerifyControl1" Visible="true" runat="server" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get New Image" />
            </asp:Panel>
        </div>
        <p>
            Please enter the text above into the following textbox</p>
        <p>
            <asp:TextBox ID="TextBox3" runat="server" Width="140px"></asp:TextBox>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Register Account" />
    </form>
</body>
</html>
