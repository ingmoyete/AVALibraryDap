<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainList.aspx.cs" Inherits="Library.Web.UI.Users.MainList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>User Main List</title>

    <!-- Latest compiled and minified CSS and style -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />
    <link href="../css/stacktable.css" rel="stylesheet" />
    <link href="../jsFiles/bootstrapPagination.css" rel="stylesheet" />
    <link href="../css.css" rel="stylesheet" />
    <!-- End Latest compiled and minified CSS and style -->
</head>
<body>
    <form id="MainListUsers" runat="server">
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
                    <a class="brand navbar-brand" href="../Default.aspx" id="brand">Library</a>
                </div>
                <div id="navbar" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a href="../Book/MainList.aspx">Books</a></li>
                        <li class="active"><a href="MainList.aspx">Users</a></li>
                        <li><a href="../Loan/MainListLoan.aspx">Loans</a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>

        <!-- Jumbotron =========================================================== -->
        <div class="container">
            <div class="jumbotron">
                <h1 class="h1Jumbotron">User List</h1>
                <p>You can modify, delete and insert Users.</p>
                <a href="InsertUser.aspx" class="insertButton btn btn-sm btn-warning">Insert a New User</a>
            </div>
        </div>

        <%-- UPDATE PANNEL --%>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <!-- Search   =========================================================== -->
                <div class="container lastItemHalf">
                    <div class="col-xs-12 removePaddingLeft">
                        <div class="input-group">
                            <asp:TextBox ID="TextBoxSearch" CssClass="form-control" runat="server"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="ButtonSearch" CssClass="btn btn-default" runat="server" Text="Search" OnClick="ButtonSearch_Click" />
                            </span>
                        </div>
                    </div>

                </div>

                <!-- filters =========================================================== -->
                <div class="container lastItem">


                    <div class="btn-group">
                        <asp:DropDownList ID="DropDownRegion" AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownRegion_SelectedIndexChanged" CssClass="form-control btn-default" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="-1">--Select Region--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSection" ControlToValidate="DropDownRegion" runat="server"></asp:RequiredFieldValidator>
                    </div>

                    <div class="btn-group">
                        <asp:Button ID="ButtonRemoveFilter" runat="server" OnClick="ButtonRemoveFilter_Click" CssClass="form-control btn-danger" Text="Remove Filters" />
                    </div>


                    <div class="page-header noMargin"></div>
                    <div class="clearfix"></div>

                </div>
                <!-- Grid =========================================================== -->

                <%  if (GridMainDetailsUser.HeaderRow != null)
                    {
                        GridMainDetailsUser.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                %>
                <div class="container lastItem">
                    <asp:GridView ID="GridMainDetailsUser" AllowPaging="true" OnPageIndexChanging="GridMainDetailsUser_PageIndexChanging" PageSize="5" UseAccessibleHeader="true" CssClass="grid1000 table table-striped" GridLines="None" DataKeyNames="UserId" runat="server" OnRowCommand="GridMainDetailsUser_RowCommand">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkDelete" CssClass="btn btn-xs btn-danger" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                                    <asp:LinkButton ID="LinkModify" CssClass="btn btn-xs btn-success" runat="server" CommandName="Modify">Modify</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

                <script type="text/javascript">
                    function pageLoad() {
                        $('#GridMainDetailsUser').stacktable();
                    }
                </script>

                <%-- END UPDATE PANEL --%>
            </ContentTemplate>
        </asp:UpdatePanel>

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

    <script>
        $('#GridMainDetailsUser').stacktable();
    </script>
</body>
</html>
