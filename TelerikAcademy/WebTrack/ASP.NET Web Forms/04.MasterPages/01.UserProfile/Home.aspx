<%@ Page 
    Title="Home Page" 
    Language="C#" MasterPageFile="~/UserProfile.Master" 
    AutoEventWireup="true" CodeBehind="Home.aspx.cs" 
    Inherits="_01.UserProfile.Home" %>

<asp:Content ID="HomeContent" ContentPlaceHolderID="ProfilePlaceholder" runat="server">
    <div>
        <label for="Username">Username:</label>
        <div id="Username">Telerik Ninja</div>
    </div>
</asp:Content>
