<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCopies.aspx.cs" Inherits="Library.Web.UI.Book.DeleteCopies" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Delete Copy</title>

    <!-- Latest compiled and minified CSS and style -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />
    <link href="../css.css" rel="stylesheet" />
    <!-- End Latest compiled and minified CSS and style -->
</head>
<body>
    <form id="DeleteCopies" runat="server">
        <!-- navbar =========================================================== -->
        <nav class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="../Default.aspx" id="brand">Library</a>
                </div>
                <div id="navbar" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="MainList.aspx">Books</a></li>
                        <li><a href="../Users/MainList.aspx">Users</a></li>
                        <li><a href="../Loan/MainListLoan.aspx">Loans</a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>
        <!-- Error message =========================================================== -->
        <div class="container">
            <asp:Panel ID="PanelDeleteCopy" Visible="false" CssClass="alert alert-danger" runat="server">
                <p>
                    <asp:Literal ID="LiteralDeleteCopy" runat="server"></asp:Literal></p>
            </asp:Panel>
        </div>

        <!-- Page Header =========================================================== -->
        <div class="container">
            <div class="page-header">
                <h1>Delete Copy</h1>
            </div>
        </div>

        <div class="container lastItem">
            <p>Comfirn you want to delete this copy:</p>
        </div>

        <!-- Form =========================================================== -->
        <div class="container removePaddingLeft lastItem">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div class="col-sm-4">
                <p>CopyId</p>
                <asp:TextBox ID="boxCopyId" runat="server" CssClass="textField"></asp:TextBox>
            </div>

            <div class="col-sm-4">
                <p>BookId</p>
                <asp:TextBox ID="boxBookId" runat="server" CssClass="textField"></asp:TextBox>
            </div>

            <div class="col-sm-4">
                <p>Purchase Date</p>
                <asp:TextBox ID="boxPurchase" runat="server" CssClass="textField"></asp:TextBox>
            </div>

            <div class="col-sm-4">
                <p>Renewal Date</p>
                <asp:TextBox ID="boxRenewal" runat="server" CssClass="textField"></asp:TextBox>
            </div>
        </div>
        <!-- Insert and Cancel Button =========================================================== -->
        <div class="container lastItem">
            <asp:Button ID="ButUpdate" CssClass="btn btn-sm btn-danger" runat="server" Text="Delete Copy" OnClick="ButUpdate_Click" />
            <asp:Button ID="ButCancel" CssClass="btn btn-sm btn-default" runat="server" Text="Cancel" OnClick="ButCancel_Click" />

        </div>
        <!-- End of form =========================================================== -->
    </form>

    <div class="clearfix lastItemDouble"></div>

    <!-- Footer =========================================================== -->
    <div class="footer container-fluid navbar navbar-inverse">
        <div class="col-xs-12 ">
            <p class="footerBrand text-center">Library (c)  - 2015</p>
        </div>
    </div>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <!-- End Latest compiled and minified JavaScript -->
</body>
</html>
