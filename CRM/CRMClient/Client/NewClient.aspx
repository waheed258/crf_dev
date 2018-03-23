<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Layout.master" AutoEventWireup="true" CodeFile="NewClient.aspx.cs" Inherits="Client_NewClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <form name="clientForm" runat="server">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <div class="header-title">
                    <h1>Client Registration</h1>
                </div>
            </section>
            <!-- Main content -->
            <section class="content">
                <div class="row">
                    <!-- Form controls -->
                    <div class="col-sm-12">
                        <div class="panel panel-bd">
                            <div class="panel-heading">
                                <div class="panel-title">
                                    <h5>Add Client</h5>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="col-md-12">
                                    <div class="form-group col-sm-3">
                                        <label>Title</label>
                                        <asp:DropDownList ID="ddlTitle" runat="server" class="form-control">
                                            <asp:ListItem Value="">Title</asp:ListItem>
                                            <asp:ListItem Value="Mr">Mr</asp:ListItem>
                                            <asp:ListItem Value="Miss">Miss</asp:ListItem>
                                            <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                            <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                            <asp:ListItem Value="Dr">Dr</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-sm-3">
                                        <label>First Name</label>
                                        <asp:TextBox ID="txtFirstName" runat="server" class="form-control" placeholder="Enter Given Name"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-sm-3">
                                        <label>Last Name</label>
                                        <asp:TextBox ID="txtLastName" runat="server" class="form-control" placeholder="Enter Sur Name"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-sm-3">
                                        <label>SAID</label>
                                        <input type="text" class="form-control" placeholder="SA ID" id="SAID" ng-model="SAID" required maxlength="13">
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group col-sm-3">
                                        <label>Company</label>
                                        <input type="text" class="form-control" placeholder="Company" ng-model="Company">
                                    </div>
                                    <div class="form-group col-sm-3">
                                        <label>Company Registration Number</label>
                                        <input type="text" class="form-control" placeholder="Company Registration No." ng-model="CompanyRegNo">
                                    </div>
                                    <div class="form-group col-sm-3">
                                        <label>Trust</label>
                                        <input type="text" class="form-control" placeholder="Trust" ng-model="Trust">
                                    </div>
                                    <div class="form-group col-sm-3">
                                        <label>Trust Registration Number</label>
                                        <input type="text" class="form-control" placeholder="Trust Registration No." ng-model="TrustRegNo">
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group col-sm-3">
                                        <label>Mobile</label>
                                        <input type="text" class="form-control" placeholder="Enter Mobile" required ng-model="Mobile" maxlength="10" id="Mobile" name="Mobile">
                                    </div>
                                    <div class="form-group col-sm-3">
                                        <label>Email</label>
                                        <input type="email" class="form-control" placeholder="Enter Email" required ng-model="EmailId">
                                    </div>

                                </div>
                            </div>
                            <div class="panel-footer">
                                <div class="col-sm-5"></div>
                                <button type="submit" class="btn btn-primary">Save</button>
                                <button type="button" class="btn btn-danger" ng-click="Cancel()">Cancel</button>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- /.content -->
        </form>
        <div class="modal fade" id="Success" tabindex="-1" role="dialog" aria-hidden="true">
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
                                        <label class="control-label" style="color: green">Client Added Successfully!</label>
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
        <div class="modal fade" id="Failure" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header modal-header-primary">
                        <h3><i class="fa fa-user m-r-5"></i>Sorry</h3>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <div class="col-md-12 form-group user-form-group">
                                        <label class="control-label" style="color: green">EmailID or SAID already exists!</label>
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
    <script type="text/javascript">
        $("#SAID").bind('keypress', function (e) {
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
        $("#SAID").bind('mouseenter', function (e) {
            var val = $(this).val();
            if (val != '0') {
                val = val.replace(/[^0-9]+/g, "");
                $(this).val(val);
            }
        });
        $("#Mobile").bind('keypress', function (e) {
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
        $("#Mobile").bind('mouseenter', function (e) {
            var val = $(this).val();
            if (val != '0') {
                val = val.replace(/[^0-9]+/g, "");
                $(this).val(val);
            }
        });

        function ValidateNo() {
            var mobilenumber = document.getElementById("Mobile");

            if (mobilenumber.value.length < 10 || mobilenumber.value.length > 10) {
                Mobile.setCustomValidity("Please enter Valid Mobile Number.");
            }
            else {
                Mobile.setCustomValidity('');
            }
        }
        Mobile.onkeyup = ValidateNo;

        function ValidateSAID() {
            var said = document.getElementById("SAID");

            if (said.value.length < 13 || said.value.length > 13) {
                SAID.setCustomValidity("Please enter Valid SAID");
            }
            else {
                SAID.setCustomValidity('');
            }
        }
        SAID.onkeyup = ValidateSAID;
    </script>
</asp:Content>

