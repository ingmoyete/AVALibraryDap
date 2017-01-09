<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Library.Web.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Login Page</title>

    <!-- Latest compiled and minified CSS and style -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />
    <link href="css.css" rel="stylesheet" />
    <!-- End Latest compiled and minified CSS and style -->

</head>
<body id="loginPage">
    <div class="container"></div>
    <form id="LoginPage" class="form-signin" runat="server">
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
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>

        <!-- Login =========================================================== -->
        <h2 class="form-signin-heading">Please sign in</h2>
        <label for="inputEmail" class="sr-only">Email address</label>

        <%this.inputEmail.Attributes.Add("placeholder", "Email address"); %>
        <asp:TextBox ID="inputEmail" CssClass="form-control" runat="server"></asp:TextBox>
        <%--<input type="email" id="inputEmail" class="form-control" placeholder="Email address" required autofocus>--%>

        <%this.inputPassword.Attributes.Add("placeholder", "Password"); %>
        <label for="inputPassword" class="sr-only">Password</label>
        <asp:TextBox ID="inputPassword" CssClass="form-control lastItemHalf" runat="server"></asp:TextBox>
        <%--<input type="password" id="inputPassword" class="form-control" placeholder="Password" required>--%>

        <%--        <div class="checkbox">
            <label>
                <input type="checkbox" value="remember-me">
                Remember me
            </label>
        </div>--%>
        <asp:Button ID="ButtonSubmit" OnClick="ButtonSubmit_Click" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Button" />
        <%--<button class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>--%>
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
