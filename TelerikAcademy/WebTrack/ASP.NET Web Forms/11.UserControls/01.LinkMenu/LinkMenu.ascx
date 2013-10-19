<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="LinkMenu.ascx.cs"
     Inherits="_01.LinkMenu.LinkMenu" %>
<asp:DataList runat="server" ID="LinkMenuDataList" OnItemDataBound="LinkMenuDataList_ItemDataBound" RepeatDirection="Horizontal">
    <ItemTemplate>
        <asp:HyperLink ID="LinkItem" runat="server" href='<%# Eval("URL") %>' Text='<%# Eval("Text") %>'></asp:HyperLink>
    </ItemTemplate>
</asp:DataList>
