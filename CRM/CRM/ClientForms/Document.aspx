<%@ Page Title="" Language="C#" MasterPageFile="~/ClientForms/Layout.master" AutoEventWireup="true" CodeFile="Document.aspx.cs" Inherits="ClientForms_Document" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="header-title">
                <h1>Documents</h1>
            </div>
        </div>
        <!-- Main content -->
        <div class="content">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-6">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Add Document</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div>
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-12">
                                <div class="col-sm-3 form-group">
                                    <label class="control-label">SAID</label>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <asp:TextBox ID="txtSAID" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxtSAID" runat="server" ControlToValidate="txtSAID" Display="Dynamic" ErrorMessage="Enter SAID"
                                        ForeColor="Red"  ValidationGroup="Doc"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="col-sm-3 form-group">
                                    <label class="control-label">Document</label>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <asp:FileUpload ID="fuDoc" runat="server" AllowMultiple="true" ></asp:FileUpload>
                                    <asp:RequiredFieldValidator ID="rfvfuDoc" runat="server" ControlToValidate="fuDoc" Display="Dynamic" ErrorMessage="Select Document"
                                        ForeColor="Red"  ValidationGroup="Doc"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="fuDoc" runat="server" ID="revfuDoc" ForeColor="Red"
                                        Display="Dynamic" CssClass="span6 m-wrap" ErrorMessage="Select only Pdf Files." ValidationGroup="Doc"
                                        ValidationExpression="^.*\.(pdf|PDF)$" />
                                </div>
                            </div>

                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="btn btn-primary" Text="Submit" ValidationGroup="Doc" />
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" CssClass="btn btn-danger" Text="Cancel" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

