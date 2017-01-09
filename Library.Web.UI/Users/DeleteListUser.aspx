<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteListUser.aspx.cs" Inherits="Library.Web.UI.Users.DeleteListUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="DeleteListUsers" runat="server">
    <div>
        <h1>SELECT AN ITEM TO DELETE</h1>

        <asp:GridView ID="GridDeleteListUser" DataKeyNames="UserId" runat="server" OnSelectedIndexChanged="GridDeleteListUser_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>

        <h2><a href="MainList.aspx">back to Main List</a></h2>
    </form>
</body>
</html>
