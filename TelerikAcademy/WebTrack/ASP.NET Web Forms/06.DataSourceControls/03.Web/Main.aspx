<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="Main.aspx.cs" 
    Inherits="_03.Web.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>World Data</title>
    <style>
        table, td {
            border-collapse:collapse;
            border: 1px solid black;
        }
        
    </style>
</head>
<body>
    <form id="mainForm" runat="server">
        <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server" 
            ConnectionString="name=WorldDBEntities" 
            DefaultContainerName="WorldDBEntities" 
            EntitySetName="Continents" EnableFlattening ="false" />

        <asp:ListBox ID="ListBoxContinents" runat="server" Rows="4"
            DataSourceID="EntityDataSourceContinents" 
            DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ListBoxContinents_SelectedIndexChanged"
            AutoPostBack="True"  />

        <br />
        <label for="ContinentNameBox">Continent name</label>
        <asp:TextBox runat="server" ID="ContinentNameBox"></asp:TextBox>
        <label for="ResultContinentAdd">Result of last operation:</label>
        <asp:TextBox ID="ResultContinentAdd" runat="server" Enabled="false"></asp:TextBox>
        <asp:Button runat="server" ID="AddContinentButton" OnClick="AddContinentButton_Click" Text="Add new continent" />

        <br />

        <asp:TextBox runat="server" ID="ContinentEditNameBox" Text=""></asp:TextBox>
        <label for="ResultContinentUpdate">Result of last operation:</label>
        <asp:TextBox ID="ResultContinentUpdate" runat="server" Enabled="false"></asp:TextBox>
        <asp:Button runat="server" ID="EditContinentButton" OnClick="EditContinentButton_Click" Text="Edit Continent" />

        <br />

        <asp:Button runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" Text="Delete Continent" />

        <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server" 
            ConnectionString="name=WorldDBEntities" 
            DefaultContainerName="WorldDBEntities" 
            EntitySetName="Countries" Include="Towns" EnableUpdate="true" EnableDelete="true"
            Where="it.ContinentId=@ContID">
            <WhereParameters>
                <asp:ControlParameter Name="ContID" Type="Int32"
                    ControlID="ListBoxContinents" />
            </WhereParameters>
        </asp:EntityDataSource>


        <asp:GridView ID="GridViewCountries" runat="server" DataSourceID="EntityDataSourceCountries" 
            AllowPaging="True" PageSize="3" AllowSorting="True"
             AutoGenerateColumns="false" DataKeyNames="Id" 
            OnSelectedIndexChanged="GridViewCountries_SelectedIndexChanged"
            ShowFooter="true" OnRowUpdating="GridViewCountries_RowUpdating">
            <Columns>
                <asp:CommandField ShowSelectButton="True" HeaderText="Select Country" />
                <asp:CommandField ShowEditButton="True" HeaderText="Edit Country" />
                <asp:CommandField ShowDeleteButton="True" HeaderText="Delete Country" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <img src='<%#: GenerateImageStringFromDb(Eval("Flag")) %>' alt="flag" height="50" width="100" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:FileUpload ID="FileUploaded" runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <br />
        <div id="ContainerAddCountry" runat="server">
            <label for="CountryName">Country Name:</label>
            <asp:TextBox Id="CountryName" runat="server"></asp:TextBox>
            <label for="CountryLanguage">Country Language:</label>
            <asp:TextBox Id="CountryLanguage" runat="server"></asp:TextBox>
            <label for="CountryPopulation">Country Population:</label>
            <asp:TextBox Id="CountryPopulation" runat="server"></asp:TextBox>
            <label for="FileUpload">Flag:</label>
            <asp:FileUpload  ID="NewFlagUploader" runat="server" />
            <label for="ResultCountryAdd">Result of last operation:</label>
            <asp:TextBox ID="ResultCountryAdd" runat="server" Enabled="false"></asp:TextBox>
            <asp:Button runat="server" ID="SaveCountryButton" Text="SaveCountry" OnClick="SaveCountryButton_Click"/>
        </div>

         <asp:EntityDataSource ID="EntityDataSourceTowns" runat="server"
            EnableInsert="True" EnableUpdate="True" EnableDelete="True"
            ConnectionString="name=WorldDBEntities" 
            DefaultContainerName="WorldDBEntities"  Include="Country"
            EntitySetName="Towns" Where="it.CountryId=@ContID" EnableFlattening="False" EntityTypeFilter="Town">
            <WhereParameters>
                <asp:ControlParameter Name="ContID" Type="Int32"
                    ControlID="GridViewCountries" />
            </WhereParameters>
        </asp:EntityDataSource>

         <asp:EntityDataSource ID="EntityDataSourceCountriesAll" runat="server" 
            ConnectionString="name=WorldDBEntities" 
            DefaultContainerName="WorldDBEntities"
            EntitySetName="Countries" EnableFlattening="False">
        </asp:EntityDataSource>
        
        <asp:ListView ID="ListViewTowns" ItemType="_03.Web.Town" runat="server" DataKeyNames="Id" DataSourceID="EntityDataSourceTowns" InsertItemPosition="None">         
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListCountry" runat="server" 
                            DataSourceID="EntityDataSourceCountriesAll"
                            DataValueField="Id"
                            DataTextField="Name"
                            SelectedValue="<%# BindItem.CountryId %>"
                            AppendDataBoundItems="true">
                            <asp:ListItem Text="(no country)" Value="" />
                        </asp:DropDownList>
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
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListCountry" runat="server" 
                            DataSourceID="EntityDataSourceCountriesAll"
                            DataValueField="Id"
                            DataTextField="Name"
                            SelectedValue="<%# BindItem.CountryId %>"
                            AppendDataBoundItems="true">
                            <asp:ListItem Text="(no country)" Value="" />
                        </asp:DropDownList>
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
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country.Name") %>' />
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
                                    <th runat="server">Name</th>
                                    <th runat="server">Population</th>
                                    <th runat="server">Country</th>
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
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        
    </form>
</body>
</html>
