<%@ Page Title="" Language="C#" MasterPageFile="~/UserProfile.Master" 
    AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" 
    Inherits="_01.UserProfile.PersonalInfo" %>

<asp:Content ID="PersonalInfoContent" ContentPlaceHolderID="ProfilePlaceholder" runat="server">
    <div>
        <label for="FirstName">First name:</label>
        <div id="FirstName">Ninjio</div>
        <label for="LastName">Last name:</label>
        <div id="LastName">Ninjev</div>
        <label for="Age">Age:</label>
        <div id="Age">25</div>
        <label for="Occupation">Occupation:</label>
        <div id="Occupation">Aspiring software developer</div>
    </div>
</asp:Content>
