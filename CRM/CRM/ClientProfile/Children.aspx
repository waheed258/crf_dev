<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/LayoutForClientProfile.master" AutoEventWireup="true" CodeFile="Children.aspx.cs" Inherits="ClientProfile_Children" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js"></script>
    <script type="text/javascript">

        $(document).ready(function (event) {
            $("#ContentPlaceHolder1_txtMobileNum,#ContentPlaceHolder1_txtPhoneNum,#ContentPlaceHolder1_txtSAID,#ContentPlaceHolder1_txtPostalCode,#ContentPlaceHolder1_txtAccountNumber").bind('keypress', function (e) {
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
            $("#ContentPlaceHolder1_txtMobileNum,#ContentPlaceHolder1_txtPhoneNum,#ContentPlaceHolder1_txtSAID,#ContentPlaceHolder1_txtPostalCode,#ContentPlaceHolder1_txtAccountNumber").bind('mouseenter', function (e) {
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
                    $("[id *=ContentPlaceHolder1_gvChildDetails]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvChildDetails]").children
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


                    $("[id *=ContentPlaceHolder1_gvChildDetails]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvChildDetails]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
        });
        $(document).ready(function () {
            $("#target1").keyup(function () {
                if ($("[id *=target1]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gdvBankList]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gdvBankList]").children
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
            $("#target2").keyup(function () {
                if ($("[id *=target2]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvAddress]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvAddress]").children
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
        .style1 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="header-title">
                <h1>Children Information</h1>
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
                                <h5>Add Children</h5>
                            </div>
                        </div>
                        <div class="panel-body" id="Tabs">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#tab1" data-toggle="tab">Child Information</a></li>
                                <li><a href="#tab3" data-toggle="tab">Address Details</a></li>
                                <li><a href="#tab2" data-toggle="tab">Bank Details</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="tab1">
                                    <div class="panel-body">

                                        <div class="col-md-12">
                                            <div class="form-group col-sm-3">
                                                <div class="col-sm-11" style="padding: 0px;">
                                                    <label>Identification Number</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtSAID" runat="server" CssClass="form-control" placeholder="Enter SAID" MaxLength="13"></asp:TextBox>
                                                    <asp:Label ID="msgSAID" runat="server" CssClass="control-label" Style="color: red" />
                                                    <asp:RequiredFieldValidator ID="rfvSAID" runat="server" ControlToValidate="txtSAID" ForeColor="Red"
                                                        ErrorMessage="Please Enter SAID" ValidationGroup="Child" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revSAID" runat="server" ErrorMessage="Please enter 13 digits" ValidationExpression="[0-9]{13}" Display="Dynamic"
                                                        ControlToValidate="txtSAID" ForeColor="Red" ValidationGroup="Child"></asp:RegularExpressionValidator>
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
                                                  <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="ddlTitle" ForeColor="Red"
                                                    ErrorMessage="Please Select Title" ValidationGroup="Child" Display="Dynamic" InitialValue=""></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group col-sm-3">
                                                <label>First Name</label><span class="style1">*</span>
                                                <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" placeholder="Enter First Name" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ForeColor="Red"
                                                    ErrorMessage="Please Enter First Name" ValidationGroup="Child" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group col-sm-3">
                                                <label>Last Name</label><span class="style1">*</span>
                                                <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" placeholder="Enter Last Name" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ForeColor="Red"
                                                    ErrorMessage="Please Enter Last Name" ValidationGroup="Child" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>
                                        <div class="col-sm-12">
                                            <div class="form-group col-sm-3">
                                                <label>Email</label><span class="style1">*</span>
                                                <asp:TextBox ID="txtEmailId" CssClass="form-control" runat="server" placeholder="Enter EmailId" MaxLength="75"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtEmailId" ForeColor="Red"
                                                    ErrorMessage="Please Enter Email" ValidationGroup="Child" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revEmailId" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please check Email Format"
                                                    ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Child">
                                                </asp:RegularExpressionValidator>

                                            </div>
                                            <div class="form-group col-sm-3">
                                                <label>Mobile</label><span class="style1">*</span>
                                                <asp:TextBox ID="txtMobileNum" CssClass="form-control" runat="server" placeholder="Enter Mobile Number" MaxLength="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvMobileNum" runat="server" ControlToValidate="txtMobileNum" ForeColor="Red"
                                                    ErrorMessage="Please Enter Mobile" ValidationGroup="Child" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revMobileNum" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                    ControlToValidate="txtMobileNum" ForeColor="Red" ValidationGroup="Child"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="form-group col-sm-3">
                                                <label>Phone</label>
                                                <asp:TextBox ID="txtPhoneNum" CssClass="form-control" runat="server" placeholder="Enter Phone Number" MaxLength="10"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revPhoneNum" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                    ControlToValidate="txtPhoneNum" ForeColor="Red" ValidationGroup="Child"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="form-group col-sm-3">
                                                <label>Tax Reference Number</label>
                                                <asp:TextBox ID="txtTaxRefNum" runat="server" CssClass="form-control" placeholder="Enter Tax Reference Number"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="col-sm-12">
                                            <div class="form-group col-sm-3">
                                                <label>Date Of Birth</label><span class="style1">*</span>
                                                <asp:TextBox ID="txtDateOfBirth" CssClass="form-control" runat="server" placeholder="Enter Date Of Birth" TextMode="Date"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth" ForeColor="Red"
                                                    ErrorMessage="Please Enter Date Of Birth" ValidationGroup="Child" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Photo Upload</label>
                                                <asp:FileUpload ID="fuPhoto" runat="server" AllowMultiple="true"></asp:FileUpload>

                                                <a id="anchorId" href="#" runat="server" target="_blank">
                                                    <asp:Label ID="lblPhotoName" runat="server" /></a>

                                                <asp:RegularExpressionValidator ControlToValidate="fuPhoto" runat="server" ID="revfuPhoto" ForeColor="Red"
                                                    Display="Dynamic" CssClass="span6 m-wrap" ErrorMessage="Select only jpg,png Files." ValidationGroup="Child"
                                                    ValidationExpression="^.*\.(jpg|png|JPG|PNG)$" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-footer" style="border-top: 0px !important;">
                                        <div class="col-sm-5"></div>
                                        <asp:Button ID="btnChildSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Child" OnClick="btnChildSubmit_Click" />
                                        <asp:Button ID="btnChildUpdate" runat="server" Text="Update" ValidationGroup="Child" CssClass="btn btn-primary" OnClick="btnChildUpdate_Click"></asp:Button>
                                        <asp:Button ID="btnChildCancel" runat="server" Text="Cancel" class="btn btn-danger" OnClick="btnChildCancel_Click" />
                                    </div>


                                    <div class="panel panel-bd" id="ChildList" runat="server">
                                        <div class="panel-heading">
                                            <div class="panel-title">
                                                <h5>List of Children</h5>
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
                                            <asp:GridView ID="gvChildDetails" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="ChildrenID" CssClass="rounded-corners"
                                                EmptyDataText="There are no data records to display."
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" OnRowEditing="gvChildDetails_RowEditing" OnRowDeleting="gvChildDetails_RowDeleting"
                                                CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvChildDetails_RowCommand" OnPageIndexChanging="gvChildDetails_PageIndexChanging">
                                                <PagerStyle CssClass="pagination_grid" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Childern Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblChildrenID" Text='<%#Eval("ChildrenID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Identification #">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Title" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblTitle" Text='<%#Eval("Title") %>'></asp:Label>
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
                                                    <asp:TemplateField HeaderText="Email ID">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblEmailID" Text='<%#Eval("EmailID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mobile" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblMobile" Text='<%#Eval("Mobile") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Phone" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblPhone" Text='<%#Eval("Phone") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="TaxRefNo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblTaxRefNo" Text='<%#Eval("TaxRefNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DateOfBirth" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblDateOfBirth" Text='<%#Eval("DateOfBirth") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client Identification #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Photo Upload" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblImage" Text='<%#Eval("Image") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                CommandName="Edit" CommandArgument='<%#Eval("ChildrenID") %>' ToolTip="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                CommandName="Delete" ToolTip="Delete" />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Document">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnDocument" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/upload.png"
                                                                CommandName="Document" ToolTip="Add Documents" CommandArgument='<%#Eval("SAID") %>' />
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
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tab2">

                                    <div class="panel-body">
                                        <div class="row" id="searchbank" runat="server">
                                            <div class="col-lg-12">
                                                <div class="col-lg-1 form-group">
                                                    <asp:DropDownList ID="dropPage2" runat="server"
                                                        OnSelectedIndexChanged="dropPage2_SelectedIndexChanged" CssClass="form-control"
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
                                            <asp:GridView ID="gdvBankList" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="BankDetailID" CssClass="rounded-corners"
                                                EmptyDataText="There are no data records to display."
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" OnRowEditing="gdvBankList_RowEditing" OnRowDeleting="gdvBankList_RowDeleting"
                                                CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gdvBankList_RowCommand" OnPageIndexChanging="gdvBankList_PageIndexChanging">
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
                                                            <asp:Label runat="server" ID="lblSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Child Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblChildName" Text='<%#Eval("FIRSTNAME")+" "+Eval("LASTNAME") %>'></asp:Label>
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

                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                CommandName="Edit" CommandArgument='<%#Eval("BankDetailID") %>' ToolTip="Edit" />
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
                                <div class="tab-pane fade" id="tab3">

                                    <div class="panel-body">
                                        <div class="row" id="searchaddress" runat="server">
                                            <div class="col-lg-12">
                                                <div class="col-lg-1 form-group">
                                                    <asp:DropDownList ID="DropPage1" runat="server"
                                                        OnSelectedIndexChanged="DropPage1_SelectedIndexChanged"
                                                        AutoPostBack="true" CssClass="form-control">
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
                                            <asp:GridView ID="gvAddress" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="AddressDetailID" CssClass="rounded-corners"
                                                EmptyDataText="There are no data records to display."
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" OnRowEditing="gvAddress_RowEditing" OnRowDeleting="gvAddress_RowDeleting"
                                                CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvAddress_RowCommand" OnPageIndexChanging="gvAddress_PageIndexChanging">
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
                                                    <asp:TemplateField HeaderText="Child Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAddChildName" Text='<%#Eval("FirstName")+" "+Eval("LastName") %>'></asp:Label>
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
                                                                CommandName="Edit" ToolTip="Edit" CommandArgument='<%#Eval("AddressDetailID") %>' />
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
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-12 form-group user-form-group">
                                                <div class="panel-body">
                                                    <div class="col-sm-12">
                                                        <asp:Label ID="lblBankMessage" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Identification #</label>
                                                            <asp:TextBox ID="txtSAIDBank" runat="server" CssClass="form-control" ReadOnly="true" placeholder="Enter Identification"></asp:TextBox>

                                                        </div>
                                                        <div class="col-sm-8 form-group">
                                                            <label class="control-label">Child Name</label>
                                                            <asp:TextBox ID="txtChildNameBank" runat="server" CssClass="form-control" ReadOnly="true" placeholder="Enter Child Name"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Bank Name</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control" placeholder="Enter Bank Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvBankName" runat="server" ControlToValidate="txtBankName" Display="Dynamic" ErrorMessage="Enter Bank Name"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Branch Number</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtBranchNumber" runat="server" CssClass="form-control" placeholder="Enter Branch Number"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvBranchNumber" runat="server" ControlToValidate="txtBranchNumber" Display="Dynamic" ErrorMessage="Enter Branch Number"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Account Number</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtAccountNumber" runat="server" CssClass="form-control" placeholder="Enter Account Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAccountNumber" runat="server" ControlToValidate="txtAccountNumber" Display="Dynamic" ErrorMessage="Enter Account Number"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>

                                                    </div>

                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Account Type</label><span class="style1">*</span>
                                                            <asp:DropDownList ID="ddlAccountType" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvAccountType" runat="server" ControlToValidate="ddlAccountType" Display="Dynamic" ErrorMessage="Please select Account Type"
                                                                ValidationGroup="Bank" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Currency</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtCurrency" runat="server" CssClass="form-control" placeholder="Enter Currency"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvCurrency" runat="server" ControlToValidate="txtCurrency" Display="Dynamic" ErrorMessage="Enter Currency"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Swift</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtSwift" runat="server" CssClass="form-control" placeholder="Enter Swift"></asp:TextBox>
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
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-12 form-group user-form-group">
                                                <div class="panel-body">
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-12 form-group">
                                                            <asp:CheckBox ID="chkClientAddress" runat="server" Text="Same as Client Address" AutoPostBack="true" OnCheckedChanged="chkClientAddress_CheckedChanged" />
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Identification #</label>
                                                            <asp:TextBox ID="txtSAIDAddress" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>


                                                        </div>
                                                        <div class="col-sm-8 form-group">
                                                            <label class="control-label">Child Name</label>
                                                            <asp:TextBox ID="txtChildNameAddress" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
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
                                                            <label class="control-label">Suburb Name</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtSuburbName" CssClass="form-control" runat="server" placeholder="Enter Suburb Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvSuburbName" runat="server" ControlToValidate="txtSuburbName" Display="Dynamic" ErrorMessage="Enter Suburb Name"
                                                                ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">City</label><span class="style1">*</span>
                                                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity" Display="Dynamic" ErrorMessage="Please select City"
                                                                ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Postal Code</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtPostalCode" CssClass="form-control" runat="server" placeholder="Enter Postal Code" MaxLength="6"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvPostalCode" runat="server" ControlToValidate="txtPostalCode" Display="Dynamic" ErrorMessage="Enter Postal Code"
                                                                ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12">
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
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
