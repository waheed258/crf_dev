﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="AdvisorList.aspx.cs" Inherits="AdminForms_AdvisorList" %>

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
                <h1>All Advisors</h1>            
            </div>
        </section>
        <!-- Main content -->
        <section class="content" id="sectionAdvisorList" runat="server">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Advisor List</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gvAdvisor" runat="server" Width="100%"
                                AutoGenerateColumns="False" DataKeyNames="AdvisorID" CssClass="rounded-corners"
                                EmptyDataText="There are no data records to display."
                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100" OnRowEditing="gvAdvisor_RowEditing"
                                CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3">
                                <Columns>
                                    <asp:TemplateField HeaderText="Advisor ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblAdvisorID" Text='<%#Eval("AdvisorID") %>'></asp:Label>
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
                                    <asp:TemplateField HeaderText="Mobile">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblMobile" Text='<%#Eval("Mobile") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email ID">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblEmailID" Text='<%#Eval("EmailID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblDesignation" Text='<%#Eval("AdvisorDesignation") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblDesig" Text='<%#Eval("Designation") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LoginID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblLoginID" Text='<%#Eval("LoginId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Password" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblPassword" Text='<%#Eval("Password") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblBranch" Text='<%#Eval("Branch") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AType" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblAType" Text='<%#Eval("AdvisorType") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblAStatus" Text='<%#Eval("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Role" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblRole" Text='<%#Eval("AdvisorRole") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit.png"
                                                CommandName="Edit" ToolTip="Edit" />
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
                                <h5>Update Advisor</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12">
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>First Name</label>
                                    <asp:TextBox ID="txtFirstName" class="form-control" runat="server" placeholder="Enter First Name" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter First Name" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Last Name</label>
                                    <asp:TextBox ID="txtLastName" class="form-control" runat="server" placeholder="Enter Last Name" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Last Name" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Mobile</label>
                                    <asp:TextBox ID="txtMobileNum" class="form-control" runat="server" placeholder="Enter Mobile Number" MaxLength="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMobileNum" runat="server" ControlToValidate="txtMobileNum" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Mobile" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMobileNum" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                        ControlToValidate="txtMobileNum" ForeColor="#d0582e" ValidationGroup="Advisor"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Phone</label>
                                    <asp:TextBox ID="txtPhoneNum" class="form-control" runat="server" placeholder="Enter Phone Number" MaxLength="15"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revPhoneNum" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                        ControlToValidate="txtPhoneNum" ForeColor="#d0582e" ValidationGroup="Advisor"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmailId" class="form-control" runat="server" placeholder="Enter EmailId" MaxLength="75"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtEmailId" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Email" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmailId" runat="server" ForeColor="#d0582e" Display="Dynamic" ErrorMessage="Please check Email Format"
                                        ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Advisor">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Login ID</label>
                                    <asp:TextBox ID="txtLoginId" class="form-control" runat="server" placeholder="Enter LoginId" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="rfvLoginId" runat="server" ControlToValidate="txtLoginId" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Login ID" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Password</label>
                                    <asp:TextBox ID="txtPassword" class="form-control" runat="server" placeholder="Enter Password" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Password" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <%--   <div class="form-group col-sm-3">
                                    <label>Confirm Password</label>
                                    <asp:TextBox ID="txtConfirmPassword" TextMode="Password" class="form-control" runat="server" placeholder="Enter Confirm Password" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtPassword" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Password" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                        ControlToCompare="txtPassword" Operator="Equal" Text="Should match with Password"
                                        ErrorMessage="Should match with Password" class="validationred"
                                        ValidationGroup="Advisor" Display="Dynamic" ForeColor="#d0582e"></asp:CompareValidator>
                                </div>--%>
                                <div class="form-group col-sm-3">
                                    <label>Designation</label>
                                    <asp:DropDownList ID="ddlDesignation" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvDesignation" runat="server" ControlToValidate="ddlDesignation" ForeColor="#d0582e"
                                        ErrorMessage="Please Select Designation" ValidationGroup="Advisor" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Branch</label>
                                    <asp:DropDownList ID="ddlBranch" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvBranch" runat="server" ControlToValidate="ddlBranch" ForeColor="#d0582e"
                                        ErrorMessage="Please Select Branch" ValidationGroup="Advisor" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Advisor Type</label>
                                    <asp:DropDownList ID="ddlAdvisorType" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvAdvisorType" runat="server" ControlToValidate="ddlAdvisorType" ForeColor="#d0582e"
                                        ErrorMessage="Please Select Advisor Type" ValidationGroup="Advisor" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Status</label>
                                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlStatus" ForeColor="#d0582e"
                                        ErrorMessage="Please Select Status" ValidationGroup="Advisor" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Role</label>
                                    <asp:DropDownList ID="ddlRole" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvRole" runat="server" ControlToValidate="ddlRole" ForeColor="#d0582e"
                                        ErrorMessage="Please Select Role" ValidationGroup="Advisor" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="btnSubmit" runat="server" Text="Update" class="btn btn-add" ValidationGroup="Advisor" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Back to List" OnClick="btnCancel_Click" class="btn btn-danger" />
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
                                        <label class="control-label" style="color: green">Advisor Updated Successfully!</label>
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
