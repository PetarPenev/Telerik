<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="_04.RegistrationForm.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="RegistrationForm" runat="server">
        <div>
            <label for="FirstNameInput">First Name:</label>
            <asp:TextBox runat="server" ID="FirstNameInput"></asp:TextBox>
            <br />
            <label for="LastNameInput">Last Name:</label>
            <asp:TextBox runat="server" ID="LastNameInput"></asp:TextBox>
            <br />
            <label for="FacultyNumberInput">Faculty Number:</label>
            <asp:TextBox runat="server" ID="FacultyNumberInput"></asp:TextBox>
            <br />
            <asp:DropDownList ID="UniversityInput" runat="server" AutoPostBack="False">
                <asp:ListItem Value="1">Sofia University</asp:ListItem>
                <asp:ListItem Value="2">Technical University</asp:ListItem>
                <asp:ListItem Value="3">UNSS</asp:ListItem>
                <asp:ListItem Value="4">Medical University</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:DropDownList ID="SpecialtyInput" runat="server" AutoPostBack="False">
                <asp:ListItem Value="1">Mathematics</asp:ListItem>
                <asp:ListItem Value="2">Informatics</asp:ListItem>
                <asp:ListItem Value="3">Engineering</asp:ListItem>
                <asp:ListItem Value="4">Economics</asp:ListItem>
                <asp:ListItem Value="5">Medicine</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:ListBox runat="server" ID="CourseInput" AutoPostBack="false" SelectionMode="Multiple">
                <asp:ListItem Value="1">First Introductory Course</asp:ListItem>
                <asp:ListItem Value="2">Second Introductory Course</asp:ListItem>
                <asp:ListItem Value="3">Third Introductory Course</asp:ListItem>
                <asp:ListItem Value="4">Forth Introductory Course</asp:ListItem>
                <asp:ListItem Value="5">Fifth Introductory Course</asp:ListItem>
                <asp:ListItem Value="6">Sixth Introductory Course</asp:ListItem>
            </asp:ListBox>
            <br />
            <asp:Button runat="server" ID="SubmitButton" OnClick="VisualizeInputs" Text="Submit" />
            <br />
            <div runat="server" id="OutputDiv" visible="false"></div>
        </div>
    </form>
</body>
</html>
