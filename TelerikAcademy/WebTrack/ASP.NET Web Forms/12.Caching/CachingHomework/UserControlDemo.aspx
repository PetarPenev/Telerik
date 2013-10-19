<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserControlDemo.aspx.cs" Inherits="CachingHomework.UserControlDemo" %>
<%@ Register Src="~/UserControl.ascx" TagPrefix="project" TagName="CacheableUserControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <project:CacheableUserControl runat="server" />
</asp:Content>
