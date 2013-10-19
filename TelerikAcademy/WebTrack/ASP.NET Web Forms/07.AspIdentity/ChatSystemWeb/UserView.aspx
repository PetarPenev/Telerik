<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserView.aspx.cs" Inherits="ChatSystemWeb.UserView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="MessagesGrid" CurrentSortDirAuthor="ASC" CurrentSortDirText="ASC"
        AllowPaging="true" AllowSorting="true" 
        AutoGenerateColumns="false" PageSize="5" OnPageIndexChanging="MessagesGrid_PageIndexChanging" 
        OnSorting="MessagesGrid_Sorting">
        <Columns>
            <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author"/>
            <asp:BoundField DataField="Text" HeaderText="Message Text" SortExpression="Text" />
        </Columns>
    </asp:GridView>
    <label for="MessageContent" runat="server">Message:</label>
    <asp:TextBox ID="MessageContent" runat="server" MaxLength="20"></asp:TextBox>
    <label for="ErrorContent" runat="server">Last Post result:</label>
    <asp:TextBox ID="ErrorContent" runat="server" Enabled="false"></asp:TextBox>
    <asp:Button runat="server" ID="PostMessageBtn" Text="Post message" OnClick="PostMessageBtn_Click" />
</asp:Content>
