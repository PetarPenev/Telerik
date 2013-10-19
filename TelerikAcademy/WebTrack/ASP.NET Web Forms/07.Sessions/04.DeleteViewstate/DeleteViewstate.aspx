<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="DeleteViewstate.aspx.cs" 
    Inherits="_04.DeleteViewstate.DeleteViewstate" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Viewstate</title>
    <script src="jquery-1.8.2.js"></script>
</head>
<body>
    <form id="formTextBox" runat="server">
        <asp:TextBox runat="server" ID="Text"></asp:TextBox>
        <asp:Button runat="server" ID="ButtonSaveText" OnClick="ButtonSaveText_Click" Text="Save in ViewState" />
        <button id="deleteViewstate">Delete Viewstate</button>
    </form>
    <script>
        $(document).ready(
            $("#deleteViewstate").on("click", function(){
                $("#__VIEWSTATE").remove();
            })
            );
    </script>
</body>
</html>
