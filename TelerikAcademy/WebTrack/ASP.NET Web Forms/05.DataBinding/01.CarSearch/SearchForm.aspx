<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchForm.aspx.cs" Inherits="_01.CarSearch.SearchForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Car Search</title>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="SearchForm" runat="server">
        <label for="ProducersDropDown">Brand:</label>
        <asp:DropDownList ID="ProducersDropDown" runat="server" AutoPostBack="true"
            DataTextField="Name"
            onselectedindexchanged="ProducerChanged">
        </asp:DropDownList>
        <br />
        <label for="ModelsDropDown">Model:</label>
        <asp:DropDownList ID="ModelsDropDown" runat="server" AutoPostBack="false">
        </asp:DropDownList>
        <br />
        <label for="ExtrasList">Extras:</label>
        <asp:CheckBoxList runat="server" ID="ExtrasList" DataTextField="Name"></asp:CheckBoxList>
        <br />
        <label for="EnginesList">Engine:</label>
        <asp:RadioButtonList ID="EnginesList" runat="server"></asp:RadioButtonList>
        <br />
        <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitData" />
        <br />
        <asp:Literal runat="server" ID="ResultView"></asp:Literal>
    </form>
</body>
</html>
