<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientRegistration.aspx.cs" Inherits="AdminForms_ClientRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Auditions Registration Form Widget Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- //for-mobile-apps -->
    <!-- //custom-theme -->

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



    <link href="../css/style.css" rel="stylesheet" type="text/css" media="all" />

    <!-- js -->
    <script type="text/javascript" src="../js/jquery-2.1.4.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- //js -->

    <!-- font-awesome-icons -->
    <!-- //font-awesome-icons -->
    <link href="//fonts.googleapis.com/css?family=Anton&amp;subset=latin-ext,vietnamese" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
                <div class="center-container">
                    <div class="">
                        <div class="main">

                            <div class="w3layouts_main_grid">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <h1 class="w3layouts_head" style="text-decoration: underline">Activ8 Client Registration</h1>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <label></label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                                            <span class="agileits_grid">
                                                <label>Title</label>
                                                <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 68%">
                                                    <asp:ListItem Value="-1">--Select Title--</asp:ListItem>
                                                    <asp:ListItem Value="Mr">Mr</asp:ListItem>
                                                    <asp:ListItem Value="Miss">Miss</asp:ListItem>
                                                    <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                                    <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                                    <asp:ListItem Value="Dr">Dr</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="Please select Title" ControlToValidate="ddlTitle"
                                                    InitialValue="-1" Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                        <div class="col-lg-4">
                                            <span class="agileits_grid">
                                                <label>First Name </label>
                                                <asp:TextBox ID="txtFirstName" placeholder="Given Name" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Please enter First Name" ControlToValidate="txtFirstName"
                                                    Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>
                                        <div class="col-lg-4">
                                            <span class="agileits_grid">
                                                <label>Last Name </label>
                                                <asp:TextBox ID="txtLastName" placeholder="Sur Name" runat="server"></asp:TextBox>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                                            <span class="agileits_grid">
                                                <label>SAID</label>
                                                <asp:TextBox ID="txtSAID" placeholder="SAID" runat="server" MaxLength="13"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvSAID" runat="server" ErrorMessage="Please enter SAID" ControlToValidate="txtSAID"
                                                    Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rgvSAID" runat="server" ErrorMessage="Please enter 13 digits" ValidationExpression="[0-9]{13}" Display="Dynamic"
                                                    ControlToValidate="txtSAID" ForeColor="#f31010" ValidationGroup="Save"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-lg-4">
                                            <span class="agileits_grid">
                                                <label>Mobile</label>
                                                <asp:TextBox ID="txtMobile" placeholder="Mobile Number" runat="server" MaxLength="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvMobileNum" runat="server" ErrorMessage="Please enter Mobile Number" ControlToValidate="txtMobile"
                                                    Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rgvMobile" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                    ControlToValidate="txtMobile" ForeColor="#f31010" ValidationGroup="Save"></asp:RegularExpressionValidator>
                                            </span>
                                        </div>
                                        <div class="col-lg-4">
                                            <span class="agileits_grid">
                                                <label>Email ID</label>
                                                <asp:TextBox ID="txtEmailId" placeholder="Email ID" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvEmailID" runat="server" ErrorMessage="Please enter Email ID" ControlToValidate="txtEmailId"
                                                    Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                            </span>
                                        </div>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                                            <span class="agileits_grid">
                                                <label>Company</label>
                                                <asp:TextBox ID="txtCompanyName" placeholder="Company Name" runat="server"></asp:TextBox>
                                            </span>
                                        </div>
                                        <div class="col-lg-4">
                                            <span class="agileits_grid">
                                                <label>Number</label>
                                                <asp:TextBox ID="txtComRegNum" placeholder="Company Registration Number" runat="server"></asp:TextBox>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                                            <span class="agileits_grid">
                                                <label>Trust</label>
                                                <asp:TextBox ID="txtTrust" placeholder="Trust Name" runat="server"></asp:TextBox>
                                            </span>
                                        </div>
                                        <div class="col-lg-4">
                                            <span class="agileits_grid">
                                                <label>Number</label>
                                                <asp:TextBox ID="txtTrustNum" placeholder="Trust Registration Number" runat="server"></asp:TextBox>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                                            <div class="w3_main_grid_right">
                                                <span class="agileits_grid">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="Save" OnClick="btnSubmit_Click" />
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="background: #f31010;" />
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
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
                                                            <label class="control-label" style="color: green">You Registered Successfully. One of our Avisors will contact you soon!</label>
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
                    </div>
                </div>
          <%--  </ContentTemplate>
        </asp:UpdatePanel>--%>
        <!-- banner -->
        <!-- //footer -->
    </form>
    <script type="text/javascript">
        function openModal() {
            $('#Success').modal('show');
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function (event) {
            $("#txtMobile").bind('keypress', function (e) {
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
            $("#txtMobile").bind('mouseenter', function (e) {
                var val = $(this).val();
                if (val != '0') {
                    val = val.replace(/[^0-9]+/g, "");
                    $(this).val(val);
                }
            });

            $("#txtSAID").bind('keypress', function (e) {
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
            $("#txtSAID").bind('mouseenter', function (e) {
                var val = $(this).val();
                if (val != '0') {
                    val = val.replace(/[^0-9]+/g, "");
                    $(this).val(val);
                }
            });
        })
    </script>
</body>
</html>
