<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insertBooks.aspx.cs" Inherits="AVALibraryDap.insertBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="insertBooks" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h1>
            <asp:Literal ID="litInsertBooks" runat="server">
                INSERT BOOKS
            </asp:Literal>
        </h1>

        <h2>Title</h2>
        <div>
            <asp:TextBox ID="boxTitle" runat="server"></asp:TextBox>  
        </div>

        <h2>Author</h2>
        <div>
            <asp:TextBox ID="boxAuthor" runat="server"></asp:TextBox>  
        </div>

        <h2>Section (Should be 1)</h2>
        <div>
            <asp:TextBox ID="boxSection" runat="server"></asp:TextBox>  
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="*" ErrorMessage="It should be an integer" ControlToValidate="boxSection" ValidationExpression="(?:\d*\.)?\d+"></asp:RegularExpressionValidator>
        </div>

        <asp:Button ID="buttonInsertBook" runat="server" Text="Insert" OnClick="buttonInsertBook_Click" style="height: 26px" />
        
        <a href="ListBooks.aspx">
            <h2>
            <asp:Literal ID="litGetBackToBookList" runat="server">
                Get back to the books list
            </asp:Literal>
            </h2>
        </a>

    </form>
</body>
</html>
