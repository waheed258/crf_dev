<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="AdminForms_UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show');
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <div class="header-title">
                        <h1>Advisor Profile</h1>
                    </div>
                </section>
                <!-- Main content -->
                <section class="content">
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
                                         <div class="form-group col-sm-3">
                                            <label>SAID</label>
                                            <asp:TextBox ID="txtSAId" class="form-control" runat="server" placeholder="Enter SAID" MaxLength="13" ReadOnly="true"></asp:TextBox>          
                                              <asp:RegularExpressionValidator ID="revtxtSAId" runat="server" ErrorMessage="Please enter 13 digits" ValidationExpression="[0-9]{13}" Display="Dynamic"
                                        ControlToValidate="txtSAId" ForeColor="#f31010" ValidationGroup="Save"></asp:RegularExpressionValidator>
                                        </div>
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
                                            <asp:TextBox ID="txtMobileNum" class="form-control" runat="server" placeholder="Enter Mobile Number" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvMobileNum" runat="server" ControlToValidate="txtMobileNum" ForeColor="#d0582e"
                                                ErrorMessage="Please Enter Mobile" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revMobileNum" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                ControlToValidate="txtMobileNum" ForeColor="#d0582e" ValidationGroup="Advisor"></asp:RegularExpressionValidator>
                                        </div>
                                      
                                    </div>

                                    <div class="col-sm-12">
                                          <div class="form-group col-sm-3">
                                            <label>Phone</label>
                                            <asp:TextBox ID="txtPhoneNum" class="form-control" runat="server" placeholder="Enter Phone Number" MaxLength="10"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="revPhoneNum" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                ControlToValidate="txtPhoneNum" ForeColor="#d0582e" ValidationGroup="Advisor"></asp:RegularExpressionValidator>
                                        </div>
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
                                            <asp:RequiredFieldValidator ID="rfvLoginId" runat="server" ControlToValidate="txtLoginId" ForeColor="#d0582e"
                                                ErrorMessage="Please Enter Login ID" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group col-sm-3">
                                            <label>Password</label>
                                            <asp:TextBox ID="txtPassword"  class="form-control" runat="server" placeholder="Enter Password" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ForeColor="#d0582e"
                                                ErrorMessage="Please Enter Password" ValidationGroup="Advisor" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                       
                                    </div>

                                    <div class="col-sm-12">
                                         <div class="form-group col-sm-3">
                                            <label>Designation</label>
                                            <asp:DropDownList ID="ddlDesignation" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvDesignation" runat="server" ControlToValidate="ddlDesignation" ForeColor="#d0582e"
                                                ErrorMessage="Please Select Designation" ValidationGroup="Advisor" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
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
                                        
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="form-group col-sm-3">
                                            <label>Role</label>
                                            <asp:DropDownList ID="ddlRole" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvRole" runat="server" ControlToValidate="ddlRole" ForeColor="#d0582e"
                                                ErrorMessage="Please Select Role" ValidationGroup="Advisor" InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                         <div class="form-group col-sm-3">
                                            <label>Upload Photo</label>
                                            <asp:FileUpload ID="fuImageUpload" runat="server"/>
                                            <asp:HiddenField ID="hfImage" runat="server" />
                                             
                                                
                                        </div>
                                        
                                    </div>
                                </div>
                                <div class="panel-footer">
                                    <div class="col-sm-5"></div>
                                    <asp:button id="btnUpdate" runat="server" text="Update" class="btn btn-add" validationgroup="advisor" onclick="btnUpdate_Click" />
                                    <asp:button id="btncancel" runat="server" text="cancel" class="btn btn-danger" onclick="btncancel_Click" />
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

