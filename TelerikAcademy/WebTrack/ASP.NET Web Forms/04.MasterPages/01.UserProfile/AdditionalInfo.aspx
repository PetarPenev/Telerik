<%@ Page Title="" Language="C#" MasterPageFile="~/UserProfile.Master"
     AutoEventWireup="true" CodeBehind="AdditionalInfo.aspx.cs"
     Inherits="_01.UserProfile.AdditionalInfo" %>

<asp:Content ID="AdditionalInfoContent" ContentPlaceHolderID="ProfilePlaceholder" runat="server">
        <label for="HomeTown">Home town:</label>
        <div id="HomeTown">Asenovgrad</div>
        <label for="Education">Education:</label>
        <div id="Education">Bachelor's degree in Engineering</div>
        <label for="Hobbies">Hobbies:</label>
        <div id="Hobbies">Driving, hiking, ski jumping</div>
</asp:Content>
