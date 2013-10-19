<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_04.EmployeesWithRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="EmployeeDetals" runat="server"
            ConnectionString="<%$ ConnectionStrings:NorthwindDb %>"
            SelectCommand="SELECT EmployeeID, LastName, FirstName, Title, BirthDate, HireDate, Address, City, PostalCode FROM Employees">
        </asp:SqlDataSource>

        <asp:Repeater ID="RepeaterTemplatedList" runat="server" DataSourceID="EmployeeDetals">
            <HeaderTemplate>
                <table>
                    <thead>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Title</th>
                        <th>Birth Date</th>
                        <th>Hire Date</th>
                        <th>Address</th>
                        <th>City</th>
                        <th>Postal Code</th>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#: Eval("FirstName") %></td>
                    <td><%#: Eval("LastName") %></td>
                    <td><%#: Eval("Title") %></td>
                    <td><%#: Eval("BirthDate", "{0:d}") %></td>
                    <td><%#: Eval("HireDate", "{0:d}") %></td>
                    <td><%#: Eval("Address") %></td>
                    <td><%#: Eval("City") %></td>
                    <td><%#: Eval("PostalCode") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
