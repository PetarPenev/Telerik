<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CachingHomework.About" %>
<%@ OutputCache Duration="3600" VaryByParam="none" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
        <p class="lead">Your app description page.</p>
    </header>

    <div class="row-fluid">
        <div class="span12">
            <p>About is now cachable for 1 hour.</p>
             <h2>Time: <%= DateTime.Now %></h2>
        </div>
    </div>

</asp:Content>
