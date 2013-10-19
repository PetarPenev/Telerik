<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_03.EmployeeDetailsSinglePage.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="NorthwindData"
            runat="server"
            DataSourceMode="DataReader"
            ConnectionString="<%$ ConnectionStrings:NorthwindDb%>"
            SelectCommand="SELECT EmployeeId, FirstName, LastName FROM Employees"></asp:SqlDataSource>

        <asp:SqlDataSource ID="EmployeeDetals" runat="server"
            ConnectionString="<%$ ConnectionStrings:NorthwindDb %>"
            SelectCommand="SELECT EmployeeID, LastName, FirstName, Title, BirthDate, HireDate, Address, City, Region FROM Employees
                WHERE EmployeeID = @empId">
            <SelectParameters>
                <asp:Parameter Name="empId" DefaultValue="1" />
            </SelectParameters>
        </asp:SqlDataSource>
   

        <asp:GridView ID="EmployeeGridView" runat="server" AutoGenerateColumns="false"
                 DataSourceID="NorthwindData" DataKeyNames="EmployeeId">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:TemplateField HeaderText="See details">
                        <ItemTemplate>
                            <asp:Button runat="server" CausesValidation="false"
                                Text="Details" CommandArgument='<%# Eval("EmployeeId") %>' OnCommand="Visualize" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

         <asp:FormView ID="FormViewEmployee" runat="server">
            <ItemTemplate>
                <h3><%#: Eval("FirstName") + " " + Eval("LastName") %></h3>
                <table border="0">
                    <tr>
                        <td>Title:</td>
                        <td><%#: Eval("Title")%></td>
                    </tr>
                    <tr>
                        <td>Birth Date:</td>
                        <td><%#: Eval("BirthDate", "{0:d}")%></td>
                    </tr>
                    <tr>
                        <td>Hire Date:</td>
                        <td><%#: Eval("HireDate", "{0:d}")%></td>
                    </tr>
                    <tr>
                        <td>Address:</td>
                        <td><%#: Eval("Address")%></td>
                    </tr>
                    <tr>
                        <td>City:</td>
                        <td><%#: Eval("City")%></td>
                    </tr>
                    <tr>
                        <td>Region:</td>
                        <td><%#: Eval("Region")%></td>
                    </tr>
                </table>
                <hr />
            </ItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>
