<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberLogin.aspx.cs" Inherits="WebApplication1.Account.MemberLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Member Login</h1>
        </div>
        <p>
            Username:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            Password:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <p>
            New user? <a href="Register.aspx">Register here.</a></p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Home" OnClick="Button2_Click" />
        </p>
    </form>
</body>
</html>
