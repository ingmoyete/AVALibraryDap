<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AVALibraryDap.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Default" runat="server">

    <div>
        <a href="ListBooks.aspx">
            <h2>
                <asp:Literal ID="LitBooks" runat="server">BOOKS</asp:Literal>  
            </h2>
        </a>
    </div>

    <div>
        <a href="ListUsers.aspx">
            <h2>
                <asp:Literal ID="LitUsers" runat="server">USERS</asp:Literal>  
            </h2>
        </a>
    </div>

    </form>
</body>
</html>
