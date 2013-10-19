<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Moderator.aspx.cs" Inherits="ChatSystemWeb.Moderator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="MessagesGrid" CurrentSortDirAuthor="ASC" CurrentSortDirText="ASC"
        AllowPaging="true" AllowSorting="true" 
        AutoGenerateColumns="false" PageSize="5" OnPageIndexChanging="MessagesGrid_PageIndexChanging" 
        OnRowEditing="MessagesGrid_RowEditing" OnRowUpdating="MessagesGrid_RowUpdating" OnRowCancelingEdit="MessagesGrid_RowCancelingEdit"
        OnSorting="MessagesGrid_Sorting">
        <Columns>
            <asp:CommandField ShowEditButton="true" HeaderText="Edit Message" />
            <asp:TemplateField HeaderText="Author" SortExpression="Author">
                <ItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Eval("Author") %>' Enabled="false"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="AuthorEditContent" IdAttribute='<%# Eval("Id") %>' runat="server" Text='<%# Eval("Author") %>'/>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Text" SortExpression="Text">
                <ItemTemplate>
                    <asp:TextBox runat="server" Text='<%# Eval("Text") %>' Enabled="false"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextEditContent" runat="server" Text='<%# Eval("Text") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <label for="MessageContent" runat="server">Message:</label>
    <asp:TextBox ID="MessageContent" runat="server" MaxLength="20"></asp:TextBox>
    <label for="ErrorContent" runat="server">Last Post result:</label>
    <asp:TextBox ID="ErrorContent" runat="server" Enabled="false"></asp:TextBox>
    <asp:Button runat="server" ID="PostMessageBtn" Text="Post message" OnClick="PostMessageBtn_Click" />
</asp:Content>
