<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoAlbum.aspx.cs" Inherits="_03.PhotoAlbum.PhotoAlbum" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Photo Album</title>
    <style>
        #div-align, h1 {
            text-align:center;
        }
    </style>
    <script src="jquery-1.8.2.min.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <h1>My Slideshow</h1>

        <asp:Image ID="Image1" runat="server" Height="250" />
        <asp:SlideShowExtender ID="Image1_SlideShowExtender" runat="server"
            Enabled="True" ImageDescriptionLabelID="txtDesc"
            SlideShowServiceMethod="GetSlides" AutoPlay="true"
            NextButtonID="btnNext" PreviousButtonID="btnPrev"
            TargetControlID="Image1">
        </asp:SlideShowExtender>
        <br />
        <div id="div-align">
            <asp:Button ID="btnPrev" runat="server" Text="<" />
            <asp:Button ID="btnNext" runat="server" Text=">" />
            <asp:Label ID="txtDesc" runat="server" Text="Label" />
        </div>
    </form>
    <script src="popup-script.js"></script>
</body>
</html>
