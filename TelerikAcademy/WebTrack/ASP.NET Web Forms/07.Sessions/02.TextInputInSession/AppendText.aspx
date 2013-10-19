<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppendText.aspx.cs" Inherits="_02.TextInputInSession.AppendText" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <label for="TextResult">Resulting text:</label>
        <asp:Label runat="server" ID="TextResult"></asp:Label>
        <br />
        <asp:TextBox runat="server" ID="TextBoxInput"></asp:TextBox>
        <asp:Button runat="server" ID="AppendTextButton" OnClick="AppendTextButton_Click" Text="Add Text" />
    </form>
</body>
</html>
