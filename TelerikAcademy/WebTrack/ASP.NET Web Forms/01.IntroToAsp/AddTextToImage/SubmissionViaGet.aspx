<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmissionViaGet.aspx.cs" Inherits="AddTextToImage.SubmissionViaGet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formGet" runat="server" action="request.img" method="get">
     <label for="imageText">Text of image:</label>
    <asp:TextBox ID="imageText" runat="server"></asp:TextBox>
    <asp:Button runat="server" Text="Send Text"/>
    </form>
</body>
</html>
