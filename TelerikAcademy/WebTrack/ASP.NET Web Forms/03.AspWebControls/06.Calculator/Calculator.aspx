<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="_06.Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <link href="styles.css" rel="stylesheet" />
</head>
<body>
    <form id="CalculatorForm" runat="server">
    <div id="CalculatorContainer">
        <div id="display-div">
            <asp:TextBox runat="server" ID="CalculatorDisplay" Enabled="false" Text="0"></asp:TextBox>
        </div>
        <div id="main-button-div">
            <asp:Button runat="server" ID="Button1" Text="1" OnClick="AddNumber" />
            <asp:Button runat="server" ID="Button2" Text="2" OnClick="AddNumber"/>
            <asp:Button runat="server" ID="Button3" Text="3" OnClick="AddNumber"/>
            <asp:Button runat="server" ID="PlusButton" Text="+" OnClick="CheckOperation"/>
            <br />                     
            <asp:Button runat="server" ID="Button4" Text="4" OnClick="AddNumber"/>
            <asp:Button runat="server" ID="Button5" Text="5" OnClick="AddNumber"/>
            <asp:Button runat="server" ID="Buttton6" Text="6" OnClick="AddNumber"/>
            <asp:Button runat="server" ID="MinusButton" Text="-" OnClick="CheckOperation"/>
            <br />                     
            <asp:Button runat="server" ID="Button7" Text="7" OnClick="AddNumber"/>
            <asp:Button runat="server" ID="Button8" Text="8" OnClick="AddNumber"/>
            <asp:Button runat="server" ID="Button9" Text="9" OnClick="AddNumber"/>
            <asp:Button runat="server" ID="MultiplyButton" Text="*" OnClick="CheckOperation"/>
            <br />                     
            <asp:Button runat="server" ID="ClearButton" Text="Clear" OnClick="ClearCalculator" />
            <asp:Button runat="server" ID="Button0" Text="0" OnClick="AddNumber"/>
            <asp:Button runat="server" ID="DivideButton" Text="/" OnClick="CheckOperation"/>
            <asp:Button runat="server" ID="SquareRootButton" Text="&radic;" OnClick="CheckOperation"/>
        </div>
        <div id="finish-div">
            <asp:Button runat="server" ID="EqualButton" Text="=" OnClick="CalculateResult"/>
        </div>
    </div>
    </form>
</body>
</html>
