<%@ Page Title="" Language="C#" MasterPageFile="~/ClientForms/Layout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ClientForms_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <div class="content-header">
                <div class="header-title">
                    <h1>Trust Information</h1>
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
                                    <h5>Add Trust</h5>
                                </div>
                            </div>
                            <div class="panel-body">
                                <ul class="nav nav-tabs">
                                    <li class="active"><a href="#tab1" data-toggle="tab">Trust Information</a></li>
                                    <li><a href="#tab2" data-toggle="tab">Residential Address</a></li>
                                    <li><a href="#tab3" data-toggle="tab">Bank Details</a></li>
                                </ul>

                                <div class="tab-content">
                                    <div class="tab-pane fade in active" id="tab1">
                                        <div class="panel-body">
                                            <div class="col-sm-12">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Trust UIC</label>
                                                    <asp:TextBox ID="txtUIC" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtUIC" runat="server" ControlToValidate="txtUIC" Display="Dynamic" ErrorMessage="Enter UIC Number"
                                                        ValidationGroup="trust" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Trust Name</label>
                                                    <asp:TextBox ID="txtTrustName" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvTrustName" runat="server" ControlToValidate="txtTrustName" Display="Dynamic" ErrorMessage="Enter Trust Name"
                                                        ValidationGroup="trust" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Year of Trust Foundation</label>
                                                    <asp:TextBox ID="txtYearofFoundation" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvYearOfFoundation" runat="server" ControlToValidate="txtYearofFoundation" Display="Dynamic"
                                                        ErrorMessage="Enter year of Foundation"
                                                        ValidationGroup="trust" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Tax Reference No</label>
                                                    <asp:TextBox ID="txtTaxRef" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvTaxRefNo" runat="server" ControlToValidate="txtTaxRef" Display="Dynamic"
                                                        ErrorMessage="Enter Tax Reference"
                                                        ValidationGroup="trust" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Telephone</label>
                                                    <asp:TextBox ID="txtTelephone" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvTelephone" runat="server" ControlToValidate="txtTelephone" Display="Dynamic"
                                                        ErrorMessage="Enter Telephone"
                                                        ValidationGroup="trust" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Fax</label>
                                                    <asp:TextBox ID="txtFax" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Email Id</label>
                                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                                                        ErrorMessage="Enter Email ID"
                                                        ValidationGroup="trust" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Website</label>
                                                    <asp:TextBox ID="txtWebsite" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="panel-footer" style="border-top: 0px !important;">
                                            <div class="col-sm-5"></div>
                                            <asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="trust" CssClass="btn btn-primary"></asp:Button>
                                            <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btn btn-danger"></asp:Button>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="tab2">
                                        <div class="panel-body">
                                            <div class="col-sm-12">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Plot No</label>
                                                    <asp:TextBox ID="txtPlotNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtPlotNo" runat="server" ControlToValidate="txtPlotNo" Display="Dynamic" ErrorMessage="Enter Plot No Number"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Building Name</label>
                                                    <asp:TextBox ID="txtBulding" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvBuildingNo" runat="server" ControlToValidate="txtBulding" Display="Dynamic" ErrorMessage="Enter Building name"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Floor</label>
                                                    <asp:TextBox ID="txtFloor" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Flat No</label>
                                                    <asp:TextBox ID="txtFlatrNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-sm-12">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Road Name</label>
                                                    <asp:TextBox ID="txtRoadName" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvRoadName" runat="server" ControlToValidate="txtRoadName" Display="Dynamic" ErrorMessage="Enter Road Name"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Road No</label>
                                                    <asp:TextBox ID="txtRoadNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvRoadNo" runat="server" ControlToValidate="txtRoadNo" Display="Dynamic" ErrorMessage="Enter Road No"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Suburb Name</label>
                                                    <asp:TextBox ID="txtSuburbName" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvSuburbName" runat="server" ControlToValidate="txtSuburbName" Display="Dynamic" ErrorMessage="Enter Suburb Name"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">City</label>
                                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity" Display="Dynamic" ErrorMessage="Please select City"
                                                        ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="col-sm-12">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Postal Code</label>
                                                    <asp:TextBox ID="txtPostalCode" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvPostalCode" runat="server" ControlToValidate="txtPostalCode" Display="Dynamic" ErrorMessage="Enter Postal Code"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Province</label>
                                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvProvince" runat="server" ControlToValidate="ddlProvince" Display="Dynamic" ErrorMessage="Please select Province"
                                                        ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Country</label>
                                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Please select Country"
                                                        ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel-footer" style="border-top: 0px !important;">
                                            <div class="col-sm-5"></div>
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="Address" CssClass="btn btn-primary"></asp:Button>
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger"></asp:Button>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="tab3">

                                        <div class="panel-body">

                                            <div class="col-sm-12">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Bank Name</label>
                                                    <asp:TextBox ID="txtBankName" runat="server" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvBankName" runat="server" ControlToValidate="txtBankName" Display="Dynamic" ErrorMessage="Enter Bank Name"
                                                        ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Branch Number</label>
                                                    <asp:TextBox ID="txtBranchNumber" runat="server" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvBranchNumber" runat="server" ControlToValidate="txtBranchNumber" Display="Dynamic" ErrorMessage="Enter Branch Number"
                                                        ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Account Number</label>
                                                    <asp:TextBox ID="txtAccountNumber" runat="server" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvAccountNumber" runat="server" ControlToValidate="txtAccountNumber" Display="Dynamic" ErrorMessage="Enter Account Number"
                                                        ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Account Type</label>
                                                    <asp:DropDownList ID="ddlAccountType" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvAccountType" runat="server" ControlToValidate="ddlAccountType" Display="Dynamic" ErrorMessage="Please select Account Type"
                                                        ValidationGroup="Bank" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="col-sm-12">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Currency</label>
                                                    <asp:TextBox ID="txtCurrency" runat="server" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCurrency" Display="Dynamic" ErrorMessage="Enter Currency"
                                                        ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label">Swift</label>
                                                    <asp:TextBox ID="txtSwift" runat="server" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvSwift" runat="server" ControlToValidate="txtSwift" Display="Dynamic" ErrorMessage="Enter Swift"
                                                        ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="panel-footer" style="border-top: 0px !important;">
                                            <div class="col-sm-5"></div>
                                            <asp:Button ID="Button3" runat="server" Text="Submit" ValidationGroup="Bank" CssClass="btn btn-primary"></asp:Button>
                                            <asp:Button ID="Button4" runat="server" Text="Cancel" CssClass="btn btn-danger"></asp:Button>
                                        </div>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.content -->
        </div>
    
</asp:Content>

