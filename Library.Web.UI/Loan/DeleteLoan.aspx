<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteLoan.aspx.cs" Inherits="Library.Web.UI.Loan.DeleteLoan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Delete Loan</title>

    <!-- Latest compiled and minified CSS and style -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />
    <link href="../css.css" rel="stylesheet" />
    <!-- End Latest compiled and minified CSS and style -->
</head>
<body>
    <form id="DeleteLoans" runat="server">
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
                        <li><a href="../Book/MainList.aspx">Books</a></li>
                        <li><a href="../Users/MainList.aspx">Users</a></li>
                        <li class="active"><a href="MainListLoan.aspx">Loans</a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>
            <!-- Page Header =========================================================== -->
        <div class="container">
            <div class="page-header">
                <h1>Delete Loan</h1>
            </div>
        </div>

        <div class="container">
        <p><strong>Confirm you want to delete the following loan:</strong></p>
        </div>

        <!-- Form =========================================================== -->
        <div class="container removePaddingLeft lastItem">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <!-- Dates =============== -->
                <div class="col-sm-4">
            <p>Delivery Date</p>
                <asp:TextBox ID="boxDelivery" runat="server" CssClass="textField"></asp:TextBox>
            </div>

            <div class="col-sm-4">
            <p>Loan Date</p>
                <asp:TextBox ID="boxLoanDate" runat="server" CssClass="textField"></asp:TextBox>
            </div>

            <div class="clearfix"></div>

            <!-- Loan details =============== -->
            <p class="addPaddingLeft lastItemt"><strong>Loan description: </strong></p>

            <div class="col-sm-4"> 
            <p>Book Code</p>
                <asp:TextBox ID="boxCopyId" runat="server" CssClass="textField"></asp:TextBox>
            </div>

            <div class="col-sm-4"> 
            <p>Loan Code</p>
                <asp:TextBox ID="boxLoanId" runat="server" CssClass="textField"></asp:TextBox>
            </div>

            <div class="clearfix"></div>

            <div class="col-sm-4">
            <p>Title</p>
                <asp:TextBox ID="boxTitle" runat="server" CssClass="textField"></asp:TextBox>
            </div>

                <div class="col-sm-4">
            <p>Author</p>
                <asp:TextBox ID="boxAuthor" runat="server" CssClass="textField"></asp:TextBox>
            </div>

            <div class="col-sm-4 lastItem">
            <p>Section</p>
                <asp:DropDownList ID="ddlSection" runat="server" CssClass="textField"></asp:DropDownList>
            </div>

            <div class="col-sm-4">
            <p>Name</p>
                <asp:TextBox ID="boxName" runat="server" CssClass="textField"></asp:TextBox>
            </div>

            <div class="col-sm-4">
            <p>Last Name</p>
                <asp:TextBox ID="boxLastName" runat="server" CssClass="textField"></asp:TextBox>
            </div>
            <div class="col-sm-4">
            <p>Dni</p>
                <asp:TextBox ID="boxDni" runat="server" CssClass="textField"></asp:TextBox>
            </div>
        </div>

        <!-- Insert and Cancel Button =========================================================== -->
        <div class="container lastItem">
            <asp:Button ID="ButDelete" CssClass="btn btn-sm btn-danger" runat="server" Text="Delete" OnClick="ButDelete_Click" />
            <a href="MainListLoan.aspx" class="btn btn-sm btn-default">Cancel</a>
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
