<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListBooks.aspx.cs" Inherits="AVALibraryDap.ListBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="ListUsers" runat="server">
    <div>
        <h1><asp:Literal ID="Literal1" runat="server">LIST OF BOOKS</asp:Literal></h1>

        <h3><a href="insertBooks.aspx">Insert</a></h3>

        <h3><a href="ListUpdate.aspx">Modify</a></h3>

        <h3><a href="#">Delete</a></h3>

        <asp:GridView ID="gridBookList" runat="server" DataKeyNames="BookId" OnSelectedIndexChanged="gridBookList_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>

        <h2><a href="Default.aspx">back to Default Page</a></h2>
    </form>
</body>
</html>
