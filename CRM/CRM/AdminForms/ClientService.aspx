<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="ClientService.aspx.cs" Inherits="AdminForms_ClientService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show');
        }
        function openDeleteModal() {
            $('#delete').modal('show');
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#target").keyup(function () {
                if ($("[id *=target]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvClientService]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvClientService]").children
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


                    $("[id *=ContentPlaceHolder1_gvClientService]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvClientService]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
        });
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
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="header-title">
                <h1>Client Service</h1>
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
                                <h5>Add Service</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12">

                                <asp:Label ID="lblMessage" runat="server"></asp:Label>

                            </div>
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <asp:Label ID="lblName" runat="server" Text="Service Name"></asp:Label><span class="style1">*</span>
                                    <asp:TextBox ID="txtServiceName" class="form-control" runat="server" TextMode="MultiLine" placeholder="Enter Service Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvServiceName" runat="server" ControlToValidate="txtServiceName" ForeColor="#d0582e"
                                        ErrorMessage="Please Enter Service Name" ValidationGroup="service" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="panel-footer">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-add" ValidationGroup="service" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-add" ValidationGroup="service" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger" OnClick="btnCancel_Click" />
                        </div>
                        <div class="panel panel-bd" id="ServiceList" runat="server">
                            <div class="panel-heading">
                                           <div class="panel-title">
                                               <h5>List of Services</h5>
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
                                <asp:GridView ID="gvClientService" runat="server" Width="100%"
                                    AutoGenerateColumns="False" DataKeyNames="ServiceID" CssClass="rounded-corners" OnPageIndexChanging="gvClientService_PageIndexChanging"
                                    EmptyDataText="There are no data records to display."
                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" OnRowEditing="gvClientService_RowEditing" OnRowDeleting="gvClientService_RowDeleting"
                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%; align-items: center" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvClientService_RowCommand">
                                    <PagerStyle CssClass="pagination_grid" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Service ID">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblServiceID" Text='<%#Eval("ServiceID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ServiceName">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblServiceName" Text='<%#Eval("ServiceName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                    CommandName="Edit" ToolTip="Edit" CommandArgument='<%#Eval("ServiceID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                    CommandName="Delete" ToolTip="Delete" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                    <HeaderStyle BackColor="#E8F1F3"></HeaderStyle>
                                    <PagerSettings Mode="NumericFirstLast" />
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
                     <h3> <asp:Label ID="lblTitle" runat="server" class="control-label"/></h3>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <div class="col-md-12 form-group user-form-group">
                                        <asp:Label ID="message" runat="server" class="control-label" />
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

