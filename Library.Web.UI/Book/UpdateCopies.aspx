<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCopies.aspx.cs" Inherits="Library.Web.UI.Book.UpdateCopies" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Insert book</title>

    <!-- Latest compiled and minified CSS and style -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <link href="../css.css" rel="stylesheet" />
    <!-- End Latest compiled and minified CSS and style -->
</head>
<body>
    <form id="UpdateCopies" runat="server">
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

        <!-- Page Header =========================================================== -->
        <div class="container">
            <div class="page-header">
                <h1>Update Copy</h1>
            </div>
        </div>

        <div class="container lastItem">
            <p>Fill the required fields in order to update the copy</p>
        </div>

        <!-- Form =========================================================== -->
        <div class="container removePaddingLeft">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div class="col-sm-4">
                <p>CopyId</p>
                <asp:TextBox ID="boxCopyId" runat="server" CssClass="textField"></asp:TextBox>
            </div>

            <div class="col-sm-4">
                <p>BookId</p>
                <asp:TextBox ID="boxBookId" runat="server" CssClass="textField"></asp:TextBox>
            </div>

            <div class="clearfix"></div>

            <div class="col-sm-4">
                <p>Purchase Date</p>
                <asp:TextBox ID="boxPurchase" runat="server" CssClass="required australianDate datePick"></asp:TextBox>
                <div class="errorContainer"></div>
            </div>

            <div class="col-sm-4">
                <p>Renewal Date</p>
                <asp:TextBox ID="boxRenewal" runat="server" CssClass="required australianDate datePick"></asp:TextBox>
                <div class="errorContainer"></div>
            </div>
        </div>

        <!-- Insert and Cancel Button =========================================================== -->
        <div class="container lastItem">
            <asp:Button ID="ButUpdate" CssClass="btn btn-sm btn-success" runat="server" Text="Update Copy" OnClick="ButUpdate_Click" />
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
    <!-- Js files =========================================================== -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <%-- Include plugins here --%>
    <script src="../jsFiles/jquery.validate.min.js"></script>
    <script src="../jsFiles/additional-methods.min.js"></script>

    <%-- End plugins --%>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <!-- Js validation =========================================================== -->

    <%-- Date picker --%>
    <script>
        $(function () {
            $(".datePick").datepicker({
                dateFormat: 'dd/mm/yy'
            }).on('change', function () { $(".datePick").valid(); })
        });
    </script>

    <%-- Add Custom validations --%>
    <script>
        $.validator.addMethod(
        "australianDate",
        function (value, element) {
            // put your own logic here, this is just a (crappy) example
            return value.match(/^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$/);
        },
        "Please enter a date in the format dd/mm/yyyy."
        );
    </script>

    <%-- Client Validations --%>
    <script type="text/javascript">

        $("#boxName").on('change', function () { $("#boxName").valid(); })
        $("#boxCopies").on('change', function () { $("#boxCopies").valid(); })
        $("#boxTitle").on('change', function () { $("#boxTitle").valid(); })
        $("#boxAuthor").on('change', function () { $("#boxAuthor").valid(); })
        $("#boxPurchase").on('change', function () { $("#boxPurchase").valid(); })
        $("#boxRenewal").on('change', function () { $("#boxRenewal").valid(); })
    </script>
</body>
</html>
