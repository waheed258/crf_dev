<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="LocationMaster.aspx.cs" Inherits="AdminForms_LocationMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script src="../Scripts/jquery-1.10.2.min.js"></script>
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
    <script type="text/javascript">
        $(document).ready(function (event) {
            $("#ContentPlaceHolder1_txtMobileNum","#ContentPlaceHolder1_txtTelNum").bind('keypress', function (e) {
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
            $("#ContentPlaceHolder1_txtMobileNum", "#ContentPlaceHolder1_txtTelNum").bind('mouseenter', function (e) {
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
            $('#ContentPlaceHolder1_Success').modal('show');
        }
        function openDeleteModal() {
            $('#delete').modal('show', { backdrop: 'static' });
        }

    </script>
     <script type="text/javascript">
         $(document).ready(function () {
             $("#target").keyup(function () {
                 if ($("[id *=target]").val() != "") {
                     $("[id *=ContentPlaceHolder1_gvLocation]").children
                     ('tbody').children('tr').each(function () {
                         $(this).show();
                     });
                     $("[id *=ContentPlaceHolder1_gvLocation]").children
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


                     $("[id *=ContentPlaceHolder1_gvLocation]").children('tbody').
                             children('tr').each(function (index) {
                                 if (index == 0)
                                     $(this).show();
                             });
                 }
                 else {
                     $("[id *=ContentPlaceHolder1_gvLocation]").children('tbody').
                             children('tr').each(function () {
                                 $(this).show();
                             });
                 }
             });
         });
       </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <div class="header-title">
                        <h1>Location</h1>
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
                                        <h5>Add Location</h5>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div class="col-sm-12">
                                        <div class="form-group col-sm-3">
                                            <label>Location Name</label>
                                            <asp:TextBox ID="txtLocationName" class="form-control" runat="server" placeholder="Enter Location Name" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvLocationName" runat="server" ControlToValidate="txtLocationName" ForeColor="#d0582e"
                                                ErrorMessage="Please Enter Location Name" ValidationGroup="Location" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group col-sm-3">
                                            <label>Mobile Number</label>
                                            <asp:TextBox ID="txtMobileNum" class="form-control" runat="server" placeholder="Enter Mobile Number" MaxLength="10"></asp:TextBox>                                         
                                            <asp:RegularExpressionValidator ID="revMobileNum" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                ControlToValidate="txtMobileNum" ForeColor="#d0582e" ValidationGroup="Location"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="form-group col-sm-3">
                                            <label>Telephone Number</label>
                                            <asp:TextBox ID="txtTelNum" class="form-control" runat="server" placeholder="Enter Telephone Number" MaxLength="10"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="revTelNum" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                ControlToValidate="txtTelNum" ForeColor="#d0582e" ValidationGroup="Location"></asp:RegularExpressionValidator>
                                        </div>
                                         <div class="form-group col-sm-3">
                                            <label>Primary Email</label>
                                            <asp:TextBox ID="txtPrimaryEmail" class="form-control" runat="server" placeholder="Enter Primary Email" MaxLength="75"></asp:TextBox>                                          
                                            <asp:RegularExpressionValidator ID="revPrimaryEmail" runat="server" ForeColor="#d0582e" Display="Dynamic" ErrorMessage="Please check Email Format"
                                                ControlToValidate="txtPrimaryEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Location">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="col-sm-12">
                                        <div class="form-group col-sm-3">
                                            <label>Secondary Email</label>
                                            <asp:TextBox ID="txtSecondaryEmail" class="form-control" runat="server" placeholder="Enter Secondary Email" MaxLength="75"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="revSecondaryEmail" runat="server" ForeColor="#d0582e" Display="Dynamic" ErrorMessage="Please check Email Format"
                                                ControlToValidate="txtSecondaryEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Location">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="form-group col-sm-3">
                                            <label>Vat Registration</label>
                                            <asp:TextBox ID="txtVatReg" class="form-control" runat="server" placeholder="Enter Vat Registration" MaxLength="50"></asp:TextBox>                                        
                                        </div>
                                        <div class="form-group col-sm-3">
                                            <label>Vat %</label>
                                            <asp:TextBox ID="txtVatPerc" class="form-control" runat="server" placeholder="Enter Vat %" MaxLength="50"></asp:TextBox>
                                        </div>
                                         <div class="form-group col-sm-3">
                                                    <label>Plot No</label>
                                                    <asp:TextBox ID="txtPlotNo" CssClass="form-control" runat="server" MaxLength="10" placeholder="Enter Plot No" ></asp:TextBox>                                                   
                                          </div>
                                    </div>

                                    <div class="col-sm-12">
                                        <div class="form-group col-sm-3">
                                            <label>Building Name</label>
                                             <asp:TextBox ID="txtBuildingName" CssClass="form-control" runat="server" MaxLength="50" placeholder="Enter Building Name"></asp:TextBox>   
                                        </div>
                                         <div class="form-group col-sm-3">
                                            <label>Floor No</label>
                                             <asp:TextBox ID="txtFloorNo" CssClass="form-control" runat="server" MaxLength="10" placeholder="Enter Floor No"></asp:TextBox>   
                                        </div>
                                        <div class="form-group col-sm-3">
                                            <label>Flat No</label>
                                             <asp:TextBox ID="txtFlatNo" CssClass="form-control" runat="server" MaxLength="10" placeholder="Enter Flat No"></asp:TextBox>   
                                        </div>
                                         <div class="form-group col-sm-3">
                                            <label>Road Name</label>
                                             <asp:TextBox ID="txtRoadName" CssClass="form-control" runat="server" MaxLength="50" placeholder="Enter Road Name"></asp:TextBox>   
                                        </div>
                                         
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="form-group col-sm-3">
                                            <label>Road No</label>
                                             <asp:TextBox ID="txtRoadNum" CssClass="form-control" runat="server" MaxLength="10" placeholder="Enter Road No"></asp:TextBox>   
                                        </div>
                                         <div class="form-group col-sm-3">
                                            <label>Suburb Name</label>
                                             <asp:TextBox ID="txtSuburbName" CssClass="form-control" runat="server" MaxLength="50" placeholder="Enter Suburb Name"></asp:TextBox>   
                                        </div>                                        
                                         <div class="form-group col-sm-3">
                                            <label>Postal Code</label>
                                             <asp:TextBox ID="txtPostalCode" CssClass="form-control" runat="server" MaxLength="10" placeholder="Enter Postal Code"></asp:TextBox>   
                                        </div>
                                         <div class="form-group col-sm-3">
                                            <label>City</label>
                                              <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList> 
                                        </div>
                                        </div>
                                        
                                    <div class="col-sm-12">
                                         <div class="form-group col-sm-3">
                                            <label>Province</label>
                                              <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList> 
                                        </div>
                                        <div class="form-group col-sm-3">
                                            <label>Country</label>
                                              <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList> 
                                        </div>
                                    </div>
                                </div>
                                <div class="panel-footer">
                                    <div class="col-sm-5"></div>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-add" ValidationGroup="Location" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-add" ValidationGroup="Location" OnClick="btnUpdate_Click" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger" OnClick="btnCancel_Click" />
                                </div>

                                <div class="panel panel-bd" id="ChildList" runat="server">
                                        <div class="panel-heading">
                                            <div class="panel-title">
                                                <h5>List of Locations</h5>
                                            </div>
                                        </div>
                                        <div class="row"  id="search" runat="server">
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
                                                   <input id="target" type="text" class="form-control" placeholder="Text To Search"/>
                                                </div>
                                             
                                            </div>
                                        </div>
                                        <div class="panel-body" style="margin-top: 10px">
                                          
                                            <asp:GridView ID="gvLocation" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="LocationID" CssClass="rounded-corners"
                                                EmptyDataText="There are no data records to display."
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" OnRowEditing="gvLocation_RowEditing" OnRowDeleting="gvLocation_RowDeleting"
                                                CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvLocation_RowCommand" OnPageIndexChanging="gvLocation_PageIndexChanging" >
                                                <PagerStyle CssClass="pagination_grid" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Location ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblLocationID" Text='<%#Eval("LocationID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Location Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblLocationName" Text='<%#Eval("LocationName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="MobileNum">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblMobileNum" Text='<%#Eval("MobileNum") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Telephone Num" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblTelephoneNum" Text='<%#Eval("TelephoneNum") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Primary Email">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblPrimaryEmail" Text='<%#Eval("PrimaryEmail") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SecondaryEmail">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSecondaryEmail" Text='<%#Eval("SecondaryEmail") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="VatRegistration" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblVatRegistration" Text='<%#Eval("VatRegistration") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="VatPercentage" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblVatPercentage" Text='<%#Eval("VatPercentage") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
 
                                                    <asp:TemplateField HeaderText="Plot No" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblPlotNo" Text='<%#Eval("PlotNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Building Name" Visible="false">
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
                                                     <asp:TemplateField HeaderText="Road No" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblRoadNo" Text='<%#Eval("RoadNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Suburb Name" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSuburbName" Text='<%#Eval("SuburbName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="City" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCity" Text='<%#Eval("City") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Postal Code" Visible="false">
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
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                CommandName="Edit" CommandArgument='<%#Eval("LocationID") %>' ToolTip="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                CommandName="Delete" ToolTip="Delte" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   
                                                </Columns>
                                            </asp:GridView>
                                        </div>
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

