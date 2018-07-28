<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Protected.administrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Administrator</h1>
            <h2>Welcome, 
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </h2>
            <p>This is the administrators page.
            Only administrators may enter.</p>
            <p>Staff and Administration List</p>
            <p>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </p>
        </div>

        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Home" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign Out" />
    </form>
</body>
</html>
