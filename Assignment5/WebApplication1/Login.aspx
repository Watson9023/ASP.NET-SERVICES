<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Staff Login</h1>
        </div>
        <p>
            Username:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            Password:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Return" />
        </p>
    </form>
</body>
</html>
