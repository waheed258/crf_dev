<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Registration</title>
    <!-- Favicon and touch icons -->
    <link rel="shortcut icon" href="../assets/dist/img/ico/favicon.png" type="image/x-icon" />
    <!-- Start Global Mandatory Style
         =====================================================================-->
    <!-- jquery-ui css -->
    <link href="../assets/plugins/jquery-ui-1.12.1/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap -->
    <link href="../assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap rtl -->
    <!--<link href="assets/bootstrap-rtl/bootstrap-rtl.min.css" rel="stylesheet" type="text/css"/>-->
    <!-- Lobipanel css -->
    <link href="../assets/plugins/lobipanel/lobipanel.min.css" rel="stylesheet" type="text/css" />

    <!-- Font Awesome -->
    <link href="../assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Pe-icon -->
    <link href="../assets/pe-icon-7-stroke/css/pe-icon-7-stroke.css" rel="stylesheet" type="text/css" />
    <!-- Themify icons -->
    <link href="../assets/themify-icons/themify-icons.css" rel="stylesheet" type="text/css" />
    <!-- End Global Mandatory Style
         =====================================================================-->
    <!-- Start page Label Plugins 
         =====================================================================-->
    <!-- Emojionearea -->
    <link href="../assets/plugins/emojionearea/emojionearea.min.css" rel="stylesheet" type="text/css" />
    <!-- Monthly css -->
    <link href="../assets/plugins/monthly/monthly.css" rel="stylesheet" type="text/css" />
    <!-- End page Label Plugins 
         =====================================================================-->
    <!-- Start Theme Layout Style
         =====================================================================-->
    <!-- Theme style -->
    <link href="../assets/dist/css/stylecrm.css" rel="stylesheet" type="text/css" />
    <!-- Theme style rtl -->
    <!--<link href="assets/dist/css/stylecrm-rtl.css" rel="stylesheet" type="text/css"/>-->
    <!-- End Theme Layout Style
         =====================================================================-->
    <script type="text/javascript">
        function openModal() {
            $('#Success').modal('show');
        }
    </script>
    <style type="text/css">
        .style1 {
            color: #FF0000;
        }
    </style>
</head>
<body class="hold-transition sidebar-mini">
    <form id="form1" runat="server">
        <!--preloader-->
        <%-- <div id="preloader">
            <div id="status"></div>
        </div>--%>
        <!-- Site wrapper -->
        <div class="wrapper">
            <header class="main-header">
                <a href="Registration.aspx" class="logo">
                    <!-- Logo -->
                    <span class="logo-mini">
                        <img src="../assets/dist/img/logo-mini.jpg" alt="" />
                    </span>
                    <span class="logo-lg">
                        <img src="../assets/dist/img/logo.jpg" alt="" />
                    </span>
                </a>
                <!-- Header Navbar -->
                <nav class="navbar navbar-static-top">
                </nav>
            </header>
            <!-- =============================================== -->
            <!-- Left side column. contains the sidebar -->

            <!-- Content Wrapper. Contains page content -->
            <div class="col-sm-12">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <div class="panel panel-bd" id="companylist" runat="server" style="margin-top: 120px; margin-left: 30px; margin-right: 30px">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Registration</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12">
                                <div class="col-sm-6 form-group">
                                    <label class="control-label">Title</label><span class="style1">*</span>
                                    <asp:DropDownList ID="ddlTitle" CssClass="form-control" runat="server" Style="width: 68%">
                                        <asp:ListItem Value="">Title</asp:ListItem>
                                        <asp:ListItem Value="Mr">Mr</asp:ListItem>
                                        <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                        <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                        <asp:ListItem Value="Miss">Miss</asp:ListItem>
                                        <asp:ListItem Value="Dr">Dr</asp:ListItem>
                                        <asp:ListItem Value="Prof">Prof</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="Please select Title" ControlToValidate="ddlTitle"
                                        InitialValue="" Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label class="control-label">First Name </label><span class="style1">*</span>
                                    <asp:TextBox ID="txtFirstName" CssClass="form-control" placeholder="Given Name" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Please enter First Name" ControlToValidate="txtFirstName"
                                        Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label class="control-label">Last Name </label>
                                    <asp:TextBox ID="txtLastName" CssClass="form-control" placeholder="Sur Name" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label class="control-label">SAID</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtSAID" CssClass="form-control" placeholder="SAID" runat="server" MaxLength="13"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSAID" runat="server" ErrorMessage="Please enter SAID" ControlToValidate="txtSAID"
                                        Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rgvSAID" runat="server" ErrorMessage="Please enter 13 digits" ValidationExpression="[0-9]{13}" Display="Dynamic"
                                        ControlToValidate="txtSAID" ForeColor="#f31010" ValidationGroup="Save"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label class="control-label">Province</label><span class="style1">*</span>
                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvProvince" runat="server" ControlToValidate="ddlProvince" Display="Dynamic" ErrorMessage="Please select Province"
                                        ValidationGroup="Save" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label class="control-label">City</label><span class="style1">*</span>
                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity" Display="Dynamic" ErrorMessage="Please select City"
                                        ValidationGroup="Save" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label class="control-label">Mobile</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtMobile" CssClass="form-control" placeholder="Mobile Number" runat="server" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMobileNum" runat="server" ErrorMessage="Please enter Mobile Number" ControlToValidate="txtMobile"
                                        Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rgvMobile" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                        ControlToValidate="txtMobile" ForeColor="#f31010" ValidationGroup="Save"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label class="control-label">Email Id</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtEmailId" CssClass="form-control" runat="server" placeholder="Email ID"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmailId" Display="Dynamic"
                                        ErrorMessage="Enter Email ID"
                                        ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmailId" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please check Email Format"
                                        ControlToValidate="txtEmailId" CssClass="form-control" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Save">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer" style="border-top: 0px !important;">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="btnRegistration" runat="server" Text="Submit" ValidationGroup="Save" CssClass="btn btn-primary" OnClick="btnRegistration_Click"></asp:Button>
                            <asp:Button ID="btnegistrationCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnegistrationCancel_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-2"></div>
            <div class="modal fade" id="Success" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                            <h3><i class="fa fa-user m-r-5"></i>Thank you</h3>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <fieldset>
                                        <div class="col-md-12 form-group user-form-group">
                                            <asp:Label ID="lblMessage" runat="server" Style="color: green"></asp:Label>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger pull-left" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </div>
        <!-- /.wrapper -->
        <!-- Start Core Plugins
         =====================================================================-->
        <!-- jQuery -->
        <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js" type="text/javascript"></script>
        <!-- jquery-ui -->
        <script src="../assets/plugins/jquery-ui-1.12.1/jquery-ui.min.js" type="text/javascript"></script>
        <!-- Bootstrap -->
        <script src="../assets/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
        <!-- lobipanel -->
        <script src="../assets/plugins/lobipanel/lobipanel.min.js" type="text/javascript"></script>
        <!-- Pace js -->
        <script src="../assets/plugins/pace/pace.min.js" type="text/javascript"></script>
        <!-- SlimScroll -->
        <script src="../assets/plugins/slimScroll/jquery.slimscroll.min.js" type="text/javascript">    </script>
        <!-- FastClick -->
        <script src="../assets/plugins/fastclick/fastclick.min.js" type="text/javascript"></script>
        <!-- CRMadmin frame -->
        <script src="../assets/dist/js/custom.js" type="text/javascript"></script>
        <!-- End Core Plugins
         =====================================================================-->
        <!-- Start Page Lavel Plugins
         =====================================================================-->
        <!-- ChartJs JavaScript -->
        <script src="../assets/plugins/chartJs/Chart.min.js" type="text/javascript"></script>
        <!-- Counter js -->
        <script src="../assets/plugins/counterup/waypoints.js" type="text/javascript"></script>
        <script src="../assets/plugins/counterup/jquery.counterup.min.js" type="text/javascript"></script>
        <!-- Monthly js -->
        <script src="../assets/plugins/monthly/monthly.js" type="text/javascript"></script>
        <!-- End Page Lavel Plugins
         =====================================================================-->
        <!-- Start Theme label Script
         =====================================================================-->
        <!-- Dashboard js -->
        <script src="../assets/dist/js/dashboard.js" type="text/javascript"></script>
        <!-- End Theme label Script
         =====================================================================-->
    </form>
</body>
<script type="text/javascript">
    $("#txtSAID,#txtMobile").bind('keypress', function (e) {
        if (e.keyCode == '9' || e.keyCode == '16') {
            return;
        }
        var code;
        if (e.keyCode) code = e.keyCode;
        else if (e.which) code = e.which;
        if (e.which == 46)
            return false;
        if (code == 8 || code == 46)
            return true;
        if (code < 48 || code > 57)
            return false;
    });
    $("#txtSAID,#txtMobile").bind('mouseenter', function (e) {
        var val = $(this).val();
        if (val != '0') {
            val = val.replace(/[^0-9]+/g, "");
            $(this).val(val);
        }
    });
</script>
</html>
