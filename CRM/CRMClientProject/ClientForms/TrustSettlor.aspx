﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ClientForms/Layout.master" AutoEventWireup="true" CodeFile="TrustSettlor.aspx.cs" Inherits="ClientForms_TrustSettlor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $("#target").keyup(function () {
                 if ($("[id *=target]").val() != "") {
                     $("[id *=ContentPlaceHolder1_gvTrust]").children
                     ('tbody').children('tr').each(function () {
                         $(this).show();
                     });
                     $("[id *=ContentPlaceHolder1_gvTrust]").children
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


                     $("[id *=ContentPlaceHolder1_gvTrust]").children('tbody').
                             children('tr').each(function (index) {
                                 if (index == 0)
                                     $(this).show();
                             });
                 }
                 else {
                     $("[id *=ContentPlaceHolder1_gvTrust]").children('tbody').
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

        $(document).ready(function (event) {
            $("#ContentPlaceHolder1_txtTelephone,ContentPlaceHolder1_txtUIC").bind('keypress', function (e) {
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
            $("#ContentPlaceHolder1_txtTelephone,ContentPlaceHolder1_txtUIC").bind('mouseenter', function (e) {
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
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="header-title">
                <h1>Trust Settlor Information</h1>
            </div>
        </div>
        <!-- Main content -->
        <div class="content">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Add Trust Settlor</h5>
                            </div>
                        </div>
                        <div class="panel-body">

                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#tabTrust" data-toggle="tab">Settlor Details</a></li>
                                <li><a href="#tabAddress" data-toggle="tab">Address Details</a></li>
                                <li><a href="#tabBank" data-toggle="tab">Bank Details</a></li>
                            </ul>

                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="tabTrust">
                                    <div>
                                        <asp:HiddenField ID="hfTrustSettlerId" runat="server" Value="0" />
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Trust Registration Number</label>
                                                <asp:TextBox ID="txtTrustUIC" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">

                                                <label class="control-label">SAID</label>
                                                <asp:TextBox ID="txtSAID" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtSAID" runat="server" ControlToValidate="txtSAID" Display="Dynamic" ErrorMessage="Enter SAID"
                                                    ValidationGroup="Settler" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">First Name</label>
                                                <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFirstName" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="Enter First Name"
                                                    ValidationGroup="Settler" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Last Name</label>
                                                <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtLastName" runat="server" ControlToValidate="txtLastName" Display="Dynamic"
                                                    ErrorMessage="Enter Last Name"
                                                    ValidationGroup="Settler" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Tax Reference No.</label>
                                                <asp:TextBox ID="txtTaxRefNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtTaxRefNo" runat="server" ControlToValidate="txtTaxRefNo" Display="Dynamic"
                                                    ErrorMessage="Enter Tax Reference Number."
                                                    ValidationGroup="Settler" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Email Id</label>
                                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                                                    ErrorMessage="Enter Email Id"
                                                    ValidationGroup="Settler" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Mobile</label>
                                                <asp:TextBox ID="txtMobile" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtMobile" runat="server" ControlToValidate="txtMobile" Display="Dynamic"
                                                    ErrorMessage="Enter Mobile Number"
                                                    ValidationGroup="Settler" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Phone</label>
                                                <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="panel-footer" style="border-top: 0px !important;">
                                        <div class="col-sm-5"></div>
                                        <asp:Button ID="btnSubmit" runat="server" Text="Save" ValidationGroup="Settler" OnClick="btnSubmit_Click" CssClass="btn btn-primary"></asp:Button>
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger"></asp:Button>
                                    </div>

                                    <div class="panel panel-bd">
                                        <div class="panel-heading">
                                            <div class="panel-title">
                                                <h5>List of Trustees</h5>
                                            </div>
                                        </div>

                                       <div class="row" id="search" runat="server">
                                            <div class="col-lg-12">
                                                <div class="col-lg-4" style="margin-top: 15px">
                                                    <asp:DropDownList ID="DropPage" runat="server"
                                                        OnSelectedIndexChanged="DropPage_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                        <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                                                        <asp:ListItem Value="20">20</asp:ListItem>
                                                        <asp:ListItem Value="50">50</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <label class="control-label">
                                                        Records per page</label>
                                                </div>
                                                <div class="col-lg-3" style="margin-top: 10px">
                                                    <input id="target" type="text" class="form-control" placeholder="Text To Search" />
                                                </div>

                                            </div>
                                        </div>
                                        <div class="panel-body" style="margin-top: 10px">
                                            <div class="table-responsive">
                                                <asp:GridView ID="gvTrustSettler" runat="server" Width="100%"
                                                    AutoGenerateColumns="False" DataKeyNames="TrustSettlerID" CssClass="rounded-corners"
                                                    EmptyDataText="There are no data records to display." BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100" HeaderStyle-BackColor="#e8f1f3"
                                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" OnRowCommand="gvTrustSettler_RowCommand">
                                                    <PagerStyle CssClass="pagination_grid" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S No.">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Trust Settlor Id" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblTrustSettlerId" Text='<%#Eval("TrustSettlerID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Client SAID">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Client UIC" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblReferenceUIC" Text='<%#Eval("ReferenceUIC") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SAID">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="First Name">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblFirstName" Text='<%#Eval("FirstName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="LastName">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblLastName" Text='<%#Eval("LastName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Tax Ref No." Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblTaxRefNo" Text='<%#Eval("TaxRefNo") %>'></asp:Label>
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

                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                    CommandName="EditTrustSettler" ToolTip="Edit" CommandArgument='<%#Eval("TrustSettlerID") %>' />
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
                                                                    CommandName="DeleteSettler" ToolTip="Address Details" CommandArgument='<%#Eval("TrustSettlerID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>

                                </div>


                                <div class="tab-pane fade" id="tabAddress">
                                      <div class="row" id="searchaddress" runat="server">
                                        <div class="col-lg-12">
                                            <div class="col-lg-4" style="margin-top: 15px">
                                                <asp:DropDownList ID="dropAddress" runat="server"
                                                    OnSelectedIndexChanged="dropAddress_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                    <asp:ListItem Value="50">50</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="control-label">
                                                    Records per page</label>
                                            </div>
                                            <div class="col-lg-3" style="margin-top: 10px">
                                                <input id="targetAddress" type="text" class="form-control" placeholder="Text To Search" />
                                            </div>

                                        </div>
                                    </div>
                                    <div class="panel-body" style="margin-top:10px;">
                                        
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

                                                    <asp:TemplateField HeaderText="SAID">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trust Registration #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="ReferenceSAID">
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
                                    <div class="row" id="searchbank" runat="server">
                                        <div class="col-lg-12">
                                            <div class="col-lg-4" style="margin-top: 15px">
                                                <asp:DropDownList ID="dropBank" runat="server"
                                                    OnSelectedIndexChanged="dropBank_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                    <asp:ListItem Value="50">50</asp:ListItem>
                                                </asp:DropDownList>
                                                <label class="control-label">
                                                    Records per page</label>
                                            </div>
                                            <div class="col-lg-3" style="margin-top: 10px">
                                                <input id="targetBank" type="text" class="form-control" placeholder="Text To Search" />
                                            </div>

                                        </div>
                                    </div>
                                    <div class="panel-body" style="margin-top: 10px;">
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
                                                    <asp:TemplateField HeaderText="SAID">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBankSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trust Registration #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBankUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ReferenceSAID">
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
                                    <div class="col-md-12 form-group user-form-group">
                                        <div class="panel-body">
                                            <div class="col-sm-12">
                                                <asp:Label ID="lblBankMessage" runat="server"></asp:Label>
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
                                                    <label class="control-label">House No</label>
                                                    <asp:TextBox ID="txtHouseNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvHouseNo" runat="server" ControlToValidate="txtHouseNo" Display="Dynamic" ErrorMessage="Enter Plot No Number"
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
                                                    <asp:TextBox ID="txtPostalCode" CssClass="form-control" runat="server"></asp:TextBox>
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

</asp:Content>

