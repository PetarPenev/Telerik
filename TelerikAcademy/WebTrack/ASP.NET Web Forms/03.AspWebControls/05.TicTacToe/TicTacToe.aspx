<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicTacToe.aspx.cs" Inherits="_05.TicTacToe.TicTacToe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tic Tac Toe</title>
    <style>
        .btn-field{
            min-width:100px;
            background-color: aquamarine;
        }

        #TurnBox, #ResultBox {
            min-width: 150px;
        }

        #ClearGameButton{
            max-width:150px;
        }
    </style>
</head>
<body>
    <form id="TicTacToeForm" runat="server">
    <div>
        <asp:Button runat="server" ID="Position00" CssClass="btn-field" Text="Empty" OnClick="ProcessClick" />
        <asp:Button runat="server" ID="Position01" CssClass="btn-field" Text="Empty" OnClick="ProcessClick" />
        <asp:Button runat="server" ID="Position02" CssClass="btn-field" Text="Empty" OnClick="ProcessClick" />
        <br />
        <asp:Button runat="server" ID="Position10" CssClass="btn-field" Text="Empty" OnClick="ProcessClick" />
        <asp:Button runat="server" ID="Position11" CssClass="btn-field" Text="Empty" OnClick="ProcessClick" />
        <asp:Button runat="server" ID="Position12" CssClass="btn-field" Text="Empty" OnClick="ProcessClick" />
        <br />
        <asp:Button runat="server" ID="Position20" CssClass="btn-field" Text="Empty" OnClick="ProcessClick" />
        <asp:Button runat="server" ID="Position21" CssClass="btn-field" Text="Empty" OnClick="ProcessClick" />
        <asp:Button runat="server" ID="Position22" CssClass="btn-field" Text="Empty" OnClick="ProcessClick" />
        <br />
        <asp:Button runat="server" ID="ClearGameButton" Text="Clear Game" OnClick="ClearGame" />
        <asp:TextBox runat="server" ID="TurnBox" Enabled="false" Text="0 turns passed"></asp:TextBox>
        <asp:TextBox runat="server" ID="ResultBox" Enabled="false"></asp:TextBox>
    </div>
    </form>
</body>
</html>
