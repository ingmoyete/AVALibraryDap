<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="MainList.aspx.cs" Inherits="Library.Web.UI.Book.MainList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Book Main List</title>

    <!-- Latest compiled and minified CSS and style -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />
    <link href="../css/stacktable.css" rel="stylesheet" />
    <link href="../jsFiles/bootstrapPagination.css" rel="stylesheet" />
    <link href="../css.css" rel="stylesheet" />
    <!-- End Latest compiled and minified CSS and style -->
</head>
<body>
    <form id="MainListBooks" runat="server">
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
                        <li class="active"><a href="MainList.aspx">Books</a></li>
                        <li><a href="../Users/MainList.aspx">Users</a></li>
                        <li><a href="../Loan/MainListLoan.aspx">Loans</a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>

        <!-- Jumbotron =========================================================== -->
        <div class="container">
            <div class="jumbotron">
                <h1 class="h1Jumbotron">Book List</h1>
                <p>You can modify, delete and insert books. Select a record to see all the copies for a book</p>
                <a href="Insert.aspx" class="insertButton btn btn-sm btn-warning">Insert a New book</a>
            </div>
        </div>


        <%-- UPDATE PANEL --%>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelBookSearch" runat="server">
            <ContentTemplate>

                <!-- Search   =========================================================== -->
                <div class="container lastItemHalf">
                    <div class="col-xs-12 removePaddingLeft">
                        <div class="input-group">
                            <asp:TextBox ID="TextBoxSearch" CssClass="form-control" runat="server"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="ButtonSearch" OnClick="ButtonSearch_Click" CssClass="btn btn-default" runat="server" Text="Search" />
                            </span>
                        </div>
                    </div>

                </div>
                <!-- filters =========================================================== -->
                <div class="container lastItem">


                    <div class="btn-group">
                        <asp:DropDownList ID="DropDownSection" AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownSection_SelectedIndexChanged" CssClass="form-control btn-default" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="-1">--Select Section--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSection" ControlToValidate="DropDownSection" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    <div class="btn-group">
                        <asp:DropDownList ID="DropDownCopies" AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownCopies_SelectedIndexChanged" CssClass="form-control btn-default" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="-1">--Select Copies--</asp:ListItem>
                            <asp:ListItem Value="1">&lt; 5 copies</asp:ListItem>
                            <asp:ListItem Value="2">&gt; 5 Copies</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCopies" ControlToValidate="DropDownCopies" runat="server"></asp:RequiredFieldValidator>
                    </div>

                    <div class="btn-group">
                        <asp:Button ID="ButtonRemoveFilter" OnClick="ButtonRemoveFilter_Click" runat="server" CssClass="form-control btn-danger" Text="Remove Filters" />
                    </div>


                    <div class="page-header noMargin"></div>
                    <div class="clearfix"></div>

                </div>


                <!-- Grid =========================================================== -->
                <%  if (GridMainList.HeaderRow != null)
                    {
                        GridMainList.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                         
                      
                %>

                <div class="container lastItem">
                    <asp:GridView ID="GridMainList" AllowPaging="true" OnPageIndexChanging="GridMainList_PageIndexChanging" PageSize="5" UseAccessibleHeader="true" CssClass="table-striped table" GridLines="None" runat="server" DataKeyNames="BookId" OnRowCommand="GridMainList_RowCommand">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkModify" CssClass="btn btn-xs btn-success" CommandName="Modify" runat="server">Modify</asp:LinkButton>
                                    <asp:LinkButton ID="LinkDelete" CssClass="btn btn-xs btn-danger" CommandName="Delete" runat="server">Delete</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" CssClass="btn btn-xs btn-default" CommandName="Copies" runat="server">See All Copies</asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

                <script type="text/javascript">
                    function pageLoad() {
                        $('#GridMainList').stacktable();
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
    <%-- Stacktable --%>
    <script>
        $('#GridMainList').stacktable();
    </script>

</body>
</html>
