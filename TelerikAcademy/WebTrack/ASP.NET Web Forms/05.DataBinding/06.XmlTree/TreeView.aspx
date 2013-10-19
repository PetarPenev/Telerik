<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeView.aspx.cs" Inherits="_06.XmlTree.TreeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TreeView ID="TreeView1"
            runat="server" DataSourceID="XmlDataSource1" ExpandImageUrl="~/images/plus.png" OnTreeNodeExpanded="Expand" 
            OnTreeNodeCollapsed="Collapse" NoExpandImageUrl="~/images/ordinary.png"
            CollapseImageUrl="~/images/minus.gif" >

            <DataBindings>

                <asp:TreeNodeBinding DataMember="Category"
                    ValueField="ID" TextField="Name"></asp:TreeNodeBinding>

                <asp:TreeNodeBinding DataMember="Description"
                    ValueField="Value"
                    TextField="Value"></asp:TreeNodeBinding>

            </DataBindings>

        </asp:TreeView>

        <asp:XmlDataSource ID="XmlDataSource1" runat="server"
            DataFile="Categories.xml"></asp:XmlDataSource>
    </form>
</body>
</html>
