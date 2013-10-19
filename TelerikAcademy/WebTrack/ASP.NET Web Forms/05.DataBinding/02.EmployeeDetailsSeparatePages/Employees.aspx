<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_02.EmployeeDetailsSeparatePages.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
</head>
<body>
    <form id="form1" runat="server">   
        <asp:GridView ID="EmployeeGridView" runat="server" AutoGenerateColumns="false"
             DataSourceID="NorthwindData" DataKeyNames="EmployeeId">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:HyperLinkField HeaderText="See details" Text="Details" DataNavigateUrlFields="EmployeeId"
                    DataNavigateUrlFormatString="EmpDetails.aspx?id={0}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="NorthwindData"
          runat="server"
          DataSourceMode="DataReader"
          ConnectionString="<%$ ConnectionStrings:NorthwindDb%>"
          SelectCommand="SELECT EmployeeId, FirstName, LastName FROM Employees"></asp:SqlDataSource>
   
    </form>
</body>
</html>
