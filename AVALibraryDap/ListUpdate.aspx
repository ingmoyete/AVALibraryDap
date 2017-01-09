<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListUpdate.aspx.cs" Inherits="AVALibraryDap.ListUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1><asp:Literal ID="Literal1" runat="server">SELECT THE ITEM TO UPDATE</asp:Literal></h1>
        <asp:GridView ID="GridUpdateList" runat="server" DataKeyNames="BookId">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <a href="ListBooks.aspx">Back to list</a>
    </form>
</body>
</html>
