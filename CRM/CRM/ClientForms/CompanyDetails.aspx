<%@ Page Title="" Language="C#" MasterPageFile="~/ClientForms/Layout.master" AutoEventWireup="true" CodeFile="CompanyDetails.aspx.cs" Inherits="ClientForms_CompanyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/jquery-1.10.2.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function (event) {
            $("#ContentPlaceHolder1_txtCompanyUIC,#ContentPlaceHolder1_txtTelephone,#ContentPlaceHolder1_txtFax,#ContentPlaceHolder1_txtPostalCode,#ContentPlaceHolder1_txtAccountNumber").bind('keypress', function (e) {
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
            $("#ContentPlaceHolder1_txtCompanyUIC,#ContentPlaceHolder1_txtTelephone,#ContentPlaceHolder1_txtFax,#ContentPlaceHolder1_txtPostalCode,#ContentPlaceHolder1_txtAccountNumber").bind('mouseenter', function (e) {
                var val = $(this).val();
                if (val != '0') {
                    val = val.replace(/[^0-9]+/g, "");
                    $(this).val(val);
                }
            });
        })
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#target").keyup(function () {
                if ($("[id *=target]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvCompany]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvCompany]").children
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


                    $("[id *=ContentPlaceHolder1_gvCompany]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvCompany]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
            $("#targetBank").keyup(function () {
                if ($("[id *=targetBank]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvBankDetails]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvBankDetails]").children
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


                    $("[id *=ContentPlaceHolder1_gvBankDetails]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvBankDetails]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
            $("#targetAddress").keyup(function () {
                if ($("[id *=targetAddress]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvAddressDetails]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvAddressDetails]").children
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


                    $("[id *=ContentPlaceHolder1_gvAddressDetails]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvAddressDetails]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
        });
    </script>
    <script type="text/javascript">
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show');
        }
        function openBankModal() {
            $('#ContentPlaceHolder1_bankPopup').modal('show');
        }
        function openAddressModal() {
            $('#ContentPlaceHolder1_addressPopup').modal('show');
        }
        function openDeleteModal() {
            $('#delete').modal('show');
        }
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="header-title">
                <h1>Company Information</h1>
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
                                <h5>Add Company</h5>
                            </div>
                        </div>
                        <div class="panel-body" id="Tabs">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#tab1" data-toggle="tab">Company Information</a></li>
                                <li><a href="#tab3" data-toggle="tab">Address Details</a></li>
                                <li><a href="#tab2" data-toggle="tab">Bank Details</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="tab1">
                                    <div class="panel-body">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label>Trust</label>
                                                <asp:DropDownList ID="ddlTrustNames" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="col-sm-2 form-group">
                                                <label class="control-label">Registration #</label>
                                                <asp:TextBox ID="txtCompanyUIC" CssClass="form-control" runat="server" placeholder="Registration #" MaxLength="13"></asp:TextBox>
                                                <asp:Label ID="msgUIC" runat="server" class="control-label" Style="color: red" />
                                                <asp:RequiredFieldValidator ID="rfvtxtUIC" runat="server" ControlToValidate="txtCompanyUIC" Display="Dynamic" ErrorMessage="Enter Registration Number"
                                                    ValidationGroup="Company" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rgvUIC" runat="server" ErrorMessage="Please enter 13 digits" ValidationExpression="[0-9]{13}" Display="Dynamic"
                                                    ControlToValidate="txtCompanyUIC" ForeColor="Red" ValidationGroup="Company"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-1 form-group" style="padding: 0px; margin-top: 14px;">
                                                <asp:ImageButton ID="imgSearchsaid" runat="server" ImageUrl="~/assets/dist/img/search-icon.png" Height="35" Width="35" ToolTip="Search" OnClick="imgSearchsaid_Click" />
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Company Name</label>
                                                <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server" placeholder="Company Name"></asp:TextBox>
                                                <asp:Label ID="lblCompanyNameError" runat="server" ForeColor="red"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfvTCompanyName" runat="server" ControlToValidate="txtCompanyName" Display="Dynamic" ErrorMessage="Enter Company Name"
                                                    ValidationGroup="Company" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Year of Company Foundation</label>
                                                <asp:TextBox ID="txtYearofFoundation" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvYearOfFoundation" runat="server" ControlToValidate="txtYearofFoundation" Display="Dynamic"
                                                    ErrorMessage="Enter year of Foundation"
                                                    ValidationGroup="Company" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">VAT Number</label>
                                                <asp:TextBox ID="txtVATRef" CssClass="form-control" runat="server" placeholder="VAT Number"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtVATRef" runat="server" ControlToValidate="txtVATRef" Display="Dynamic"
                                                    ErrorMessage="Enter Tax Reference"
                                                    ValidationGroup="Company" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Telephone</label>
                                                <asp:TextBox ID="txtTelephone" CssClass="form-control" runat="server" placeholder="Telephone" MaxLength="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvTelephone" runat="server" ControlToValidate="txtTelephone" Display="Dynamic"
                                                    ErrorMessage="Enter Telephone"
                                                    ValidationGroup="Company" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rgvTelephone" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                    ControlToValidate="txtTelephone" ForeColor="Red" ValidationGroup="Company"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Fax</label>
                                                <asp:TextBox ID="txtFax" CssClass="form-control" runat="server" placeholder="Fax" MaxLength="10"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rgvFax" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                    ControlToValidate="txtFax" ForeColor="Red" ValidationGroup="Company"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Email Id</label>
                                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Email ID"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                                                    ErrorMessage="Enter Email ID"
                                                    ValidationGroup="Company" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revEmailId" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please check Email Format"
                                                    ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Company">
                                                </asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Website</label>
                                                <asp:TextBox ID="txtWebsite" CssClass="form-control" runat="server" placeholder="http://www.example.com"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rgvWebsite" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please check Website Format"
                                                    ControlToValidate="txtWebsite" ValidationExpression="^((http|https|ftp|www):\/\/)?([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)(\.)([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]+)" ValidationGroup="Company">
                                                </asp:RegularExpressionValidator>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="panel-footer" style="border-top: 0px !important;">
                                        <div class="col-sm-5"></div>
                                        <asp:Button ID="btnCompantDetails" runat="server" Text="Submit" ValidationGroup="Company" CssClass="btn btn-primary" OnClick="btnCompantDetails_Click"></asp:Button>
                                        <asp:Button ID="btnUpdateCompany" runat="server" Text="Update" ValidationGroup="Company" CssClass="btn btn-primary" OnClick="btnUpdateCompany_Click"></asp:Button>
                                        <asp:Button ID="btnCpmpanyDetailsCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCpmpanyDetailsCancel_Click"></asp:Button>
                                    </div>
                                    <div class="panel panel-bd" id="companylist" runat="server">
                                        <div class="panel-heading">
                                            <div class="panel-title">
                                                <h5>List of Companies</h5>
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
                                                    <div class="col-lg-6"></div>
                                                    <div class="col-lg-3">
                                                        <input id="target" type="text" class="form-control" placeholder="Text To Search" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="table-responsive">
                                                <asp:GridView ID="gvCompany" runat="server" Width="100%"
                                                    AutoGenerateColumns="False" DataKeyNames="CompanyID" CssClass="rounded-corners"
                                                    EmptyDataText="There are no data records to display."
                                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvCompany_PageIndexChanging"
                                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvCompany_RowCommand">
                                                    <PagerStyle CssClass="pagination_grid" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S No.">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Company ID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblCompanyID" Text='<%#Eval("CompanyID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Reference SAID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="UIC">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Company Name">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblCompanyName" Text='<%#Eval("CompanyName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="EmailID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblEmailID" Text='<%#Eval("EmailID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Year Of Establishment" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblYearOfEstablishment" Text='<%#Eval("YearOfEstablishment") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Telephone" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblTelephone" Text='<%#Eval("Telephone") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="FaxNo" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblFaxNo" Text='<%#Eval("FaxNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Website" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblWebsite" Text='<%#Eval("Website") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Website" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblVATNo" Text='<%#Eval("VATNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Trusts" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblTrusts" Text='<%#Eval("TrustUIC") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                    CommandName="EditCompany" ToolTip="Edit" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                    CommandName="DeleteCompany" ToolTip="Edit" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Document">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnDocument" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/upload.png"
                                                                    CommandName="Document" ToolTip="Add Documents" CommandArgument='<%#Eval("UIC") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Add Bank Details">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnBank" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/bank.png"
                                                                    CommandName="Bank" ToolTip="Bank Details" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Add Address Details">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnAddress" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/address.png"
                                                                    CommandName="Address" ToolTip="Address Details" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Beneficiary">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnBeneficiary" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Beneficiary.jpg"
                                                                    CommandName="EditBeneficiary" ToolTip="Beneficiary Details" CommandArgument='<%#Eval("UIC") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Director">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnDirector" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Beneficiary.jpg"
                                                                    CommandName="EditDirector" ToolTip="Director Details" CommandArgument='<%#Eval("UIC") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tab2">
                                    <div class="panel panel-bd" id="divBankDetails" runat="server">
                                        <div class="panel-body">
                                            <div class="row" id="searchbank" runat="server">
                                                <div class="col-lg-12">
                                                    <div class="col-lg-1 form-group">
                                                        <asp:DropDownList ID="dropBank" runat="server"
                                                            OnSelectedIndexChanged="dropBank_SelectedIndexChanged"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-lg-2 form-group">
                                                        <label class="control-label">
                                                            Records per page</label>
                                                    </div>
                                                    <div class="col-lg-6"></div>
                                                    <div class="col-lg-3">
                                                        <input id="targetBank" type="text" class="form-control" placeholder="Text To Search" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="table-responsive" style="margin-top: 10px;">
                                                <asp:GridView ID="gvBankDetails" runat="server" Width="100%"
                                                    AutoGenerateColumns="False" DataKeyNames="BankDetailID" CssClass="rounded-corners"
                                                    EmptyDataText="There are no data records to display. Please add bank details."
                                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" OnRowEditing="gvBankDetails_RowEditing" OnPageIndexChanging="gvBankDetails_PageIndexChanging"
                                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowDeleting="gvBankDetails_RowDeleting" OnRowCommand="gvBankDetails_RowCommand">
                                                    <PagerStyle CssClass="pagination_grid" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S No.">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bank ID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblBankDetailID" Text='<%#Eval("BankDetailID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Registration Number">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Company Name">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblCompanyName" Text='<%#Eval("COMPANYNAME") %>'></asp:Label>
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
                                                        <asp:TemplateField HeaderText="BranchNumber" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblBranchNumber" Text='<%#Eval("BranchNumber") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Account Number">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblAccountNumber" Text='<%#Eval("AccountNumber") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Account Type" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblAccountType" Text='<%#Eval("AccountType") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Account Type Name" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblAccountTypeName" Text='<%#Eval("AccountTypeName") %>'></asp:Label>
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
                                                        <asp:TemplateField HeaderText="AdvisorID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblAdvisorID" Text='<%#Eval("AdvisorID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                    CommandName="Edit" ToolTip="Edit" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnbankDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                    CommandName="Delete" ToolTip="Delete" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tab3">
                                    <div class="panel panel-bd" id="divAddressDetails" runat="server">
                                        <div class="panel-body">
                                            <div class="row" id="searchaddress" runat="server">
                                                <div class="col-lg-12">
                                                    <div class="col-lg-1 form-group">
                                                        <asp:DropDownList ID="dropAddress" runat="server"
                                                            OnSelectedIndexChanged="dropAddress_SelectedIndexChanged"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-lg-2 form-group">
                                                        <label class="control-label">
                                                            Records per page</label>
                                                    </div>
                                                    <div class="col-lg-6"></div>
                                                    <div class="col-lg-3">
                                                        <input id="targetAddress" type="text" class="form-control" placeholder="Text To Search" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="table-responsive" style="margin-top: 10px;">
                                                <asp:GridView ID="gvAddressDetails" runat="server" Width="100%"
                                                    AutoGenerateColumns="False" DataKeyNames="AddressDetailID" CssClass="rounded-corners" OnRowDeleting="gvAddressDetails_RowDeleting"
                                                    EmptyDataText="There are no data records to display. Please add address details."
                                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" OnRowEditing="gvAddressDetails_RowEditing" OnPageIndexChanging="gvAddressDetails_PageIndexChanging"
                                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvAddressDetails_RowCommand">
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
                                                        <asp:TemplateField HeaderText="Registration Number">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Company Name">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblCompanyName" Text='<%#Eval("CompanyName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Client SAID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="House No">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblHouseNo" Text='<%#Eval("HouseNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Building Name">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblBuildingName" Text='<%#Eval("BuildingName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Floor No" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblFloorNo" Text='<%#Eval("FloorNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Flat No" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblFlatNo" Text='<%#Eval("FlatNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Road Name" Visible="false">
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
                                                        <asp:TemplateField HeaderText="City" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblCity" Text='<%#Eval("City") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PostalCode" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblPostalCode" Text='<%#Eval("PostalCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Province" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblProvince" Text='<%#Eval("Province") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Country" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblCountry" Text='<%#Eval("Country") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                    CommandName="Edit" ToolTip="Edit" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnAddressDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                    CommandName="Delete" ToolTip="Delete" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
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
            </div>
        </div>
        <!-- /.content -->
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
                                        <asp:Label ID="message" runat="server" class="control-label" Style="color: green" />
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

        <!-- delete user Modal2 -->
        <div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-hidden="true">
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
        </div>
        <!-- /.modal -->

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
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-12 form-group user-form-group">
                                                <div class="panel-body">
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Company Reg No.</label>
                                                            <asp:TextBox ID="txtCompanyUICBank" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>

                                                        </div>
                                                        <div class="col-sm-8 form-group">
                                                            <label class="control-label">Company Name</label>
                                                            <asp:TextBox ID="txtCompanyNameBank" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12">

                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Bank Name</label>
                                                            <asp:TextBox ID="txtBankName" runat="server" class="form-control" placeholder="Bank Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvBankName" runat="server" ControlToValidate="txtBankName" Display="Dynamic" ErrorMessage="Enter Bank Name"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Branch Number</label>
                                                            <asp:TextBox ID="txtBranchNumber" runat="server" class="form-control" placeholder="Branch Number"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvBranchNumber" runat="server" ControlToValidate="txtBranchNumber" Display="Dynamic" ErrorMessage="Enter Branch Number"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Account Number</label>
                                                            <asp:TextBox ID="txtAccountNumber" runat="server" class="form-control" placeholder="Account Number" AutoPostBack="true" OnTextChanged="txtAccountNumber_TextChanged"></asp:TextBox>
                                                            <asp:Label ID="msgAccountNum" runat="server" class="control-label" Style="color: red" />
                                                            <asp:RequiredFieldValidator ID="rfvAccountNumber" runat="server" ControlToValidate="txtAccountNumber" Display="Dynamic" ErrorMessage="Enter Account Number"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>

                                                    </div>

                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Account Type</label>
                                                            <asp:DropDownList ID="ddlAccountType" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvAccountType" runat="server" ControlToValidate="ddlAccountType" Display="Dynamic" ErrorMessage="Please select Account Type"
                                                                ValidationGroup="Bank" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Currency</label>
                                                            <asp:TextBox ID="txtCurrency" runat="server" class="form-control" placeholder="Currency"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCurrency" Display="Dynamic" ErrorMessage="Enter Currency"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Swift</label>
                                                            <asp:TextBox ID="txtSwift" runat="server" class="form-control" placeholder="Swift"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvSwift" runat="server" ControlToValidate="txtSwift" Display="Dynamic" ErrorMessage="Enter Swift"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <asp:Button ID="btnUpdateBank" runat="server" Text="Update" ValidationGroup="Bank" CssClass="btn btn-primary" OnClick="btnUpdateBank_Click"></asp:Button>
                        <asp:Button ID="Button4" runat="server" Text="Cancel" CssClass="btn btn-danger"></asp:Button>
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
                                                    <label class="control-label">Company Reg No.</label>
                                                    <asp:TextBox ID="txtAddrUIC" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>

                                                </div>
                                                <div class="col-sm-8 form-group">
                                                    <label class="control-label">Company Name</label>
                                                    <asp:TextBox ID="txtAddrCompanyName" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Plot No</label>
                                                    <asp:TextBox ID="txtPlotNo" CssClass="form-control" runat="server" placeholder="Plot No"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtPlotNo" runat="server" ControlToValidate="txtPlotNo" Display="Dynamic" ErrorMessage="Enter Plot No Number"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Building Name</label>
                                                    <asp:TextBox ID="txtBulding" CssClass="form-control" runat="server" placeholder="Building Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvBuildingNo" runat="server" ControlToValidate="txtBulding" Display="Dynamic" ErrorMessage="Enter Building name"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Floor</label>
                                                    <asp:TextBox ID="txtFloor" CssClass="form-control" runat="server" placeholder="Floor"></asp:TextBox>
                                                </div>

                                            </div>

                                            <div class="col-sm-12">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Flat No</label>
                                                    <asp:TextBox ID="txtFlatrNo" CssClass="form-control" runat="server" placeholder="Flat No"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Road Name</label>
                                                    <asp:TextBox ID="txtRoadName" CssClass="form-control" runat="server" placeholder="Road Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvRoadName" runat="server" ControlToValidate="txtRoadName" Display="Dynamic" ErrorMessage="Enter Road Name"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Road No</label>
                                                    <asp:TextBox ID="txtRoadNo" CssClass="form-control" runat="server" placeholder="Road No"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvRoadNo" runat="server" ControlToValidate="txtRoadNo" Display="Dynamic" ErrorMessage="Enter Road No"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>

                                            <div class="col-sm-12">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Suburb Name</label>
                                                    <asp:TextBox ID="txtSuburbName" CssClass="form-control" runat="server" placeholder="Suburb Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvSuburbName" runat="server" ControlToValidate="txtSuburbName" Display="Dynamic" ErrorMessage="Enter Suburb Name"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">City</label>
                                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity" Display="Dynamic" ErrorMessage="Please select City"
                                                        ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Postal Code</label>
                                                    <asp:TextBox ID="txtPostalCode" CssClass="form-control" runat="server" placeholder="Postal Code"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvPostalCode" runat="server" ControlToValidate="txtPostalCode" Display="Dynamic" ErrorMessage="Enter Postal Code"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Province</label>
                                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvProvince" runat="server" ControlToValidate="ddlProvince" Display="Dynamic" ErrorMessage="Please select Province"
                                                        ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Country</label>
                                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Please select Country"
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
                        <asp:Button ID="btnUpdateAddress" runat="server" Text="Update" ValidationGroup="Address" CssClass="btn btn-primary" OnClick="btnUpdateAddress_Click"></asp:Button>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger"></asp:Button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "tab1";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });
    </script>
</asp:Content>

