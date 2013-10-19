<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageLifecycle.aspx.cs" Inherits="PageLifecycle.PageLifecycle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div runat="server" id="DivContainer">   
        </div>
        <asp:Button ID="ButtonOK" Text="Click" runat="server"
            OnInit="ButtonOK_Init" OnLoad="ButtonOK_Load" OnClick="ButtonOK_Click"
            OnPreRender="ButtonOK_PreRender" OnUnload="ButtonOK_Unload" />
    </form>
</body>
</html>
