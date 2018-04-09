<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Change Password</title>

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
    <script src="../Scripts/jquery-1.10.2.min.js"></script>   
</head>
<body>
    <form id="form1" runat="server">
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
                                    <h3>Change Password</h3>
                                    <small><strong>Please Change your passowrd.</strong></small>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <label class="control-label" for="password">Create Password</label>
                                <asp:TextBox ID="txtCreatePassword" TextMode="Password" placeholder="******" runat="server" class="form-control"></asp:TextBox>
                                <span class="help-block small">Your strong password</span>
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="password">Confirm Password</label>
                                <asp:TextBox ID="txtConfirmPassword" TextMode="Password" placeholder="******" runat="server" class="form-control"></asp:TextBox>
                                <span class="help-block small">Your strong password</span>
                            </div>
                            <div>
                                <asp:Button ID="btnLogin" runat="server" Text="Change" class="btn btn-add" OnClick="btnLogin_Click" />
                                <asp:Label ID="lblError" runat="server" Style="color: red"></asp:Label>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>     
        <!-- /.content-wrapper -->
        <!-- jQuery -->
       <%-- <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js" type="text/javascript"></script>--%>
        <!-- bootstrap js -->
        <script src="../assets/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    </form>
</body>
</html>
