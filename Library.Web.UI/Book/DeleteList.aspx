<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteList.aspx.cs" Inherits="Library.Web.UI.Book.DeleteList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="DeleteList" runat="server">
    <div>
        <h1><asp:Literal ID="UpdateListTitle" runat="server">SELECT AN ITEM TO DELETE</asp:Literal></h1>

        <asp:GridView ID="GridDeleteList" runat="server" DataKeyNames="BookId" OnSelectedIndexChanged="GridDeleteList_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>

        <h2><a href="MainList.aspx">back to Main List</a></h2>
    </form>
</body>
</html>
