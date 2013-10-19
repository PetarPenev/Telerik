<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebPage.aspx.cs" Inherits="_01.LinkMenu.WebPage" %>
<%@ Register src="LinkMenu.ascx" tagname="LinkMenu"
    tagprefix="userControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Link Menu</title>
    <style>
        a {
            display:inline-block;
            margin-right: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <userControls:LinkMenu runat="server" ID="UrlMenu" font="Arial" color="red">           
        </userControls:LinkMenu>
    </form>
</body>
</html>
