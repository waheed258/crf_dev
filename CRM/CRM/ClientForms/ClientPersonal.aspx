<%@ Page Title="" Language="C#" MasterPageFile="~/ClientForms/Layout.master" AutoEventWireup="true" CodeFile="ClientPersonal.aspx.cs" Inherits="ClientProfile_ClientPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtDateofBirth").datepicker({
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
            $("#target1").keyup(function () {
                if ($("[id *=target1]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvBankDetails]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvBankDetails]").children
                    ('tbody').children('tr').each(function () {
                        var match = false;
                        $(this).children('td').each(function () {
                            if ($(this).text().toUpperCase().indexOf($("[id *=target1]").val().toUpperCase()) > -1) {
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
        });
        $(document).ready(function () {
            $("#target2").keyup(function () {
                if ($("[id *=target2]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvAddressDetails]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvAddressDetails]").children
                    ('tbody').children('tr').each(function () {
                        var match = false;
                        $(this).children('td').each(function () {
                            if ($(this).text().toUpperCase().indexOf($("[id *=target2]").val().toUpperCase()) > -1) {
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
        function openDeleteModal() {
            $('#delete').modal('show');
        }
        function openBankModal() {
            $('#ContentPlaceHolder1_bankPopup').modal('show');
        }
        function openAddressModal() {
            $('#ContentPlaceHolder1_addressPopup').modal('show');
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
                <h1>Client Personal Information</h1>
            </div>
        </div>
        <!-- Main content -->
        <asp:HiddenField ID="TabName" runat="server" />
        <div class="content">
            <div style="text-align: center; margin-bottom: 10px;">
                <asp:Label ID="lblMessage" runat="server" Style="color: #006341; font-weight: bold; text-align: center"></asp:Label>
            </div>

            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Add Client Personal</h5>
                            </div>
                        </div>
                        <div class="panel-body" id="Tabs">
                            <div style="text-align: right" id="DivAddBank" runat="server">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-labeled btn-danger m-b-5" OnClick="LinkButton2_Click">
                                    <span class="btn-label"><i class="glyphicon glyphicon-plus"></i></span>Add Address Info
                                </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-labeled btn-danger m-b-5" OnClick="LinkButton1_Click">                              
                                    <span class="btn-label"><i class="glyphicon glyphicon-plus"></i></span>Add Bank Info
                                </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-labeled btn-danger m-b-5" OnClick="LinkButton3_Click">                              
                                    <span class="btn-label"><i class="glyphicon glyphicon-plus"></i></span>Add Documents
                                </asp:LinkButton>
                            </div>
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#tabTrust" data-toggle="tab">Personal Information</a></li>
                                <li><a href="#tabAddress" data-toggle="tab">Address Details</a></li>
                                <li><a href="#tabBank" data-toggle="tab">Bank Details</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="tabTrust">
                                    <div class="panel-body">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Identification Number</label>
                                                <asp:TextBox ID="txtSAId" runat="server" class="form-control" MaxLength="13" placeholder="Enter SAID"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-sm-3">
                                                <label>Title</label><%--<span class="style1">*</span>--%>
                                                <asp:DropDownList ID="ddlTitle" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="">Title</asp:ListItem>
                                                    <asp:ListItem Value="Mr">Mr</asp:ListItem>
                                                    <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                                    <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                                    <asp:ListItem Value="Miss">Miss</asp:ListItem>
                                                    <asp:ListItem Value="Dr">Dr</asp:ListItem>
                                                    <asp:ListItem Value="Prof">Prof</asp:ListItem>
                                                </asp:DropDownList>
                                                <%-- <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="ddlTitle" Display="Dynamic" ErrorMessage="Please Select Title"
                                                    ValidationGroup="Spouse" ForeColor="Red" InitialValue=""></asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">First Name</label>
                                                <asp:TextBox ID="txtFirstName" runat="server" class="form-control" placeholder="Enter Given Name"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Last Name</label>
                                                <asp:TextBox ID="txtLastName" runat="server" class="form-control" placeholder="Enter Sur Name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">EmailId</label>
                                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Enter EmailId"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Mobile No</label>
                                                <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" MaxLength="10" placeholder="Enter Mobile No"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Phone No</label><%--<span class="style1">*</span>--%>
                                                <asp:TextBox ID="txtPhoneNo" runat="server" class="form-control" MaxLength="10" placeholder="Enter Phone No"></asp:TextBox>
                                               <%-- <asp:RequiredFieldValidator ID="rfvPhoneNo" runat="server" ControlToValidate="txtPhoneNo" Display="Dynamic"
                                                    ErrorMessage="Enter PhoneNo" ValidationGroup="Client" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                <asp:RegularExpressionValidator ID="rgvPhoneNo" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                    ControlToValidate="txtPhoneNo" ForeColor="Red" ValidationGroup="Client"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label>Date of Birth</label><%--<span class="style1">*</span>--%>
                                                <asp:TextBox ID="txtDateofBirth" runat="server"  CssClass="form-control" autocomplete="off" placeholder="Enter Date of Birth"></asp:TextBox>
                                               <%-- <asp:RequiredFieldValidator ID="rfvDateofBirth" runat="server" ControlToValidate="txtDateofBirth" Display="Dynamic"
                                                    ErrorMessage="Enter Date of Birth" ValidationGroup="Client" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            </div>

                                        </div>

                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Tax Ref No</label><%--<span class="style1">*</span>--%>
                                                <asp:TextBox ID="txtTaxRefNo" runat="server" CssClass="form-control" placeholder="Enter Tax Ref No"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator ID="rfvTaxRefNo" runat="server" ControlToValidate="txtTaxRefNo" Display="Dynamic"
                                                    ErrorMessage="Enter Tax Ref No" ValidationGroup="Client" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            </div>

                                            <div class="form-group col-sm-3">
                                                <label>Upload Photo</label>
                                                <asp:FileUpload ID="fuImageUpload" runat="server" />
                                                <asp:HiddenField ID="hfImage" runat="server" />
                                            </div>

                                        </div>

                                    </div>
                                    <div class="panel-footer" style="border-top: 0px !important;">
                                        <div class="col-sm-5"></div>
                                        <asp:Button ID="btnSubmitClientPersonal" runat="server" Text="Submit" ValidationGroup="Client" OnClick="btnSubmitClientPersonal_Click" CssClass="btn btn-primary"></asp:Button>
                                        <asp:Button ID="btnCancleClientPersonal" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancleClientPersonal_Click"></asp:Button>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabAddress">

                                    <div class="panel-body">
                                        <div class="row" id="searchaddress" runat="server">
                                            <div class="col-lg-12">
                                                <div class="col-lg-1 form-group">
                                                    <asp:DropDownList ID="DropPageAddress" runat="server" CssClass="form-control"
                                                        OnSelectedIndexChanged="DropPageAddress_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2 form-group">
                                                    <label class="control-label">
                                                        Records per page</label>
                                                </div>
                                                <div class="col-lg-6"></div>

                                                <div class="col-lg-3">
                                                    <input id="target2" type="text" class="form-control" placeholder="Text To Search" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvAddressDetails" runat="server" Width="100%" OnPageIndexChanging="gvAddressDetails_PageIndexChanging"
                                                AutoGenerateColumns="False" DataKeyNames="AddressDetailID" CssClass="rounded-corners" OnRowDeleting="gvAddressDetails_RowDeleting"
                                                EmptyDataText="There are no data records to display. Please add address details."
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" OnRowEditing="gvAddressDetails_RowEditing"
                                                CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvAddressDetails_RowCommand">
                                                <PagerStyle CssClass="pagination_grid" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-CssClass="panel-heading" ItemStyle-CssClass="gradeC">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Address Detail ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAddressDetailID" Text='<%#Eval("AddressDetailID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblFullName" Text='<%#Eval("FirstName")+" "+Eval("LastName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client Identification #">
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
                                                     <asp:TemplateField HeaderText="Complex" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblComplex" Text='<%#Eval("Complex") %>'></asp:Label>
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
                                                   <%-- <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                CommandName="EditAddress" ToolTip="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnAddressDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                CommandName="Delete" ToolTip="Delete" />
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
                                                    <asp:DropDownList ID="DropPageBank" runat="server"
                                                        OnSelectedIndexChanged="DropPageBank_SelectedIndexChanged" CssClass="form-control"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2 form-group">
                                                    <label class="control-label">
                                                        Records per page</label>
                                                </div>
                                                <div class="col-lg-6"></div>
                                                <div class="col-lg-3">
                                                    <input id="target1" type="text" class="form-control" placeholder="Text To Search" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvBankDetails" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="BankDetailID" CssClass="rounded-corners"
                                                EmptyDataText="There are no data records to display. Please add bank details." OnPageIndexChanging="gvBankDetails_PageIndexChanging"
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" OnRowEditing="gvBankDetails_RowEditing"
                                                CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowDeleting="gvBankDetails_RowDeleting" OnRowCommand="gvBankDetails_RowCommand">
                                                <PagerStyle CssClass="pagination_grid" />
                                                <Columns>

                                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-CssClass="panel-heading" ItemStyle-CssClass="gradeC">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Bank ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBankDetailID" Text='<%#Eval("BankDetailID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client Identification #">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblFullName" Text='<%#Eval("FIRSTNAME")+" "+Eval("LASTNAME") %>'></asp:Label>
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
                                                   <%-- <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                CommandName="EditBank" ToolTip="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnbankDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                CommandName="Delete" ToolTip="Delete" />
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
        </div>
        <!-- /.content -->
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
                                                    <asp:TextBox ID="txtIDNo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-8 form-group">
                                                    <label class="control-label">Client Name</label>
                                                    <asp:TextBox ID="txtAddressClientName" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">House No</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtHouseNo" CssClass="form-control" runat="server" placeholder="Enter House No"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvHouseNo" runat="server" ControlToValidate="txtHouseNo" Display="Dynamic" ErrorMessage="Enter Plot No Number"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Building Name</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtBulding" CssClass="form-control" runat="server" placeholder="Enter Building Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvBulding" runat="server" ControlToValidate="txtBulding" Display="Dynamic" ErrorMessage="Enter Building name"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Floor</label>
                                                    <asp:TextBox ID="txtFloor" CssClass="form-control" runat="server" placeholder="Enter Floor"></asp:TextBox>
                                                </div>

                                            </div>

                                            <div class="col-sm-12">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Flat No</label>
                                                    <asp:TextBox ID="txtFlatNo" CssClass="form-control" runat="server" placeholder="Enter Flat No"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Road Name</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtRoadName" CssClass="form-control" runat="server" placeholder="Enter Road Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvRoadName" runat="server" ControlToValidate="txtRoadName" Display="Dynamic" ErrorMessage="Enter Road Name"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Road No</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtRoadNo" CssClass="form-control" runat="server" placeholder="Enter Road No"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvRoadNo" runat="server" ControlToValidate="txtRoadNo" Display="Dynamic" ErrorMessage="Enter Road No"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>

                                            <div class="col-sm-12">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Suburb Name</label><%--<span class="style1">*</span>--%>
                                                    <asp:TextBox ID="txtSuburbName" CssClass="form-control" runat="server" placeholder="Enter Suburb Name"></asp:TextBox>
                                                  <%--  <asp:RequiredFieldValidator ID="rfvSuburbName" runat="server" ControlToValidate="txtSuburbName" Display="Dynamic" ErrorMessage="Enter Suburb Name"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                        <label class="control-label">City</label>
                                                        <asp:TextBox ID="txtCity" CssClass="form-control" runat="server" placeholder="Enter City"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label">Complex/Estate</label><%--<span class="style1">*</span>--%>
                                                        <asp:TextBox ID="txtComplex" CssClass="form-control" runat="server" placeholder="Enter Complex/Estate"></asp:TextBox>
                                                    </div>
                                                
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Postal Code</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtPostalCode" CssClass="form-control" runat="server" placeholder="Enter Postal Code" MaxLength="6"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvPostalCode" runat="server" ControlToValidate="txtPostalCode" Display="Dynamic" ErrorMessage="Enter Postal Code"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Province</label><span class="style1">*</span>
                                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvProvince" runat="server" ControlToValidate="ddlProvince" Display="Dynamic" ErrorMessage="Please select Province"
                                                        ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Country</label><span class="style1">*</span>
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
                        <asp:Button ID="btnAddressCancel" runat="server" Text="Cancel" CssClass="btn btn-danger"></asp:Button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>

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
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Identification #</label>
                                                            <asp:TextBox ID="txtSAIDBank" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>

                                                        </div>
                                                        <div class="col-sm-8 form-group">
                                                            <label class="control-label">Client Name</label>
                                                            <asp:TextBox ID="txtClientNameBank" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12">

                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Bank Name</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtBankName" runat="server" class="form-control" placeholder="Enter Bank Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvBankName" runat="server" ControlToValidate="txtBankName" Display="Dynamic" ErrorMessage="Enter Bank Name"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Branch Number</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtBranchNumber" runat="server" class="form-control" placeholder="Enter Branch No"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvBranchNumber" runat="server" ControlToValidate="txtBranchNumber" Display="Dynamic" ErrorMessage="Enter Branch Number"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Account Number</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtAccountNumber" runat="server" class="form-control" placeholder="Enter Account No"></asp:TextBox>
                                                            <asp:Label ID="lblBankMsg" runat="server" ForeColor="Red"></asp:Label>
                                                            <asp:RequiredFieldValidator ID="rfvAccountNumber" runat="server" ControlToValidate="txtAccountNumber" Display="Dynamic" ErrorMessage="Enter Account Number"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>

                                                    </div>

                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Account Type</label><span class="style1">*</span>
                                                            <asp:DropDownList ID="ddlAccountType" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvAccountType" runat="server" ControlToValidate="ddlAccountType" Display="Dynamic" ErrorMessage="Please select Account Type"
                                                                ValidationGroup="Bank" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Currency</label><%--<span class="style1">*</span>--%>
                                                            <asp:TextBox ID="txtCurrency" runat="server" class="form-control" placeholder="Enter Currency"></asp:TextBox>
                                                         <%--   <asp:RequiredFieldValidator ID="rfvCurrency" runat="server" ControlToValidate="txtCurrency" Display="Dynamic" ErrorMessage="Enter Currency"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Swift</label><%--<span class="style1">*</span>--%>
                                                            <asp:TextBox ID="txtSwift" runat="server" class="form-control" placeholder="Enter Swift"></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="rfvSwift" runat="server" ControlToValidate="txtSwift" Display="Dynamic" ErrorMessage="Enter Swift"
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
                        <asp:Button ID="btnUpdateBank" runat="server" Text="Update" ValidationGroup="Bank" CssClass="btn btn-primary" OnClick="btnUpdateBank_Click"></asp:Button>
                        <asp:Button ID="btnBankCancel" runat="server" Text="Cancel" CssClass="btn btn-danger"></asp:Button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    </div>
    <script type="text/javascript">
        $("#ContentPlaceHolder1_txtMobileNo,#ContentPlaceHolder1_txtPhoneNo,#ContentPlaceHolder1_txtSAId,#ContentPlaceHolder1_txtPostalCode,#ContentPlaceHolder1_txtAccountNumber").bind('keypress', function (e) {
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
        $("#ContentPlaceHolder1_txtMobileNo,#ContentPlaceHolder1_txtPhoneNo,#ContentPlaceHolder1_txtSAId,#ContentPlaceHolder1_txtPostalCode,#ContentPlaceHolder1_txtAccountNumber").bind('mouseenter', function (e) {
            var val = $(this).val();
            if (val != '0') {
                val = val.replace(/[^0-9]+/g, "");
                $(this).val(val);
            }
        });
    </script>
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

