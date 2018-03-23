<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Layout.master" AutoEventWireup="true" CodeFile="NewAdvisor.aspx.cs" Inherits="Admin_NewAdvisor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">

            <div class="header-title">
                <h1>Add Advisor</h1>
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
                                <h5>Add Advisor</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>First Name</label>
                                    <input type="text" class="form-control" placeholder="Enter First Name" required ng-model="FirstName">
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Last Name</label>
                                    <input type="text" class="form-control" placeholder="Enter last Name" required ng-model="LastName">
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Mobile</label>
                                    <input type="text" class="form-control" placeholder="Enter Mobile" required ng-model="MobileNumber" maxlength="10" id="MobileNumber" name="MobileNumber">
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Phone</label>
                                    <input type="text" class="form-control" placeholder="Enter Phone" ng-model="PhoneNumber" maxlength="10" id="PhoneNumber" name="PhoneNumber">
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Email</label>
                                    <input type="email" class="form-control" placeholder="Enter Email" required ng-model="EmailId">
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Login ID</label>
                                    <input type="text" class="form-control" placeholder="Login ID" ng-model="LoginId" required>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Password</label>
                                    <input type="password" class="form-control" placeholder="Password" required id="password" ng-model="Password">
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Confirm Password</label>
                                    <input type="password" class="form-control" placeholder="Confirm Password" required id="confirm_password" ng-model="ConfirmPassword">
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Designation</label>
                                    <select class="form-control" ng-model="DType" required>
                                        <option value="" selected>Choose Designation</option>
                                        <option ng-repeat="DType in DesignationTypes" value="{{DType.DesignationID}}">{{DType.Designation}}</option>
                                    </select>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Branch</label>
                                    <select class="form-control" ng-model="Btype" required>
                                        <option value="" selected>Choose Branch</option>
                                        <option ng-repeat="Btype in Branchs" value="{{Btype.BranchID}}">{{Btype.BranchName}}</option>
                                    </select>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Advisor Type</label>
                                    <select class="form-control" ng-model="ConsultantType" required>
                                        <option value="" selected>Choose Consultant Type</option>
                                        <option ng-repeat="ConsultantType in ConsultantTypes"
                                            value="{{ConsultantType.AdvisorTypeID}}">{{ConsultantType.AdvisorType}}
                                        </option>
                                    </select>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Status</label>
                                    <select class="form-control" ng-model="Status" required>
                                        <option value="" selected>Choose User Status</option>
                                        <option ng-repeat="Status in Statues"
                                            value="{{Status.AdvisorStatusID}}">{{Status.AdvisorStatus}}
                                        </option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Role</label>
                                    <select class="form-control" ng-model="RType" required>
                                        <option value="" selected>Choose Role</option>
                                        <option ng-repeat="RType in AdvisorRoleTypes" value="{{RType.RoleID}}">{{RType.Role}}</option>
                                    </select>
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
                                        <label class="control-label" style="color: green">Advisor Added Successfully!</label>
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
                                        <label class="control-label" style="color: green">Something went wrong, please try again!</label>
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
        var password = document.getElementById("password")
      , confirm_password = document.getElementById("confirm_password");

        function validatePassword() {
            if (password.value != confirm_password.value) {
                confirm_password.setCustomValidity("This field should match with Password");
            } else {
                confirm_password.setCustomValidity('');
            }
        }

        password.onchange = validatePassword;
        confirm_password.onkeyup = validatePassword;

        function ValidateNo() {
            var mobilenumber = document.getElementById("MobileNumber");

            if (mobilenumber.value.length < 10 || mobilenumber.value.length > 10) {
                MobileNumber.setCustomValidity("Please enter Valid Mobile Number.");
            }
            else {
                MobileNumber.setCustomValidity('');
            }
        }
        MobileNumber.onkeyup = ValidateNo;

        $("#MobileNumber").bind('keypress', function (e) {
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
        $("#MobileNumber").bind('mouseenter', function (e) {
            var val = $(this).val();
            if (val != '0') {
                val = val.replace(/[^0-9]+/g, "");
                $(this).val(val);
            }
        });


        function ValidateNo1() {
            var phonenumber = document.getElementById("PhoneNumber");

            if (phonenumber.value.length < 10 || phonenumber.value.length > 10) {
                PhoneNumber.setCustomValidity("Please enter Valid Phone Number.");
            }
            else {
                PhoneNumber.setCustomValidity('');
            }
        }
        PhoneNumber.onkeyup = ValidateNo1;



        $("#PhoneNumber").bind('keypress', function (e) {
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
        $("#PhoneNumber").bind('mouseenter', function (e) {
            var val = $(this).val();
            if (val != '0') {
                val = val.replace(/[^0-9]+/g, "");
                $(this).val(val);
            }
        });
    </script>

</asp:Content>

