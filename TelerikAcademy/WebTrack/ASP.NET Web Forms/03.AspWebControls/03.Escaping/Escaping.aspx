<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="_03.Escaping.Escaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="EscapingForm" runat="server">
        <asp:TextBox ID="TextToBeEscaped" runat="server"></asp:TextBox>
        <asp:Button Text="Display text" runat="server" ID="DisplayTextButton" OnClick="DisplayText"/>
        <asp:TextBox runat="server" ID="OutputTextBox" Visible="false"></asp:TextBox>
        <asp:Label runat="server" ID="LabelOutput" Visible="false"></asp:Label>
    </form>
</body>
</html>
