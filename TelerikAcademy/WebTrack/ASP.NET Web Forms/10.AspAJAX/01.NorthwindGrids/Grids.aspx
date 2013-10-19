<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grids.aspx.cs" Inherits="_01.NorthwindGrids.Grids" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Northwind Grid Views</title>
    <style>
        #UpdateProgress
        {
            color: White;
            background: Red;
            margin: 5px;
            padding: 5px;
            border: 1px dotted #FFAAAA;
        }

        #EmployeesGrid {
            margin-bottom: 30px;
        }
    </style>
</head>
<body>
    <form id="GridForm" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server" />

        <asp:GridView runat="server" ID="EmployeesGrid" ItemType="Employee" AutoGenerateColumns="false" 
            OnSelectedIndexChanged="EmployeesGrid_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="true" HeaderText="See employee orders" />
                <asp:BoundField DataField="EmployeeID" HeaderText="Employee Id" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="City" HeaderText="City" />
            </Columns>
        </asp:GridView>

        <asp:UpdateProgress ID="UpdateProgress" runat="server">
            <ProgressTemplate>
                Updating ...
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel runat="server" ID="UpdateOrdersPanel" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="EmployeesGrid"
                    EventName="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView runat="server" ID="OrdersGrid" ItemType="Order" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" />
                        <asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" />
                        <asp:BoundField DataField="ShipName" HeaderText="ShipName" />
                        <asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" />
                        <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
