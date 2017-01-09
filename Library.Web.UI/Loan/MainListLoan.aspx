<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainListLoan.aspx.cs" Inherits="Library.Web.UI.Loan.MainListLoan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Loan Main List</title>

    <!-- Latest compiled and minified CSS and style -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />

    <link href="../css/stacktable.css" rel="stylesheet" />
    <link href="../jsFiles/bootstrapPagination.css" rel="stylesheet" />

    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <link href="../css.css" rel="stylesheet" />
    <!-- End Latest compiled and minified CSS and style -->
</head>
<body>
    <form id="MainListLoans" runat="server">
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
                        <li><a href="../Users/MainList.aspx">Users</a></li>
                        <li class="active"><a href="MainListLoan.aspx">Loans</a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>

        <!-- Jumbotron =========================================================== -->
        <div class="container">
            <div class="jumbotron">
                <h1 class="h1Jumbotron">Loan List</h1>
                <p>You can modify, delete and insert Loans.</p>
                <a href="InsertLoan.aspx" class="insertButton btn btn-sm btn-warning">Insert a New Loan</a>
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
                        <asp:DropDownList ID="DropDownSection" AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownRegion_SelectedIndexChanged" CssClass="form-control btn-default" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="-1">--Select Section--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSection" ControlToValidate="DropDownSection" runat="server"></asp:RequiredFieldValidator>
                    </div>

                    <div class="btn-group">
                        <asp:TextBox ID="TextBoxDelivery" Text="--Select Delivery Date--" OnTextChanged="TextBoxDelivery_TextChanged" CssClass="datePick form-control btn-default" runat="server" AutoPostBack="true"></asp:TextBox>
                    </div>

                    <div class="btn-group">
                        <asp:TextBox ID="TextBoxLoan" Text="--Select Loan Date--" OnTextChanged="TextBoxLoan_TextChanged" CssClass="datePick form-control btn-default" runat="server" AutoPostBack="true"></asp:TextBox>
                    </div>

                    <div class="btn-group">
                        <asp:Button ID="ButtonRemoveFilter" runat="server" OnClick="ButtonRemoveFilter_Click" CssClass="form-control btn-danger" Text="Remove Filters" />
                    </div>


                    <div class="page-header noMargin"></div>
                    <div class="clearfix"></div>

                </div>

                <!-- Grid =========================================================== -->
                <%  if (GridListLoans.HeaderRow != null)
                    {
                        GridListLoans.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                %>

                <div class="container lastItem">
                    <asp:GridView ID="GridListLoans" AllowPaging="true" PageSize="5" OnPageIndexChanging="GridListLoans_PageIndexChanging" UseAccessibleHeader="true" CssClass="grid1000 table table-striped" GridLines="None" runat="server" OnRowCommand="GridListLoans_RowCommand" DataKeyNames="LoanId">

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

                <script type="text/javascript">
                    function pageLoad() {
                        $('#GridListLoans').stacktable();
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

    <!-- Js files =========================================================== -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <%-- Include plugins here --%>
    <script src="../jsFiles/jquery.validate.min.js"></script>
    <script src="../jsFiles/additional-methods.min.js"></script>
    <script src="../jsFiles/stacktable.js"></script>
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

    <script>
        $('#GridListLoans').stacktable();
    </script>

</body>
</html>
