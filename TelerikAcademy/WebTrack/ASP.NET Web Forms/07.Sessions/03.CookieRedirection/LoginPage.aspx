<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="_03.CookieRedirection.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox runat="server" ID="UserStatus" Enabled="false"></asp:TextBox>
        <asp:Button runat="server" ID="RedirectButton" OnClick="RedirectButton_Click" Text="Redirect" />
        <br />
        <asp:TextBox runat="server" ID="UsernameInput" MaxLength="20"></asp:TextBox>
        <asp:Button runat="server" ID="LoginButton" OnClick="LoginButton_Click" Text="Login" />
    </form>
</body>
</html>
