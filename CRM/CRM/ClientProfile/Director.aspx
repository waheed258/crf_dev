<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/LayoutForClientProfile.master" AutoEventWireup="true" CodeFile="Director.aspx.cs" Inherits="ClientProfile_Director" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#target").keyup(function () {
                if ($("[id *=target]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvDirector]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvDirector]").children
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


                    $("[id *=ContentPlaceHolder1_gvDirector]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvDirector]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
        });
        $(document).ready(function () {
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
        $(document).ready(function () {
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
        });
    </script>
    <script type="text/javascript">

        $(document).ready(function (event) {
            $("#ContentPlaceHolder1_txtSAID,#ContentPlaceHolder1_txtMobile,#ContentPlaceHolder1_txtPhone,#ContentPlaceHolder1_txtPostalCode,#ContentPlaceHolder1_txtAccountNumber").bind('keypress', function (e) {
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
            $("#ContentPlaceHolder1_txtSAID,#ContentPlaceHolder1_txtMobile,#ContentPlaceHolder1_txtPhone,#ContentPlaceHolder1_txtPostalCode,#ContentPlaceHolder1_txtAccountNumber").bind('mouseenter', function (e) {
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
        function openDeleteModal() {
            $('#delete').modal('show', { backdrop: 'static' });
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
    <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="header-title">
                <h1>Director Information</h1>
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
                                <h5>Add Director</h5>
                            </div>
                        </div>
                        <div class="panel-body" id="Tabs">

                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#tabDirector" data-toggle="tab">Director Info</a></li>
                                <li><a href="#tabAddress" data-toggle="tab">Address Details</a></li>
                                <li><a href="#tabBank" data-toggle="tab">Bank Details</a></li>
                            </ul>

                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="tabDirector">
                                    <div>
                                        <asp:HiddenField ID="hfDirectorId" runat="server" Value="0" />

                                    </div>
                                    <div class="panel-body">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Registration Number</label>
                                                <asp:TextBox ID="txtUIC" CssClass="form-control" ReadOnly="true" placeholder="Enter Registration Number" MaxLength="13" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtUIC" runat="server" ControlToValidate="txtUIC" Display="Dynamic" ErrorMessage="Enter UIC"
                                                    ValidationGroup="Director" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <div class="col-sm-11" style="padding: 0px;">
                                                    <label class="control-label">Identification Number</label>

                                                    <asp:TextBox ID="txtSAID" CssClass="form-control" placeholder="Enter SAID" MaxLength="13" runat="server"></asp:TextBox>
                                                    <asp:Label ID="lblSAIDError" runat="server" ForeColor="red"></asp:Label>
                                                    <asp:RequiredFieldValidator ID="rfvtxtSAID" runat="server" ControlToValidate="txtSAID" Display="Dynamic" ErrorMessage="Enter SAID"
                                                        ValidationGroup="Director" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revtxtSAID" runat="server" ErrorMessage="Please enter 13 digits" ValidationExpression="[0-9]{13}" Display="Dynamic"
                                                        ControlToValidate="txtSAID" ForeColor="Red" ValidationGroup="Director"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-sm-1" style="padding: 0px; margin-top: 14px;">
                                                    <asp:ImageButton ID="imgSearchsaid" runat="server" ImageUrl="~/assets/dist/img/search-icon.png" Height="35" Width="35" ToolTip="Search" OnClick="imgSearchsaid_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="form-group col-sm-3">
                                                <label>Title</label>
                                                <asp:DropDownList ID="ddlTitle" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="">Title</asp:ListItem>
                                                    <asp:ListItem Value="Mr">Mr</asp:ListItem>
                                                    <asp:ListItem Value="Miss">Miss</asp:ListItem>
                                                    <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                                    <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                                    <asp:ListItem Value="Dr">Dr</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">First Name</label>
                                                <asp:TextBox ID="txtFirstName" CssClass="form-control" placeholder="Enter First Name" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFirstName" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="Enter First Name"
                                                    ValidationGroup="Director" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Last Name</label>
                                                <asp:TextBox ID="txtLastName" CssClass="form-control" placeholder="Enter Last Name" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtLastName" runat="server" ControlToValidate="txtLastName" Display="Dynamic"
                                                    ErrorMessage="Enter Last Name" ValidationGroup="Director" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                              <div class="form-group col-sm-3">
                                                <label>Date Of Birth</label>
                                                <asp:TextBox ID="txtDateOfBirth" CssClass="form-control" runat="server" placeholder="Enter Date Of Birth" TextMode="Date"></asp:TextBox>
                                            </div>
                                        </div>

                                    <div class="col-sm-12">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label">Tax Reference No.</label>
                                            <asp:TextBox ID="txtTaxRefNo" CssClass="form-control" runat="server" placeholder="Enter Tax Ref No"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtTaxRefNo" runat="server" ControlToValidate="txtTaxRefNo" Display="Dynamic"
                                                ErrorMessage="Enter Tax Reference Number"
                                                ValidationGroup="Director" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label">Email Id</label>
                                            <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Enter Email Id" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                                                ErrorMessage="Enter Email Id" ValidationGroup="Director" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revtxtEmail" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please Enter Valid Email"
                                                ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Director">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label">Mobile</label>
                                            <asp:TextBox ID="txtMobile" CssClass="form-control" runat="server" MaxLength="10" placeholder="Enter Mobile Number"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtMobile" runat="server" ControlToValidate="txtMobile" Display="Dynamic"
                                                ErrorMessage="Enter Mobile Number" ValidationGroup="Director" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revMobile" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                ControlToValidate="txtMobile" ForeColor="Red" ValidationGroup="Director"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label">Phone</label>
                                            <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" MaxLength="10" placeholder="Enter Phone Number"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Enter Phone Number"
                                                ValidationGroup="Director" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revPhone" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                ControlToValidate="txtPhone" ForeColor="Red" ValidationGroup="Director"></asp:RegularExpressionValidator>
                                        </div>


                                    </div>


                                    <div class="col-sm-12">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label">Share Percentage</label>
                                            <asp:TextBox ID="txtSharePerc" CssClass="form-control" runat="server" placeholder="Enter Share Percentage"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtSharePerc" runat="server" ControlToValidate="txtSharePerc" Display="Dynamic"
                                                ErrorMessage="Enter Share Percentage"
                                                ValidationGroup="Director" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label">Share Value</label>
                                            <asp:TextBox ID="txtShareValue" CssClass="form-control" runat="server" placeholder="Enter Share Value"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtShareValue" runat="server" ControlToValidate="txtShareValue" Display="Dynamic"
                                                ErrorMessage="Enter Share Value"
                                                ValidationGroup="Director" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </div>
                                <div class="panel-footer" style="border-top: 0px !important;">
                                    <div class="col-sm-5"></div>
                                    <asp:Button ID="btnDirectorSubmit" runat="server" Text="Save" ValidationGroup="Director" OnClick="btnDirectorSubmit_Click" CssClass="btn btn-primary"></asp:Button>
                                    <asp:Button ID="btnDirectorCancel" runat="server" Text="Cancel" Visible="false" OnClick="btnDirectorCancel_Click" CssClass="btn btn-danger"></asp:Button>
                                    <asp:Button ID="btnBack" runat="server" Text="Back to Company" OnClick="btnBack_Click" CssClass="btn btn-danger"></asp:Button>

                                </div>
                                <div class="panel panel-bd" id="divDirectorlist" runat="server">
                                    <div class="panel-heading">
                                        <div class="panel-title">
                                            <h5>List of Directors</h5>
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
                                            <asp:GridView ID="gvDirector" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="DirectorID" CssClass="rounded-corners"
                                                EmptyDataText="There are no data records to display." OnPageIndexChanging="gvDirector_PageIndexChanging"
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100" HeaderStyle-BackColor="#e8f1f3"
                                                CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" OnRowCommand="gvDirector_RowCommand">
                                                <PagerStyle CssClass="pagination_grid" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Director Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblDirectorID" Text='<%#Eval("DirectorID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client Identification #">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Regestration #">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblReferenceUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Identification #">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="First Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblFirstName" Text='<%#Eval("FirstName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Last Name">
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
                                                    <asp:TemplateField HeaderText="Phone" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblPhone" Text='<%#Eval("Phone") %>'></asp:Label>
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
                                                                CommandName="EditDirector" ToolTip="Edit" CommandArgument='<%#Eval("DirectorID") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                CommandName="DeleteDirector" ToolTip="Delete Director" CommandArgument='<%#Eval("DirectorID") %>' />
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
                                                    <asp:TemplateField HeaderText="Director Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblDirectorName" Text='<%#Eval("FirstName")+" "+Eval("LastName") %>'></asp:Label>
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
                                                    <asp:TemplateField HeaderText="Edit">
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
                                                    </asp:TemplateField>
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
                                                    <asp:TemplateField HeaderText="Director Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblDirectorName" Text='<%#Eval("FIRSTNAME")+" "+Eval("LASTNAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trust Registration #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBankUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client Identification #">
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
                                                    <asp:TemplateField HeaderText="Edit">
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
                                                                <label class="control-label">Director Name</label>
                                                                <asp:TextBox ID="txtDirectorNameBank" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-12">
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Bank Name</label>
                                                                <asp:TextBox ID="txtBankName" runat="server" class="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBankName" Display="Dynamic" ErrorMessage="Enter Bank Name"
                                                                    ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Branch Number</label>
                                                                <asp:TextBox ID="txtBranchNumber" runat="server" class="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvtxtBranchNumber" runat="server" ControlToValidate="txtBranchNumber" Display="Dynamic" ErrorMessage="Enter Branch Number"
                                                                    ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Account Number</label>
                                                                <asp:TextBox ID="txtAccountNumber" runat="server" class="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvtxtAccountNumber" runat="server" ControlToValidate="txtAccountNumber" Display="Dynamic" ErrorMessage="Enter Account Number"
                                                                    ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-12">
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Account Type</label>
                                                                <asp:DropDownList ID="ddlAccountType" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvddlAccountType" runat="server" ControlToValidate="ddlAccountType" Display="Dynamic" ErrorMessage="Please select Account Type"
                                                                    ValidationGroup="Bank" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Currency</label>
                                                                <asp:TextBox ID="txtCurrency" runat="server" class="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvCurrency" runat="server" ControlToValidate="txtCurrency" Display="Dynamic" ErrorMessage="Enter Currency"
                                                                    ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label">Swift</label>
                                                                <asp:TextBox ID="txtSwift" runat="server" class="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvtxtSwift" runat="server" ControlToValidate="txtSwift" Display="Dynamic" ErrorMessage="Enter Swift"
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
                                                        <asp:TextBox ID="txtSAIDDirector" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-8 form-group">
                                                        <label class="control-label">Director Name</label>
                                                        <asp:TextBox ID="txtDirectorNameAddress" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">House No</label>
                                                        <asp:TextBox ID="txtHouseNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvHouseNo" runat="server" ControlToValidate="txtHouseNo" Display="Dynamic" ErrorMessage="Enter House Number"
                                                            ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Building Name</label>
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
                                                        <label class="control-label">Road Name</label>
                                                        <asp:TextBox ID="txtRoadName" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvtxtRoadName" runat="server" ControlToValidate="txtRoadName" Display="Dynamic" ErrorMessage="Enter Road Name"
                                                            ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Road No</label>
                                                        <asp:TextBox ID="txtRoadNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvtxtRoadNo" runat="server" ControlToValidate="txtRoadNo" Display="Dynamic" ErrorMessage="Enter Road No"
                                                            ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Suburb Name</label>
                                                        <asp:TextBox ID="txtSuburbName" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvtxtSuburbName" runat="server" ControlToValidate="txtSuburbName" Display="Dynamic" ErrorMessage="Enter Suburb Name"
                                                            ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">City</label>
                                                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlCity" runat="server" ControlToValidate="ddlCity" Display="Dynamic" ErrorMessage="Please select City"
                                                            ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Postal Code</label>
                                                        <asp:TextBox ID="txtPostalCode" CssClass="form-control" runat="server" MaxLength="6"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvtxtPostalCode" runat="server" ControlToValidate="txtPostalCode" Display="Dynamic" ErrorMessage="Enter Postal Code"
                                                            ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Province</label>
                                                        <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlProvince" runat="server" ControlToValidate="ddlProvince" Display="Dynamic" ErrorMessage="Please select Province"
                                                            ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Country</label>
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
                            <asp:Button ID="btnUpdateAddress" runat="server" Text="Update" ValidationGroup="Address" CssClass="btn btn-primary" OnClick="btnUpdateAddress_Click"></asp:Button>
                            <asp:Button ID="btnAddressCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnAddressCancel_Click"></asp:Button>
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
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "tabDirector";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });
    </script>
</asp:Content>

