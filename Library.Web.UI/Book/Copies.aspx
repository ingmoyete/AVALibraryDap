<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Copies.aspx.cs" Inherits="Library.Web.UI.Book.Copies" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Copies List</title>

    <!-- Latest compiled and minified CSS and style -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />
    <link href="../css/stacktable.css" rel="stylesheet" />
    <link href="../jsFiles/bootstrapPagination.css" rel="stylesheet" />
    <link href="../css.css" rel="stylesheet" />
    <!-- End Latest compiled and minified CSS and style -->
</head>
<body>
    <form id="CopyList" runat="server">

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
        <div class="container lastItem">
            <div class="page-header">
                <h1>Copies</h1>
            </div>
            <p>These are all the copies for the book. <a href="MainList.aspx">Back to the book list</a></p>
        </div>

        <!-- Grid =========================================================== -->
        <%  if (GridCopyList.HeaderRow != null)
            {
                GridCopyList.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        %>
        <div class="container lastItem">
            <asp:GridView ID="GridCopyList" AllowPaging="true" OnPageIndexChanging="GridCopyList_PageIndexChanging" PageSize="10" CssClass="table table-striped" GridLines="None" UseAccessibleHeader="true" runat="server" DataKeyNames="CopyId" OnRowCommand="GridCopyList_RowCommand">
                <PagerStyle CssClass="pagination-ys" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkModify" CssClass="btn btn-xs btn-success" CommandName="Modify" runat="server">Modify</asp:LinkButton>
                            <asp:LinkButton ID="LinkDelete" CssClass="btn btn-xs btn-danger" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
    <script src="../jsFiles/stacktable.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <!-- End Latest compiled and minified JavaScript -->
    <%-- Stacktable --%>
    <script>
        $('#GridCopyList').stacktable();
    </script>
</body>
</html>
