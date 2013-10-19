<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WriteHelloAsp.aspx.cs" Inherits="AssemblyDisplay.WriteHelloAsp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script runat="server">
        protected string ReturnStringValue(){
            return "Hello, Asp";
        }
    </script>
    <style>
        #PathToAssembly {
            min-width:600px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="NameFromCodeBehind" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonToCallNameFromCodeBehind" runat="server" OnClick="GetName" Text="Get text from code behind."/>
        <br />
        <label for="NameFromAspCode">This text is from the asp code:</label>
        <div id="NameFromAspCode"><%=ReturnStringValue()%></div>
        <br />
        <asp:TextBox runat="server" ID="PathToAssembly" Enabled="false" placeholder="Here you will see the assembly path."></asp:TextBox>
        <br />
        <asp:Button runat="server" Text="Show assembly path" OnClick="GetAssembly" />
    </form>
</body>
</html>
