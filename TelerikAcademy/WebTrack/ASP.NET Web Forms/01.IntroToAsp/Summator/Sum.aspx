<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sum.aspx.cs" Inherits="Summator.Sum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="sumForm" runat="server">
    <div>
        <label for="firstNumberInput">First Number:</label>
        <asp:TextBox type="number" id="firstNumberInput" runat="server" ></asp:TextBox>
        <br />
        <label for="secondNumberInput">Second Number:</label>
        <asp:TextBox type="number" id="secondNumberInput" runat="server" ></asp:TextBox>
        <br />
        <asp:Button runat="server" OnClick="SumInputs" Text="Calculate sum" />
        <br />
        <asp:TextBox type="text" ID="SumValue" runat="server" Enabled="false"></asp:TextBox>
    </div>
    </form>
</body>
</html>
