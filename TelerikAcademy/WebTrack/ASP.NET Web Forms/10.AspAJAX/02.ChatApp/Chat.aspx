<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="_02.ChatApp.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chat Application</title>
    <style>
        #UpdateProgress
        {
            color: White;
            background: Red;
            margin: 5px;
            padding: 5px;
            border: 1px dotted #FFAAAA;
        }
    </style>
</head>
<body>
    <form id="ChatForm" runat="server">
        
        <asp:Label runat="server" AssociatedControlID="MessageTextInput" Text="Message:"></asp:Label>
        <asp:TextBox runat="server" ID="MessageTextInput" MaxLength="50"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="ButtonPostMessage" OnClick="ButtonPostMessage_Click" Text="Post" />

        <asp:ScriptManager ID="ScriptManager" runat="server" />

        <asp:Timer ID="TimerTimeRefresh" runat="Server" Interval="10000" OnTick="TimerTimeRefresh_Tick" />

        <asp:UpdateProgress ID="UpdateProgress" runat="server">
            <ProgressTemplate>
                Updating ...
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel runat='server' ID='UpdatePanelTime' UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerTimeRefresh" EventName="Tick" />
                <asp:AsyncPostBackTrigger ControlID="ButtonPostMessage" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView runat="server" ID="MessagesGrid" ItemType="_02.ChatCodeFirst.Message" 
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="MessageText" HeaderText="Message" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
