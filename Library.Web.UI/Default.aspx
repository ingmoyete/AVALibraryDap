<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Library.Web.UI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Default Page</title>

    <!-- Latest compiled and minified CSS and style -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />
    <link href="css.css" rel="stylesheet" />
    <!-- End Latest compiled and minified CSS and style -->

</head>
<body id="defaultPage">
    <form id="form1" runat="server">

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
                    <a class="navbar-brand" href="#" id="brand">Library</a>
                </div>
                <div id="navbar" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a href="Book/MainList.aspx">Books</a></li>
                        <li><a href="Users/MainList.aspx">Users</a></li>
                        <li><a href="Loan/MainListLoan.aspx">Loans</a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>

            <!-- Jumbotron =========================================================== -->
    <div class="container">
        <div class="jumbotron" style="margin: 70px 0 0 0;">
            <h1 class="h1Jumbotron" style="padding: 0 15px 0 15px;">Library IntraNet</h1>
            <p style="padding: 0 15px 0 15px;">This is a test application</p>
        </div>
    </div>

        <!-- Carousel
    ================================================== -->
<%--        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol>
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <img class="first-slide" src="images/twitter_bootstrap-wallpaper-1920x1440%20-%20Copy.jpg" alt="First slide" />
                    <div class="container">
                        <div class="carousel-caption">
                            <h1>Responsive</h1>
                            <p>This website is responsive thanks to bootstrap. Go to its web site for more information</p>
                            <p><a class="btn btn-lg btn-primary" href="#" role="button">Sign up today</a></p>
                        </div>
                    </div>
                </div>
                <div class="item">
                    <img class="second-slide" src="images/drupal-and-jquery-logos%20-%20Copy.png" alt="Second slide" />
                    <div class="container">
                        <div class="carousel-caption">
                            <h1>JavaScript</h1>
                            <p>Client validations and different plugins such as StackTable, Jquery Validations, DatePicker are implemented by using jquery.</p>
                            <p><a class="btn btn-lg btn-danger" href="#" role="button">Learn more</a></p>
                        </div>
                    </div>
                </div>
                <div class="item">
                    <img class="third-slide" src="images/microsoft-dotnet%20-%20Copy.jpg" alt="Third slide" />
                    <div class="container">
                        <div class="carousel-caption">
                            <h1>ASP.NET</h1>
                            <p>This scrum app was created by using the web form .net framework.</p>
                            <p><a class="btn btn-lg btn-warning" href="#" role="button">Browse gallery</a></p>
                        </div>
                    </div>
                </div>
            </div>
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>--%>
        <!-- /.carousel -->
        <!-- End of form =========================================================== -->

    </form>

    <div class="clearfix"></div>

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
