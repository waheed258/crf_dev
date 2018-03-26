<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>CRM Login</title>

    <!-- Favicon and touch icons -->
    <link rel="shortcut icon" href="../assets/dist/img/ico/favicon.png" type="image/x-icon" />
    <!-- Bootstrap -->
    <link href="../assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap rtl -->
    <!--<link href="assets/bootstrap-rtl/bootstrap-rtl.min.css" rel="stylesheet" type="text/css"/>-->
    <!-- Pe-icon-7-stroke -->
    <link href="../assets/pe-icon-7-stroke/css/pe-icon-7-stroke.css" rel="stylesheet" type="text/css" />
    <!-- style css -->
    <link href="../assets/dist/css/stylecrm.css" rel="stylesheet" type="text/css" />
    <!-- Theme style rtl -->
    <!--<link href="assets/dist/css/stylecrm-rtl.css" rel="stylesheet" type="text/css"/>-->
</head>
<body>
    <form id="form1" runat="server">
        <!-- Content Wrapper -->
        <div class="login-wrapper">

            <div class="container-center">
                <div class="login-area">
                    <div class="panel panel-bd panel-custom">
                        <div class="panel-heading">
                            <div class="view-header">
                                <div class="header-icon">
                                    <i class="pe-7s-unlock"></i>
                                </div>
                                <div class="header-title">
                                    <h3>Login</h3>
                                    <small><strong>Please enter your credentials to login.</strong></small>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">

                            <div class="form-group">
                                <label class="control-label" for="username">Username</label>
                                <asp:TextBox ID="txtUserName" placeholder="example@gmail.com" runat="server" class="form-control"></asp:TextBox>
                                <span class="help-block small">Your unique username to app</span>
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="password">Password</label>
                                <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="******" runat="server" class="form-control"></asp:TextBox>
                                <span class="help-block small">Your strong password</span>
                            </div>
                            <div>
                                <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-add" OnClick="btnLogin_Click" />
                                <asp:Label ID="lblError" runat="server" style="color:red"></asp:Label>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.content-wrapper -->
        <!-- jQuery -->
        <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js" type="text/javascript"></script>
        <!-- bootstrap js -->
        <script src="../assets/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    </form>
</body>
</html>
