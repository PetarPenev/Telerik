<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoApp.aspx.cs" Inherits="_06.ToDoApp.ToDoApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ToDoList</title>
    <style>
        table, td {
            border-collapse:collapse;
            border: 1px solid black;
        }
        
    </style>
</head>
<body>
    <form id="formToDos" runat="server">
        
        <asp:EntityDataSource ID="EntityDataSourceCategories" runat="server" 
            ConnectionString="name=ListDBEntities"
             DefaultContainerName="ListDBEntities"
             EnableDelete="True" EnableFlattening="False" EnableInsert="True" 
            EnableUpdate="True" EntitySetName="Categories">
        </asp:EntityDataSource>

        <label for="MessagesTextbox">Result of last operation:</label>
        <asp:TextBox runat="server" ID="MessagesTextbox" Text="" Enabled="false"></asp:TextBox>
        <br />
        
        <asp:DropDownList ID="DropDownListCategories" runat="server" 
            AutoPostBack="True" DataSourceID="EntityDataSourceCategories" 
            DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="DropDownListCategories_SelectedIndexChanged">
        </asp:DropDownList>

        <br />
        <label for="NewCategoryNameBox">Name of category:</label>
        <asp:TextBox runat="server" ID="NewCategoryNameBox"></asp:TextBox>
        <asp:Button runat="server" ID="CreateCategoryButton" Text="Create new category" 
            OnClick="CreateCategoryButton_Click" />

        <br />
        <label for="EditCategoryNameBox">Name of category:</label>
        <asp:TextBox runat="server" ID="EditCategoryNameBox"></asp:TextBox>
        <asp:Button runat="server" ID="EditCategoryButton" Text="Edit category" 
            OnClick="EditCategoryButton_Click" />

        <br />
        <asp:Button runat="server" ID="DeleteCategoryButton" OnClick="DeleteCategoryButton_Click" 
            Text="Delete current category"/>

        <br />

        
        <asp:EntityDataSource ID="EntityDataSourceTodos" runat="server"
             ConnectionString="name=ListDBEntities" DefaultContainerName="ListDBEntities" 
            EnableDelete="True" EnableFlattening="False" EnableInsert="True" 
            EnableUpdate="True" EntitySetName="ToDoes" Where="it.CategoryId=@CatID">
            <WhereParameters>
                <asp:ControlParameter Name="CatID" Type="Int32"
                    ControlID="DropDownListCategories" />
            </WhereParameters>
        </asp:EntityDataSource>

        
        <asp:ListView ID="ListViewTodos" runat="server" DataKeyNames="Id" 
            DataSourceID="EntityDataSourceTodos" InsertItemPosition="LastItem" OnItemUpdating="ListView1_ItemUpdating"  
            OnItemInserting="ListViewTodos_ItemInserting">
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="TextTextBox" runat="server" Text='<%# Bind("Text") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="TextTextBox" runat="server" Text='<%# Bind("Text") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="TextLabel" runat="server" Text='<%# Eval("Text") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LastChangedDateLabel" runat="server" Text='<%# Eval("LastChangedDate") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server"></th>
                                    <th runat="server">Title</th>
                                    <th runat="server">Text</th>
                                    <th runat="server">LastChangedDate</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="TextLabel" runat="server" Text='<%# Eval("Text") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LastChangedDateLabel" runat="server" Text='<%# Eval("LastChangedDate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CategoryIdLabel" runat="server" Text='<%# Eval("CategoryId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CategoryLabel" runat="server" Text='<%# Eval("Category") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>

        
    </form>
</body>
</html>
