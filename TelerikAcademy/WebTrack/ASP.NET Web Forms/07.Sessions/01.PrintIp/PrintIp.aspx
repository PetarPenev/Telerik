<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintIp.aspx.cs" Inherits="_01.PrintIp.PrintIp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formIp" runat="server">
        <label for="IpLiteral" >Ip Address:</label>
        <asp:Literal runat="server" ID="IpLiteral"></asp:Literal>
        <br />
        <label for="BrowserLiteral">Browser:</label>
        <asp:Literal runat="server" ID="BrowserLiteral"></asp:Literal>
    </form>
</body>
</html>
