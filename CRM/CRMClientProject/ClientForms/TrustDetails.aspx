<%@ Page Title="" Language="C#" MasterPageFile="~/ClientForms/Layout.master" AutoEventWireup="true" CodeFile="TrustDetails.aspx.cs" Inherits="Client_TrustDetails" %>

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
                                <li ><a href="#tab1" data-toggle="tab">Bank Details</a></li>
                            </ul>

                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="tab1">
                                    <div class="panel-body">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Trust UIC</label>
                                                <asp:TextBox ID="txtUIC" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtUIC" runat="server" ControlToValidate="txtUIC" Display="Dynamic" ErrorMessage="Enter UIC Number"
                                                    ValidationGroup="trust" ValidateRequestMode="Disabled" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Trust Name</label>
                                                <asp:TextBox ID="txtTrustName" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Year of Trust Foundation</label>
                                                <asp:TextBox ID="txtYearofFoundation" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Tax Reference No</label>
                                                <asp:TextBox ID="txtTaxRef" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Telephone</label>
                                                <asp:TextBox ID="txtTelephone" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Fax</label>
                                                <asp:TextBox ID="txtFax" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Email Id</label>
                                                <asp:TextBox ID="txxEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Website</label>
                                                <asp:TextBox ID="txtWebsite" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <%-- <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Residential Address</h5>
                            </div>
                        </div>--%>
                                <div class="tab-pane fade" id="tab2">
                                    <div class="panel-body">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Plot No</label>
                                                <asp:TextBox ID="txtPlotNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtPlotNo" runat="server" ControlToValidate="txtPlotNo" Display="Dynamic" ErrorMessage="Enter Plot No Number"
                                                    ValidationGroup="trust" ValidateRequestMode="Disabled" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Building Name</label>
                                                <asp:TextBox ID="txtBulding" CssClass="form-control" runat="server"></asp:TextBox>
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
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Road No</label>
                                                <asp:TextBox ID="txtRoadNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Suburb Name</label>
                                                <asp:TextBox ID="txtSuburbName" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">City</label>
                                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    <asp:ListItem Text="-Select City-" Value="-1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Postal Code</label>
                                                <asp:TextBox ID="txtPostalCode" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Province</label>
                                                <asp:TextBox ID="txtProvince" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Country</label>
                                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    <asp:ListItem Text="-Select Country-" Value="-1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel-footer">
                                    <div class="col-sm-5"></div>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="trust" CssClass="btn btn-primary"></asp:Button>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger"></asp:Button>
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

