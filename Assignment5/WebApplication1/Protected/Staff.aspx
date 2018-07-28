<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="WebApplication1.Protected.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Staff</h1>
    <form id="form1" runat="server">
    <h2>Welcome 
        <asp:Label ID="Label1" runat="server"></asp:Label>
        </h2>
        <p>This is the staff page. Only staff members may access this page.</p>
        <p>List of all registered members</p>
        <p>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Home" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign Out" />
        <br />
    </form>
</body>
</html>
