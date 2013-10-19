<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NameDisplay.aspx.cs" Inherits="NameDisplay.NameDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #NameValue, #GreetingText {
            min-width:500px;
        }    
    </style>
</head>
<body>
    <form id="nameDisplay" runat="server">
        <asp:TextBox ID="NameValue" runat="server" placeholder="Please enter your name"></asp:TextBox>
        <br />
        <asp:Button ID="ShowNameButton" Text="Show name" OnClick="ShowName" runat="server" />
        <br />
        <asp:TextBox ID="GreetingText" runat="server" Enabled="false"></asp:TextBox>
    </form>
</body>
</html>
