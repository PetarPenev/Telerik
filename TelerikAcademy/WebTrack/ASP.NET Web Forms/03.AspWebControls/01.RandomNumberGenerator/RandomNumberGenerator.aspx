<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumberGenerator.aspx.cs" 
    Inherits="RandomNumberGenerator.RandomNumberGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="RandomGeneratorForm" runat="server">
        <input type="number" id="IntervalStart" runat="server" placeholder="Enter interval start." />
        <input type="number" id="IntevalEnd" runat="server" placeholder="Enter interval end." />
        <button id="GenerateRandomNumberButton" runat="server" onserverclick="GenerateRandomNumber">Generate</button>
        <div runat="server" text="" id="OutputDiv" visible="false"></div>
    </form>
</body>
</html>
