﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ClientForms/Layout.master" AutoEventWireup="true" CodeFile="Beneficiary.aspx.cs" Inherits="ClientForms_Beneficiary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtDateOfBirth").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0",
                dateFormat: 'yy-mm-dd',
                //numberOfMonths: 1,               
            });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtYearofFoundation").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0",
                dateFormat: 'yy-mm-dd',
                //numberOfMonths: 1,               
            });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#target").keyup(function () {
                if ($("[id *=target]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvBeneficiary]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvBeneficiary]").children
                    ('tbody').children('tr').each(function () {
                        var match = false;
                        $(this).children('td').each(function () {
                            if ($(this).text().toUpperCase().indexOf($("[id *=target]").val().toUpperCase()) > -1) {
                                match = true;
                                return false;
                            }
                        });
                        if (match) {
                            $(this).show();
                            $(this).children('th').show();
                        }
                        else {
                            $(this).hide();
                            $(this).children('th').show();
                        }
                    });


                    $("[id *=ContentPlaceHolder1_gvBeneficiary]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvBeneficiary]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
            $("#targetAddress").keyup(function () {
                if ($("[id *=target2]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvAddress]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvAddress]").children
                    ('tbody').children('tr').each(function () {
                        var match = false;
                        $(this).children('td').each(function () {
                            if ($(this).text().toUpperCase().indexOf($("[id *=targetAddress]").val().toUpperCase()) > -1) {
                                match = true;
                                return false;
                            }
                        });
                        if (match) {
                            $(this).show();
                            $(this).children('th').show();
                        }
                        else {
                            $(this).hide();
                            $(this).children('th').show();
                        }
                    });


                    $("[id *=ContentPlaceHolder1_gvAddress]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvAddress]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
            $("#targetBank").keyup(function () {
                if ($("[id *=target1]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gdvBankList]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gdvBankList]").children
                    ('tbody').children('tr').each(function () {
                        var match = false;
                        $(this).children('td').each(function () {
                            if ($(this).text().toUpperCase().indexOf($("[id *=targetBank]").val().toUpperCase()) > -1) {
                                match = true;
                                return false;
                            }
                        });
                        if (match) {
                            $(this).show();
                            $(this).children('th').show();
                        }
                        else {
                            $(this).hide();
                            $(this).children('th').show();
                        }
                    });
                    $("[id *=ContentPlaceHolder1_gdvBankList]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gdvBankList]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
        });

    </script>
    <script type="text/javascript">

        $(document).ready(function (event) {
            $("#ContentPlaceHolder1_txtSAID,#ContentPlaceHolder1_txtMobile,#ContentPlaceHolder1_txtPhone,#ContentPlaceHolder1_txtPostalCode,#ContentPlaceHolder1_txtAccountNumber,#ContentPlaceHolder1_txtCompanyUIC,#ContentPlaceHolder1_txtTelephone").bind('keypress', function (e) {
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
            $("#ContentPlaceHolder1_txtSAID,#ContentPlaceHolder1_txtMobile,#ContentPlaceHolder1_txtPhone,#ContentPlaceHolder1_txtPostalCode,#ContentPlaceHolder1_txtAccountNumber,#ContentPlaceHolder1_txtCompanyUIC,#ContentPlaceHolder1_txtTelephone").bind('mouseenter', function (e) {
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
            $('#ContentPlaceHolder1_Success').modal('show', { backdrop: 'static' });
        }
        function openBankModal() {
            $('#ContentPlaceHolder1_bankPopup').modal('show', { backdrop: 'static' });
        }
        function openAddressModal() {
            $('#ContentPlaceHolder1_addressPopup').modal('show', { backdrop: 'static' });
        }
        function openValidateModal() {
            $('#ContentPlaceHolder1_validatepopup').modal('show');
        }
        //function openDeleteModal() {
        //    $('#delete').modal('show', { backdrop: 'static' });
        //}
    </script>
    <style type="text/css">
        tr {
            height: 30px;
        }

        th, td {
            text-align: center;
        }

        thead {
            background-color: #e8f1f3;
        }

        table {
            border: 1px solid #e4e5e7;
        }

        .style1 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="header-title">
                <h1>Share Holder Information</h1>
            </div>
        </div>
        <!-- Main content -->
        <asp:HiddenField ID="TabName" runat="server" />
        <div class="content">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Add Share Holder</h5>
                            </div>
                        </div>
                        <div class="panel-body" id="Tabs">

                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#tabTrust" data-toggle="tab">Share Holder Info</a></li>
                                <li><a href="#tabAddress" data-toggle="tab">Address Details</a></li>
                                <li><a href="#tabBank" data-toggle="tab">Bank Details</a></li>
                            </ul>

                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="tabTrust">
                                    <div>
                                        <asp:HiddenField ID="hfBenefaciaryId" runat="server" Value="0" />
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Registration Number</label><span class="style1">*</span>
                                                <asp:TextBox ID="txtUIC" CssClass="form-control" ReadOnly="true" placeholder="Enter Registration Number" MaxLength="13" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtUIC" runat="server" ControlToValidate="txtUIC" Display="Dynamic" ErrorMessage="Enter UIC"
                                                    ValidationGroup="Beneficiary" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group col-sm-3">
                                                <label>Type Of Share Holder</label><span class="style1">*</span>
                                                <asp:DropDownList ID="dropBenificiaryType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dropBenificiaryType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvBenificiaryType" runat="server" ControlToValidate="dropBenificiaryType" Display="Dynamic" ErrorMessage="Please Select Type"
                                                    ValidationGroup="Beneficiary" ForeColor="Red" InitialValue=""></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div id="divIndividual" runat="server">
                                            <div class="col-sm-12">
                                                <div class="col-sm-3 form-group">
                                                    <div class="col-sm-11" style="padding: 0px;">
                                                        <label class="control-label">Identification Number</label><span class="style1">*</span>
                                                        <asp:TextBox ID="txtSAID" CssClass="form-control" placeholder="Enter SAID" MaxLength="13" runat="server"></asp:TextBox>
                                                        <asp:Label ID="lblSAIDError" runat="server" ForeColor="red"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="rfvtxtSAID" runat="server" ControlToValidate="txtSAID" Display="Dynamic" ErrorMessage="Enter SAID"
                                                            ValidationGroup="Beneficiary" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="revtxtSAID" runat="server" ErrorMessage="Please enter 13 digits" ValidationExpression="[0-9]{13}" Display="Dynamic"
                                                            ControlToValidate="txtSAID" ForeColor="Red" ValidationGroup="Beneficiary"></asp:RegularExpressionValidator>
                                                    </div>
                                                    <div class="col-sm-1" style="padding: 0px; margin-top: 14px;">
                                                        <asp:ImageButton ID="imgSearchsaid" runat="server" ImageUrl="~/assets/dist/img/search-icon.png" Height="35" Width="35" ToolTip="Search" OnClick="imgSearchsaid_Click" />
                                                    </div>
                                                </div>


                                                <div class="form-group col-sm-3">
                                                    <label>Title</label><span class="style1">*</span>
                                                    <asp:DropDownList ID="ddlTitle" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="">Title</asp:ListItem>
                                                        <asp:ListItem Value="Mr">Mr</asp:ListItem>
                                                        <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                                        <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                                        <asp:ListItem Value="Miss">Miss</asp:ListItem>
                                                        <asp:ListItem Value="Dr">Dr</asp:ListItem>
                                                        <asp:ListItem Value="Prof">Prof</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="ddlTitle" Display="Dynamic" ErrorMessage="Please Select Title"
                                                        ValidationGroup="Beneficiary" ForeColor="Red" InitialValue=""></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">First Name</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtFirstName" CssClass="form-control" placeholder="Enter First Name" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtFirstName" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="Enter First Name"
                                                        ValidationGroup="Beneficiary" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Last Name</label><%--<span class="style1">*</span>--%>
                                                    <asp:TextBox ID="txtLastName" CssClass="form-control" placeholder="Enter Last Name" runat="server"></asp:TextBox>
                                                    <%--   <asp:RequiredFieldValidator ID="rfvtxtLastName" runat="server" ControlToValidate="txtLastName" Display="Dynamic"
                                                    ErrorMessage="Enter Last Name" ValidationGroup="Beneficiary" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="col-sm-3 form-group ">
                                                    <label>Date Of Birth</label><%--<span class="style1">*</span>--%>
                                                    <asp:TextBox ID="txtDateOfBirth" CssClass="form-control" runat="server" disabled="disabled" autocomplete="off" placeholder="Enter Date Of Birth"></asp:TextBox>
                                                    <%--   <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth" Display="Dynamic"
                                                    ErrorMessage="Enter Date of Birth" ValidationGroup="Beneficiary" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                </div>

                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Tax Reference No.</label><%--<span class="style1">*</span>--%>
                                                    <asp:TextBox ID="txtTaxRefNo" CssClass="form-control" runat="server" placeholder="Enter Tax Ref No"></asp:TextBox>
                                                    <%-- <asp:RequiredFieldValidator ID="rfvtxtTaxRefNo" runat="server" ControlToValidate="txtTaxRefNo" Display="Dynamic"
                                                    ErrorMessage="Enter Tax Reference Number"
                                                    ValidationGroup="Beneficiary" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Email Id</label><%--<span class="style1">*</span>--%>
                                                    <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Enter Email Id" runat="server"></asp:TextBox>
                                                    <%--    <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                                                    ErrorMessage="Enter Email Id" ValidationGroup="Beneficiary" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    <asp:RegularExpressionValidator ID="revtxtEmail" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please Enter Valid Email"
                                                        ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Beneficiary">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Mobile</label><%--<span class="style1">*</span>--%>
                                                    <asp:TextBox ID="txtMobile" CssClass="form-control" runat="server" MaxLength="10" placeholder="Enter Mobile Number"></asp:TextBox>
                                                    <%--  <asp:RequiredFieldValidator ID="rfvtxtMobile" runat="server" ControlToValidate="txtMobile" Display="Dynamic"
                                                    ErrorMessage="Enter Mobile Number" ValidationGroup="Beneficiary" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    <asp:RegularExpressionValidator ID="revMobile" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                        ControlToValidate="txtMobile" ForeColor="Red" ValidationGroup="Beneficiary"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Phone</label><%--<span class="style1">*</span>--%>
                                                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" MaxLength="10" placeholder="Enter Phone Number"></asp:TextBox>
                                                    <%--  <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Enter Phone Number"
                                                    ValidationGroup="Beneficiary" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    <asp:RegularExpressionValidator ID="revPhone" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                        ControlToValidate="txtPhone" ForeColor="Red" ValidationGroup="Beneficiary"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="divCompany" runat="server">
                                            <div class="col-sm-12">
                                                <div class="col-sm-3 form-group">
                                                    <div class="col-sm-11" style="padding: 0px;">
                                                        <label class="control-label">Registration #</label><span class="style1">*</span>
                                                        <asp:TextBox ID="txtCompanyUIC" CssClass="form-control" runat="server" placeholder="Registration #" MaxLength="13"></asp:TextBox>
                                                        <asp:Label ID="msgUIC" runat="server" class="control-label" Style="color: red" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompanyUIC" Display="Dynamic" ErrorMessage="Enter Registration Number"
                                                            ValidationGroup="Beneficiary" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rgvUIC" runat="server" ErrorMessage="Please enter 13 digits" ValidationExpression="[0-9]{13}" Display="Dynamic"
                                                            ControlToValidate="txtCompanyUIC" ForeColor="Red" ValidationGroup="Beneficiary"></asp:RegularExpressionValidator>
                                                    </div>

                                                    <div class="col-sm-1 form-group" style="padding: 0px; margin-top: 14px;">
                                                        <asp:ImageButton ID="imgSearchUID" runat="server" ImageUrl="~/assets/dist/img/search-icon.png" Height="35" Width="35" ToolTip="Search" OnClick="imgSearchUID_Click" />
                                                    </div>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Company Name</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server" placeholder="Company Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvTCompanyName" runat="server" ControlToValidate="txtCompanyName" Display="Dynamic" ErrorMessage="Enter Company Name"
                                                        ValidationGroup="Beneficiary" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Year of Company Foundation</label>
                                                    <%-- <asp:TextBox ID="txtYearofFoundation"  CssClass="form-control" disabled="disabled" autocomplete="off" placeholder="Enter Year of Company Foundation" runat="server"></asp:TextBox>--%>
                                                    <asp:TextBox ID="txtYearofFoundation" CssClass="form-control" runat="server" disabled="disabled" autocomplete="off" placeholder="Enter Year of Company Foundation"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">VAT Number</label>
                                                    <asp:TextBox ID="txtVATRef" CssClass="form-control" runat="server" placeholder="VAT Number"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Telephone</label>
                                                    <asp:TextBox ID="txtTelephoneNum" CssClass="form-control" runat="server" placeholder="VAT Number" MaxLength="10"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="rgvTelephone" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                        ControlToValidate="txtTelephoneNum" ForeColor="Red" ValidationGroup="Beneficiary"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Email Id</label>
                                                    <asp:TextBox ID="txtCompanyEmail" CssClass="form-control" runat="server" placeholder="Email ID"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revEmailId" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please check Email Format"
                                                        ControlToValidate="txtCompanyEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Beneficiary">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Website</label>
                                                    <asp:TextBox ID="txtWebsite" CssClass="form-control" runat="server" placeholder="http://www.example.com"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="rgvWebsite" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please check Website Format"
                                                        ControlToValidate="txtWebsite" ValidationExpression="^((http|https|ftp|www):\/\/)?([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)(\.)([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]+)" ValidationGroup="Beneficiary">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="panel-footer" style="border-top: 0px !important;">
                                        <div class="col-sm-5"></div>
                                        <asp:Button ID="btnSubmit" runat="server" Text="Save" ValidationGroup="Beneficiary" OnClick="btnSubmit_Click" CssClass="btn btn-primary"></asp:Button>
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" OnClick="btnCancel_Click" CssClass="btn btn-danger"></asp:Button>
                                        <asp:Button ID="btnBack" runat="server" Text="Back to Trust" OnClick="btnBack_Click" CssClass="btn btn-danger"></asp:Button>

                                    </div>
                                    <div class="panel panel-bd" id="divBeneficiarylist" runat="server">
                                        <div class="panel-heading">
                                            <div class="panel-title">
                                                <h5>List of Share Holders</h5>
                                            </div>
                                        </div>
                                        <div class="panel-body">
                                            <div class="row" id="search" runat="server">
                                                <div class="col-lg-12">
                                                    <div class="col-lg-1 form-group">
                                                        <asp:DropDownList ID="DropPage" runat="server" CssClass="form-control"
                                                            OnSelectedIndexChanged="DropPage_SelectedIndexChanged"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-lg-2 form-group">
                                                        <label class="control-label">
                                                            Records per page</label>
                                                    </div>
                                                    <div class="col-lg-6 form-group"></div>
                                                    <div class="col-lg-3 form-group">
                                                        <input id="target" type="text" class="form-control" placeholder="Text To Search" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="table-responsive">
                                                <asp:GridView ID="gvBeneficiary" runat="server" Width="100%"
                                                    AutoGenerateColumns="False" DataKeyNames="BeneficiaryID" CssClass="rounded-corners"
                                                    EmptyDataText="There are no data records to display." OnPageIndexChanging="gvBeneficiary_PageIndexChanging"
                                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100" HeaderStyle-BackColor="#e8f1f3"
                                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" OnRowCommand="gvBeneficiary_RowCommand" OnRowDataBound="gvBeneficiary_RowDataBound">
                                                    <PagerStyle CssClass="pagination_grid" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S No.">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Beneficiary Id" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblBeneficiaryID" Text='<%#Eval("BeneficiaryID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Client Identification #">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Company Registration #">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblReferenceUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Share Holder Type">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblShareHolderType" Text='<%#Eval("BeneficiaryType") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Identification #">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Registration #">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblUICNo" Text='<%#Eval("UICNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="First Name">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblFirstName" Text='<%#Eval("FirstName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Company Name">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblCompanyName" Text='<%#Eval("CompanyName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Last Name" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblLastName" Text='<%#Eval("LastName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Mobile" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblMobile" Text='<%#Eval("Mobile") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="EmailID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblEmailID" Text='<%#Eval("EmailID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="AdvisorID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblAdvisorID" Text='<%#Eval("AdvisorID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%-- <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                    CommandName="EditBeneficiary" ToolTip="Edit" CommandArgument='<%#Eval("BeneficiaryID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Document">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnDocument" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/upload.png"
                                                                    CommandName="Document" ToolTip="Add Documents" CommandArgument='<%#Eval("SAID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bank">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnBank" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/bank.png"
                                                                    CommandName="Bank" ToolTip="Bank Details" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnAddress" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/address.png"
                                                                    CommandName="Address" ToolTip="Address Details" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                    CommandName="DeleteBeneficiary" ToolTip="Address Details" CommandArgument='<%#Eval("BeneficiaryID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Validate">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgbtnValidate" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/tick.jpg"
                                                                    CommandName="Validate" ToolTip="Validate" CommandArgument='<%#Eval("BeneficiaryID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabAddress">
                                    <div class="panel-body">
                                        <div class="row" id="searchaddress" runat="server">
                                            <div class="col-lg-12">
                                                <div class="col-lg-1 form-group">
                                                    <asp:DropDownList ID="dropAddress" runat="server"
                                                        OnSelectedIndexChanged="dropAddress_SelectedIndexChanged" CssClass="form-control"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2 form-group">
                                                    <label class="control-label">
                                                        Records per page</label>
                                                </div>
                                                <div class="col-lg-6 form-group"></div>
                                                <div class="col-lg-3 form-group">
                                                    <input id="targetAddress" type="text" class="form-control" placeholder="Text To Search" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvAddress" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="AddressDetailID" CssClass="rounded-corners" EmptyDataText="There are no data records to display."
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" CellPadding="4" CellSpacing="2" Style="font-size: 100%;"
                                                ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvAddress_RowCommand" OnPageIndexChanging="gvAddress_PageIndexChanging">
                                                <PagerStyle CssClass="pagination_grid" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Address Detail ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAddressDetailID" Text='<%#Eval("AddressDetailID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Identification #">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trust Registration #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBeneficiaryName" Text='<%#Eval("BEName").ToString()==" "?Eval("CompanyName") :Eval("BEName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Company Name" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCompanyName" Text='<%#Eval("CompanyName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client Identification #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="HouseNo">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblHouseNo" Text='<%#Eval("HouseNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Building Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBuildingName" Text='<%#Eval("BuildingName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblType" Text='<%#Eval("Type") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="FloorNo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblFloorNo" Text='<%#Eval("FloorNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Flat No" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblFlatNo" Text='<%#Eval("FlatNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RoadName" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblRoadName" Text='<%#Eval("RoadName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RoadNo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblRoadNo" Text='<%#Eval("RoadNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SuburbName" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSuburbName" Text='<%#Eval("SuburbName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Complex" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblComplex" Text='<%#Eval("Complex") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Postal Code" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblPostalCode" Text='<%#Eval("PostalCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Country" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCountry" Text='<%#Eval("Country") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Province" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblProvince" Text='<%#Eval("Province") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="City" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCity" Text='<%#Eval("City") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                CommandName="EditAddress" ToolTip="Edit" CommandArgument='<%#Eval("AddressDetailID") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnAddressDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                CommandName="DeleteAddress" ToolTip="Delete" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>

                                <div class="tab-pane fade" id="tabBank">

                                    <div class="panel-body">

                                        <div class="row" id="searchbank" runat="server">
                                            <div class="col-lg-12">
                                                <div class="col-lg-1 form-group">
                                                    <asp:DropDownList ID="dropBank" runat="server"
                                                        OnSelectedIndexChanged="dropBank_SelectedIndexChanged" CssClass="form-control"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2 form-group">
                                                    <label class="control-label">
                                                        Records per page</label>
                                                </div>
                                                <div class="col-lg-6 form-group"></div>
                                                <div class="col-lg-3 form-group">
                                                    <input id="targetBank" type="text" class="form-control" placeholder="Text To Search" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="table-responsive">
                                            <asp:GridView ID="gdvBankList" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="BankDetailID" CssClass="rounded-corners" EmptyDataText="There are no data records to display."
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" CellPadding="4" CellSpacing="2" Style="font-size: 100%;"
                                                ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gdvBankList_RowCommand" OnPageIndexChanging="gdvBankList_PageIndexChanging">
                                                <PagerStyle CssClass="pagination_grid" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BankDetail ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBankDetailID" Text='<%#Eval("BankDetailID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Identification #">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBankSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBeneficiaryName" Text='<%#Eval("BEName").ToString()==" "?Eval("CompanyName") :Eval("BEName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Company Name" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCompanyName" Text='<%#Eval("CompanyName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trust Registration #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBankUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client Identification #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Bank Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBankName" Text='<%#Eval("BankName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Branch Number">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBranchNumber" Text='<%#Eval("BranchNumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Account Number" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAccountNumber" Text='<%#Eval("AccountNumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Account Type" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAccountType" Text='<%#Eval("AccountType") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Currency" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCurrency" Text='<%#Eval("Currency") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SWIFT" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSWIFT" Text='<%#Eval("SWIFT") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                CommandName="EditBank" CommandArgument='<%#Eval("BankDetailID") %>' ToolTip="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnbankDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                CommandName="DeleteBank" ToolTip="Delete" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.content -->

            <div class="modal fade" id="bankPopup" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                            <h3><i class="fa fa-bank m-r-5" id="bankmessage" runat="server"></i></h3>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <fieldset>
                                        <asp:UpdatePanel ID="upBank" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="col-md-12 form-group user-form-group">
                                                    <div class="panel-body">
                                                        <div class="col-sm-12">
                                                            <asp:Label ID="lblBankMessage" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-12">
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Identification #</label>
                                                                <asp:TextBox ID="txtSAIDBank" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-8 form-group">
                                                                <label class="control-label">Name</label>
                                                                <asp:TextBox ID="txtBeneficiaryNameBank" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-12">
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Bank Name</label><span class="style1">*</span>
                                                                <asp:TextBox ID="txtBankName" runat="server" class="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBankName" Display="Dynamic" ErrorMessage="Enter Bank Name"
                                                                    ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Branch Number</label><span class="style1">*</span>
                                                                <asp:TextBox ID="txtBranchNumber" runat="server" class="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvtxtBranchNumber" runat="server" ControlToValidate="txtBranchNumber" Display="Dynamic" ErrorMessage="Enter Branch Number"
                                                                    ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Account Number</label><span class="style1">*</span>
                                                                <asp:TextBox ID="txtAccountNumber" runat="server" class="form-control"></asp:TextBox>
                                                                <asp:Label ID="lblaccountError" runat="server" ForeColor="red"></asp:Label>
                                                                <asp:RequiredFieldValidator ID="rfvtxtAccountNumber" runat="server" ControlToValidate="txtAccountNumber" Display="Dynamic" ErrorMessage="Enter Account Number"
                                                                    ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-12">
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Account Type</label><span class="style1">*</span>
                                                                <asp:DropDownList ID="ddlAccountType" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvddlAccountType" runat="server" ControlToValidate="ddlAccountType" Display="Dynamic" ErrorMessage="Please select Account Type"
                                                                    ValidationGroup="Bank" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Currency</label><%--<span class="style1">*</span>--%>
                                                                <asp:TextBox ID="txtCurrency" runat="server" class="form-control"></asp:TextBox>
                                                                <%--  <asp:RequiredFieldValidator ID="rfvCurrency" runat="server" ControlToValidate="txtCurrency" Display="Dynamic" ErrorMessage="Enter Currency"
                                                                    ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Swift</label><%--<span class="style1">*</span>--%>
                                                                <asp:TextBox ID="txtSwift" runat="server" class="form-control"></asp:TextBox>
                                                                <%--  <asp:RequiredFieldValidator ID="rfvtxtSwift" runat="server" ControlToValidate="txtSwift" Display="Dynamic" ErrorMessage="Enter Swift"
                                                                    ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <asp:Button ID="btnBankSubmit" runat="server" Text="Submit" ValidationGroup="Bank" CssClass="btn btn-primary" OnClick="btnBankSubmit_Click"></asp:Button>
                            <%-- <asp:Button ID="btnUpdateBank" runat="server" Text="Update" ValidationGroup="Bank" CssClass="btn btn-primary" OnClick="btnUpdateBank_Click"></asp:Button>--%>
                            <asp:Button ID="btnBankCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnBankCancel_Click"></asp:Button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>

            <div class="modal fade" id="addressPopup" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                            <h3><i class="fa fa-home m-r-5" id="addressmessage" runat="server"></i></h3>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <fieldset>
                                        <div class="col-md-12 form-group user-form-group">
                                            <div class="panel-body">
                                                <div class="col-sm-12">
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Identification #</label>
                                                        <asp:TextBox ID="txtSAIDBeneficiary" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-8 form-group">
                                                        <label class="control-label">Name</label>
                                                        <asp:TextBox ID="txtBeneficiaryAddress" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">House No</label><span class="style1">*</span>
                                                        <asp:TextBox ID="txtHouseNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvHouseNo" runat="server" ControlToValidate="txtHouseNo" Display="Dynamic" ErrorMessage="Enter House Number"
                                                            ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Building Name</label><span class="style1">*</span>
                                                        <asp:TextBox ID="txtBulding" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvBulding" runat="server" ControlToValidate="txtBulding" Display="Dynamic" ErrorMessage="Enter Building name"
                                                            ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Floor</label>
                                                        <asp:TextBox ID="txtFloor" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Flat No</label>
                                                        <asp:TextBox ID="txtFlatNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Road Name</label><span class="style1">*</span>
                                                        <asp:TextBox ID="txtRoadName" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvtxtRoadName" runat="server" ControlToValidate="txtRoadName" Display="Dynamic" ErrorMessage="Enter Road Name"
                                                            ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Road No</label><span class="style1">*</span>
                                                        <asp:TextBox ID="txtRoadNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvtxtRoadNo" runat="server" ControlToValidate="txtRoadNo" Display="Dynamic" ErrorMessage="Enter Road No"
                                                            ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Suburb Name</label><%--<span class="style1">*</span>--%>
                                                        <asp:TextBox ID="txtSuburbName" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <%-- <asp:RequiredFieldValidator ID="rfvtxtSuburbName" runat="server" ControlToValidate="txtSuburbName" Display="Dynamic" ErrorMessage="Enter Suburb Name"
                                                            ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Complex/Estate</label><%--<span class="style1">*</span>--%>
                                                        <asp:TextBox ID="txtComplex" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">City</label>
                                                        <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>

                                                </div>
                                                <div class="col-sm-12">
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Postal Code</label><span class="style1">*</span>
                                                        <asp:TextBox ID="txtPostalCode" CssClass="form-control" runat="server" MaxLength="6"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvtxtPostalCode" runat="server" ControlToValidate="txtPostalCode" Display="Dynamic" ErrorMessage="Enter Postal Code"
                                                            ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Province</label><span class="style1">*</span>
                                                        <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlProvince" runat="server" ControlToValidate="ddlProvince" Display="Dynamic" ErrorMessage="Please select Province"
                                                            ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Country</label><span class="style1">*</span>
                                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlCountry" runat="server" ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Please select Country"
                                                            ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <asp:Button ID="btnAddressSubmit" runat="server" Text="Submit" ValidationGroup="Address" CssClass="btn btn-primary" OnClick="btnAddressSubmit_Click"></asp:Button>
                            <%-- <asp:Button ID="btnUpdateAddress" runat="server" Text="Update" ValidationGroup="Address" CssClass="btn btn-primary" OnClick="btnUpdateAddress_Click"></asp:Button>--%>
                            <asp:Button ID="btnAddressCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnAddressCancel_Click"></asp:Button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>

            <div class="modal fade" id="validatepopup" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                            <h3><i class="fa fa-home m-r-5" id="validatemessage" runat="server"></i></h3>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <fieldset>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <div class="col-md-12 form-group user-form-group">
                                                    <div>
                                                        <asp:HiddenField ID="hfBeneficiaryID1" runat="server" Value="0" />
                                                    </div>
                                                    <div class="panel-body">
                                                        <div class="col-sm-12">
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Registration Number</label>
                                                                <asp:TextBox ID="txtvalidUICNum" CssClass="form-control" ReadOnly="true" MaxLength="13" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group col-sm-4">
                                                                <label>Type Of Share Holder</label>
                                                                <asp:DropDownList ID="dropvalidShareType" runat="server" CssClass="form-control" Enabled="false">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div id="divvalidIndividual" runat="server">
                                                            <div class="col-sm-12">
                                                                <div class="col-sm-4 form-group">
                                                                    <div class="col-sm-11" style="padding: 0px;">
                                                                        <label class="control-label">Identification#</label>
                                                                        <asp:TextBox ID="txtvalidSAIDNum" CssClass="form-control" ReadOnly="true" MaxLength="13" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group col-sm-4">
                                                                    <label>Title</label>
                                                                    <asp:DropDownList ID="dropvalidTitle" runat="server" CssClass="form-control" Enabled="false">
                                                                        <asp:ListItem Value="">Title</asp:ListItem>
                                                                        <asp:ListItem Value="Mr">Mr</asp:ListItem>
                                                                        <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                                                        <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                                                        <asp:ListItem Value="Miss">Miss</asp:ListItem>
                                                                        <asp:ListItem Value="Dr">Dr</asp:ListItem>
                                                                        <asp:ListItem Value="Prof">Prof</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label">First Name</label>
                                                                    <asp:TextBox ID="txtvalidFirstName" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-12">
                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label">Last Name</label>
                                                                    <asp:TextBox ID="txtValidLastName" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                </div>

                                                                <div class="col-sm-4 form-group ">
                                                                    <label>Date Of Birth</label>
                                                                    <asp:TextBox ID="txtvalidDOB" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                                </div>

                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label">Tax Reference No.</label>
                                                                    <asp:TextBox ID="txtvalidRefNum" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-12">
                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label">Email Id</label>
                                                                    <asp:TextBox ID="txtvalidEmailId" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label">Mobile</label>
                                                                    <asp:TextBox ID="txtvalidMobileNum" CssClass="form-control" runat="server" MaxLength="10" ReadOnly="true"></asp:TextBox>
                                                                </div>

                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label">Phone</label>
                                                                    <asp:TextBox ID="txtvalidPhoneNum" CssClass="form-control" runat="server" MaxLength="10" ReadOnly="true"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div id="divvalidCompany" runat="server">
                                                            <div class="col-sm-12">
                                                                <div class="col-sm-4 form-group">
                                                                    <div class="col-sm-11" style="padding: 0px;">
                                                                        <label class="control-label">Registration #</label>
                                                                        <asp:TextBox ID="txtvalidCompanyRegNum" CssClass="form-control" runat="server" ReadOnly="true" MaxLength="13"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label">Company Name</label>
                                                                    <asp:TextBox ID="txtvalidCompanyName" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label">Year of Foundation</label>
                                                                    <asp:TextBox ID="txtvalidYCF" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-12">
                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label">VAT Number</label>
                                                                    <asp:TextBox ID="txtvalidVATNum" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                                </div>

                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label">Telephone</label>
                                                                    <asp:TextBox ID="txtvalidcTelNum" CssClass="form-control" runat="server" ReadOnly="true" MaxLength="10"></asp:TextBox>

                                                                </div>
                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label">Email Id</label>
                                                                    <asp:TextBox ID="txtvalidCEMailID" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-12">
                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label">Website</label>
                                                                    <asp:TextBox ID="txtvalidCWebsite" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <asp:Button ID="btnValidOK" runat="server" Text="Validate" CssClass="btn btn-primary" OnClick="btnValidOK_Click" />
                            <asp:Button ID="btnValidCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnValidCancel_Click"></asp:Button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>

            <div class="modal fade" id="Success" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                            <h3>
                                <asp:Label ID="lblTitle" runat="server" class="control-label" /></h3>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <fieldset>
                                        <div class="col-md-12 form-group user-form-group">
                                            <asp:Label ID="message" runat="server" class="control-label" />
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

            <%--<div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header modal-header-primary">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3><i class="fa fa-home m-r-5"></i>Delete</h3>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <fieldset>
                                        <div class="col-md-12 form-group user-form-group">
                                            <asp:Label ID="lbldeletemessage" runat="server" class="control-label" Style="color: green" />
                                            <div class="pull-right">
                                                <asp:Button ID="btnSure" runat="server" Text="YES" CssClass="btn btn-add btn-sm" OnClick="btnSure_Click"></asp:Button>
                                            </div>
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
            </div>--%>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "tabTrust";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });
    </script>

</asp:Content>

