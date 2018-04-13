<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="ClientRegistrationForm.aspx.cs" Inherits="AdminForms_ClientRegistrationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show');
        }
    </script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <section class="content-header">

            <div class="header-title">
                <h1>Register a Client</h1>
            </div>
        </section>
        <section class="content" id="sectionAdvisorList" runat="server">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-bd" runat="server">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Registraion</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12">
                                <div class="col-sm-3 form-group">
                                    <label class="control-label">Title</label>
                                    <asp:DropDownList ID="ddlTitle" CssClass="form-control" runat="server" Style="width: 68%">
                                        <asp:ListItem Value="-1">--Select Title--</asp:ListItem>
                                        <asp:ListItem Value="Mr">Mr</asp:ListItem>
                                        <asp:ListItem Value="Miss">Miss</asp:ListItem>
                                        <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                        <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                        <asp:ListItem Value="Dr">Dr</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="Please select Title" ControlToValidate="ddlTitle"
                                        InitialValue="-1" Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label class="control-label">First Name </label>
                                    <asp:TextBox ID="txtFirstName" CssClass="form-control" placeholder="Given Name" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Please enter First Name" ControlToValidate="txtFirstName"
                                        Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label class="control-label">Last Name </label>
                                    <asp:TextBox ID="txtLastName" CssClass="form-control" placeholder="Sur Name" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label class="control-label">SAID</label>
                                    <asp:TextBox ID="txtSAID" CssClass="form-control" placeholder="SAID" runat="server" MaxLength="13"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSAID" runat="server" ErrorMessage="Please enter SAID" ControlToValidate="txtSAID"
                                        Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rgvSAID" runat="server" ErrorMessage="Please enter 13 digits" ValidationExpression="[0-9]{13}" Display="Dynamic"
                                        ControlToValidate="txtSAID" ForeColor="#f31010" ValidationGroup="Save"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-sm-12">
                               <div class="col-sm-3 form-group">
                                    <label class="control-label">Province</label>
                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvProvince" runat="server" ControlToValidate="ddlProvince" Display="Dynamic" ErrorMessage="Please select Province"
                                        ValidationGroup="Save" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label class="control-label">City</label>
                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity" Display="Dynamic" ErrorMessage="Please select City"
                                        ValidationGroup="Save" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                               
                                <div class="col-sm-3 form-group">
                                    <label class="control-label">Mobile</label>
                                    <asp:TextBox ID="txtMobile" CssClass="form-control" placeholder="Mobile Number" runat="server" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMobileNum" runat="server" ErrorMessage="Please enter Mobile Number" ControlToValidate="txtMobile"
                                        Display="Dynamic" ValidationGroup="Save" ForeColor="#f31010"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rgvMobile" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                        ControlToValidate="txtMobile" ForeColor="#f31010" ValidationGroup="Save"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label class="control-label">Email Id</label>
                                    <asp:TextBox ID="txtEmailId" CssClass="form-control" runat="server" placeholder="Email ID"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmailId" Display="Dynamic"
                                        ErrorMessage="Enter Email ID"
                                        ValidationGroup="Save" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmailId" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please check Email Format"
                                        ControlToValidate="txtEmailId" CssClass="form-control" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Save">
                                    </asp:RegularExpressionValidator>
                                </div>

                            </div>
                        </div>
                        <div class="panel-footer" style="border-top: 0px !important;">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="btnRegistration" runat="server" Text="Submit" ValidationGroup="Save" CssClass="btn btn-primary" OnClick="btnRegistration_Click"></asp:Button>
                            <asp:Button ID="btnegistrationCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnegistrationCancel_Click"></asp:Button>
                        </div>
                    </div>
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
                                                <asp:Label ID="lblMessage" runat="server" Style="color: green"></asp:Label>
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
        </section>
    </div>
    <script type="text/javascript">
        $("#ContentPlaceHolder1_txtSAID,#ContentPlaceHolder1_txtMobile").bind('keypress', function (e) {
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
        $("#ContentPlaceHolder1_txtSAID,#ContentPlaceHolder1_txtMobile").bind('mouseenter', function (e) {
            var val = $(this).val();
            if (val != '0') {
                val = val.replace(/[^0-9]+/g, "");
                $(this).val(val);
            }
        });
    </script>
</asp:Content>

