<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumberGenerator.aspx.cs" Inherits="_02.RandomNumberGeneratorWithServerControls.RandomNumberGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="RandomGeneratorForm" runat="server">
        <asp:TextBox id="IntervalStart" runat="server" placeholder="Enter interval start."></asp:TextBox>
        <asp:TextBox id="IntevalEnd" runat="server" placeholder="Enter interval end."></asp:TextBox>
        <asp:Button id="GenerateRandomNumberButton" Text="Generate" runat="server" onclick="GenerateRandomNumber" />
        <asp:TextBox runat="server" text="" id="OutputDiv" visible="false"></asp:TextBox>
    </form>
</body>
</html>
