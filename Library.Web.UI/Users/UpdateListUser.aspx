<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateListUser.aspx.cs" Inherits="Library.Web.UI.Users.UpdateListUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="UpdateListUser" runat="server">
    <div>
        <h1><asp:Literal ID="UpdateListTitle" runat="server">SELECT AN ITEM TO UPDATE</asp:Literal></h1>

        <asp:GridView ID="GridUpdateListUsers" DataKeyNames="UserId" runat="server" OnSelectedIndexChanged="GridUpdateListUsers_SelectedIndexChanged">
            <Columns>

                <asp:CommandField ShowSelectButton="True" />

            </Columns>
        </asp:GridView>
    </div>

        <h2><a href="MainList.aspx">back to Main List</a></h2>
    </form>
</body>
</html>
