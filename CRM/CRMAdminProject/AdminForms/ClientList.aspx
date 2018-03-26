<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="ClientList.aspx.cs" Inherits="AdminForms_ClientList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">

        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show');
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
        <section class="content-header">
            <div class="header-title">
                <h1>Registered Clients</h1>
            </div>
        </section>
        <!-- Main content -->
        <section class="content" id="sectionClientList" runat="server">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Clients List</h5>
                            </div>
                        </div>

                        <div class="panel-body">
                            <asp:GridView ID="gvClientsList" runat="server" Width="100%"
                                AutoGenerateColumns="False" DataKeyNames="ClientRegistartionID" CssClass="rounded-corners"
                                EmptyDataText="There are no data records to display."
                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100" OnRowEditing="gvClientsList_RowEditing"
                                CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvClientsList_RowCommand">
                                <Columns>
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
                                    <asp:TemplateField HeaderText="Mobile Number">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblMobileNumber" Text='<%#Eval("MobileNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblStatus" Text='<%#Eval("ClientStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CStatus" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCStatus" Text='<%#Eval("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CompanyName" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCompanyName" Text='<%#Eval("CompanyName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CompanyRegNo" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCompanyRegNo" Text='<%#Eval("CompanyRegNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TrustName" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTrustName" Text='<%#Eval("TrustName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TrustRegNo" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTrustRegNo" Text='<%#Eval("TrustRegNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Title" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTitle" Text='<%#Eval("Title") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RegID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblRegID" Text='<%#Eval("ClientRegistartionID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" ImageUrl="~/assets/dist/img/edit.png" data-toggle="modal" data-target="#Edit" runat="server" Width="23px" Height="23px"
                                                CommandName="Edit" ToolTip="Edit" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
                                            <asp:ImageButton ID="btnValidate" ImageUrl="~/assets/dist/img/validate1.png" data-toggle="modal" data-target="#Validate" runat="server" Width="23px" Height="23px"
                                                CommandName="Validate" ToolTip="Validate" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
                                            <asp:ImageButton ID="btnFeedback" ImageUrl="~/assets/dist/img/feedback.jpg" data-toggle="modal" data-target="#Feedback" runat="server" Width="23px" Height="23px"
                                                CommandName="Feedback" ToolTip="Feedback" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
                                            <asp:ImageButton ID="btnStatus" ImageUrl="~/assets/dist/img/Status.png" data-toggle="modal" data-target="#Status" runat="server" Width="23px" Height="23px"
                                                CommandName="Status" ToolTip="Status" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </section>


        <section class="content" id="editSection" runat="server">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Update Client</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Title</label>
                                    <asp:DropDownList ID="ddlTitle" runat="server" class="form-control">
                                        <asp:ListItem Text="--Select Title--" Value="-1" />
                                        <asp:ListItem Text="Mr" Value="-1" />
                                        <asp:ListItem Text="Miss" Value="-1" />
                                        <asp:ListItem Text="Ms" Value="-1" />
                                        <asp:ListItem Text="Mrs" Value="-1" />
                                        <asp:ListItem Text="Dr" Value="-1" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="Please select Title" Display="Dynamic"
                                        ControlToValidate="ddlTitle" ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>First Name</label>
                                    <asp:TextBox ID="txtFirstName" runat="server" class="form-control" placeholder="Enter Given Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Please Enter First Name" ControlToValidate="txtFirstName" Display="Dynamic"
                                        ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Last Name</label>
                                    <asp:TextBox ID="txtLastName" runat="server" class="form-control" placeholder="Enter Sur Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Please Enter Last Name" ControlToValidate="txtLastName" Display="Dynamic"
                                        ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>SAID</label>
                                    <asp:TextBox ID="txtSAID" runat="server" class="form-control" placeholder="SA ID" MaxLength="13"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSAID" runat="server" ErrorMessage="Please Enter Last Name" ControlToValidate="txtSAID" Display="Dynamic"
                                        ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Mobile</label>
                                    <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="Enter Mobile" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ErrorMessage="Please Enter Mobile Number" ControlToValidate="txtMobile" Display="Dynamic" ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rgvMobile" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                        ControlToValidate="txtMobile" ForeColor="#d0582e" ValidationGroup="Client"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Enter Email" TextMode="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFV_Email" runat="server" ErrorMessage="Please Enter EmailID" ControlToValidate="txtEmail" ValidationGroup="Client" Display="Dynamic" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmailId" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please check Email Format"
                                        ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Client">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Company</label>
                                    <asp:TextBox ID="txtCompany" runat="server" class="form-control" placeholder="Company"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Company Registration</label>
                                    <asp:TextBox ID="txtCompanyRegNo" runat="server" class="form-control" placeholder="Registration No"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Trust</label>
                                    <asp:TextBox ID="txtTrust" runat="server" class="form-control" placeholder="Trust"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Trust Registration</label>
                                    <asp:TextBox ID="txtTrustRegNo" runat="server" class="form-control" placeholder="Registration No"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="Button_Update" runat="server" Text="Update" class="btn btn-add btn-sm" ValidationGroup="Client" OnClick="Button_Update_Click" />
                            <asp:Button ID="Button_Close" runat="server" class="btn btn-danger btn-sm" Text="Back to List" OnClick="Button_Close_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="content" id="statusSection" runat="server">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Update Status</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Title</label>
                                    <asp:DropDownList ID="ddlClientStatus" runat="server" class="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvClientStatus" runat="server" ErrorMessage="Please select Status" Display="Dynamic"
                                        ControlToValidate="ddlClientStatus" ValidationGroup="Client" ForeColor="#d0582e" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="btnStatusSubmit" runat="server" Text="Update" class="btn btn-add btn-sm" ValidationGroup="Client" OnClick="btnStatusSubmit_Click" />
                            <asp:Button ID="btnStatusCancel" runat="server" class="btn btn-danger btn-sm" Text="Back to List" OnClick="btnStatusCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>

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


    </div>
</asp:Content>

