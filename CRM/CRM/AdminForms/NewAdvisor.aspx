﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="NewAdvisor.aspx.cs" Inherits="AdminForms_NewAdvisor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function (event) {
            $("#ContentPlaceHolder1_txtMobileNum,#ContentPlaceHolder1_txtPhoneNum,#ContentPlaceHolder1_txtSAId").bind('keypress', function (e) {
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
            $("#ContentPlaceHolder1_txtMobileNum,#ContentPlaceHolder1_txtPhoneNum,#ContentPlaceHolder1_txtSAId").bind('mouseenter', function (e) {
                var val = $(this).val();
                if (val != '0') {
                    val = val.replace(/[^0-9]+/g, "");
                    $(this).val(val);
                }
            });


        })
    </script>
    <script type="text/javascript">
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show');
        }

    </script>
    <style type="text/css">
        .style1 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="header-title">
                <h1>Advisor</h1>
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
                                    <div class="col-sm-11" style="padding: 0px;">
                                        <label>SAID</label><span class="style1">*</span>
                                        <asp:TextBox ID="txtSAId" class="form-control" runat="server" placeholder="Enter SAID" MaxLength="13"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvSAId" runat="server" ControlToValidate="txtSAId" ForeColor="#d0582e"
                                            ErrorMessage="Please Enter SAID" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revtxtSAId" runat="server" ErrorMessage="Please enter 13 digits" ValidationExpression="[0-9]{13}" Display="Dynamic"
                                            ControlToValidate="txtSAId" ForeColor="#f31010" ValidationGroup="Save"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-sm-1" style="padding: 0px; margin-top: 14px;">
                                        <asp:ImageButton ID="imgSearchsaid" runat="server" ImageUrl="~/assets/dist/img/search-icon.png" Height="35" Width="35" ToolTip="Search" OnClick="imgSearchsaid_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>First Name</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtFirstName" class="form-control" runat="server" placeholder="Enter First Name" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter First Name" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Last Name</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtLastName" class="form-control" runat="server" placeholder="Enter Last Name" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Last Name" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Mobile</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtMobileNum" class="form-control" runat="server" placeholder="Enter Mobile Number" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMobileNum" runat="server" ControlToValidate="txtMobileNum" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Mobile" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMobileNum" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                        ControlToValidate="txtMobileNum" ForeColor="#d0582e" ValidationGroup="Advisor"></asp:RegularExpressionValidator>
                                </div>

                            </div>

                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Phone</label>
                                    <asp:TextBox ID="txtPhoneNum" class="form-control" runat="server" placeholder="Enter Phone Number" MaxLength="10"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revPhoneNum" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                        ControlToValidate="txtPhoneNum" ForeColor="#d0582e" ValidationGroup="Advisor"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Email</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtEmailId" class="form-control" runat="server" placeholder="Enter EmailId" MaxLength="75"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtEmailId" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Email" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmailId" runat="server" ForeColor="#d0582e" Display="Dynamic" ErrorMessage="Please check Email Format"
                                        ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Advisor">
                                    </asp:RegularExpressionValidator>
                                </div>


                                <div class="form-group col-sm-3">
                                    <label>Designation</label><span class="style1">*</span>
                                    <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvDesignation" runat="server" ControlToValidate="ddlDesignation" ForeColor="#d0582e"
                                        ErrorMessage="Please Select Designation" ValidationGroup="Advisor" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <asp:Label ID="lblAdvisorType" runat="server">Advisor Type</asp:Label>
                                    <asp:DropDownList ID="ddlAdvisorType" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                    <asp:CheckBox ID="chkIscontentValidator" runat="server" Text="Content Validator" />
                                    <asp:RequiredFieldValidator ID="rfvAdvisorType" runat="server" ControlToValidate="ddlAdvisorType" ForeColor="#d0582e"
                                        ErrorMessage="Please Select Advisor Type" ValidationGroup="Advisor" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>



                            </div>
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Login ID</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtLoginId" class="form-control" runat="server" placeholder="Enter LoginId" MaxLength="50" OnTextChanged="txtLoginId_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:Label ID="msgLoginId" runat="server" class="control-label" Style="color: red" />
                                    <asp:RequiredFieldValidator ID="rfvLoginId" runat="server" ControlToValidate="txtLoginId" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Login ID" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Password</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control" runat="server" placeholder="Enter Password" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Password" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Confirm Password</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtConfirmPassword" TextMode="Password" class="form-control" runat="server" placeholder="Enter Confirm Password" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Confirm Password" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                        ControlToCompare="txtPassword" Operator="Equal" Text="Should match with Password"
                                        ErrorMessage="Should match with Password" class="validationred"
                                        ValidationGroup="Advisor" Display="Dynamic" ForeColor="#d0582e"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Branch</label><span class="style1">*</span>
                                    <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvBranch" runat="server" ControlToValidate="ddlBranch" ForeColor="#d0582e"
                                        ErrorMessage="Please Select Branch" ValidationGroup="Advisor" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group col-sm-3">
                                    <label>Status</label><span class="style1">*</span>
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlStatus" ForeColor="#d0582e"
                                        ErrorMessage="Please Select Status" ValidationGroup="Advisor" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <%--  <div class="form-group col-sm-3">
                                    <label>Role</label>
                                    <asp:DropDownList ID="ddlRole" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvRole" runat="server" ControlToValidate="ddlRole" ForeColor="#d0582e"
                                        ErrorMessage="Please Select Role" ValidationGroup="Advisor" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>--%>
                            </div>



                        </div>
                        <div class="panel-footer">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-add" ValidationGroup="Advisor" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- /.content -->

        <div class="modal fade" id="Success" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header modal-header-primary">
                        <h3><asp:Label ID="lblTitle" runat="server" class="control-label"/></h3>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <div class="col-md-12 form-group user-form-group">
                                        <asp:Label ID="message" runat="server" class="control-label"></asp:Label>
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

</asp:Content>

