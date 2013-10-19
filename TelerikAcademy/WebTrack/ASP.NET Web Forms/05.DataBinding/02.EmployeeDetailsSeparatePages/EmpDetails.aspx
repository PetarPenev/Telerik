<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="_02.EmployeeDetailsSeparatePages.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Details</title>
</head>
<body>
    <form id="form1" runat="server">       
        <asp:SqlDataSource ID="EmployeeDetals" runat="server"
            ConnectionString="<%$ ConnectionStrings:NorthwindDb %>"
            SelectCommand="SELECT EmployeeID, LastName, FirstName, Title, BirthDate, HireDate, Address, City, PostalCode FROM Employees
                WHERE EmployeeID = @empId">
            <SelectParameters>
                <asp:QueryStringParameter Name="empId" QueryStringField="id" DefaultValue="1" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:DetailsView ID="DetailsViewEmployee" runat="server" 
             DataSourceID="EmployeeDetals" AutoGenerateRows="false">
            <Fields>
                <asp:BoundField DataField="FirstName" HeaderText="First Name"/>
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField HeaderText="Birth Date" DataField="BirthDate" HtmlEncode="false" DataFormatString="{0:d}" />
                <asp:BoundField DataField="HireDate" HeaderText="Hire Date"   HtmlEncode="false" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="PostalCode" HeaderText="Postal Code" />
            </Fields>
        </asp:DetailsView>

        <a href="Employees.aspx">Get back</a>    
    </form>
</body>
</html>
