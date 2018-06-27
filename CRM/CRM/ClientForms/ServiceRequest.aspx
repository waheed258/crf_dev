<%@ Page Title="" Language="C#" MasterPageFile="~/ClientForms/Layout.master" AutoEventWireup="true" CodeFile="ServiceRequest.aspx.cs" Inherits="ClientForms_ServiceRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show');
        }
        //function openBankModal() {
        //    $('#ContentPlaceHolder1_bankPopup').modal('show');
        //}
        //function openAddressModal() {
        //    $('#ContentPlaceHolder1_addressPopup').modal('show');
        //}
        //function openDeleteModal() {
        //    $('#delete').modal('show');
        //}
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#target").keyup(function () {
                if ($("[id *=target]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvServiceDetails]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvServiceDetails]").children
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


                    $("[id *=ContentPlaceHolder1_gvServiceDetails]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvServiceDetails]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
           
           
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="content-wrapper">

        <div class="content-header">
            <div class="header-title">
                <h1>Service Request</h1>
            </div>
        </div>
        <div class="content">
            <div style="text-align: center; margin-bottom: 10px;">
                <asp:Label ID="lblMessage" runat="server" Style="color: #006341; font-weight: bold; text-align: center"></asp:Label>
            </div>


            <div class="panel panel-bd">
                <div class="panel-heading">
                    <div class="panel-title">
                        <h5>Service Request Form</h5>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="col-sm-12">
                        <div class="form-group col-sm-2">
                            <label class="control-label">Services</label><span class="style1">*</span>
                        </div>
                        <div class="form-group col-sm-6">
                            <asp:DropDownList ID="ddlService" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvService" runat="server" ControlToValidate="ddlService" Display="Dynamic" ErrorMessage="Please select Services"
                                ValidationGroup="Service" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group col-sm-2">
                            <label class="control-label">Description</label><span class="style1">*</span>
                        </div>
                        <div class="form-group col-sm-6">
                            <asp:TextBox ID="txtDetails" TextMode="MultiLine" Height="80" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails" Display="Dynamic" ErrorMessage="Enter Details"
                                ValidationGroup="Service" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group col-sm-2">
                            <label class="control-label">Priority</label><span class="style1">*</span>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvPriority" runat="server" ControlToValidate="ddlPriority" Display="Dynamic" ErrorMessage="Select Priority"
                                ValidationGroup="Service" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group col-sm-2">
                            <label class="control-label">Upload Document</label>
                        </div>
                        <div class="form-group col-sm-4">
                            <asp:FileUpload ID="fuServiceDocument" runat="server"></asp:FileUpload>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="col-sm-4"></div>

                    <asp:Button ID="btnSubmitServiceRequest" runat="server" Text="Submit" ValidationGroup="Service" OnClick="btnSubmitServiceRequest_Click" CssClass="btn btn-primary"></asp:Button>
                   <%-- <asp:Button ID="btnUpdateSR" runat="server" Text="Update" ValidationGroup="Service" OnClick="btnUpdateSR_Click" CssClass="btn btn-primary"></asp:Button>--%>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click"></asp:Button>
                </div>

                <div class="panel panel-bd" id="divAddressDetails" runat="server">
                    <div class="panel-heading">
                        <div class="panel-title">
                            <h5>List of Service Request</h5>
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
                        <asp:GridView ID="gvServiceDetails" runat="server" Width="100%"
                            AutoGenerateColumns="False" DataKeyNames="ClientServiceID" CssClass="rounded-corners" OnRowDeleting="gvServiceDetails_RowDeleting"
                            EmptyDataText="There are no data records to display. Please add Service details."
                            BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100" OnRowEditing="gvServiceDetails_RowEditing" OnPageIndexChanging="gvServiceDetails_PageIndexChanging"
                            CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvServiceDetails_RowCommand">
                            <PagerStyle CssClass="pagination_grid" />
                            <Columns>


                                <asp:TemplateField HeaderText="S.No" HeaderStyle-CssClass="panel-heading" ItemStyle-CssClass="gradeC">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblClientServiceID" Text='<%#Eval("ClientServiceID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Client SAID">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ServiceID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblClientServiceIDFK" Text='<%#Eval("ClientService") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblClientService" Text='<%#Eval("ServiceName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDetailInformation" Text='<%#Eval("DetailInformation") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Priority">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPriority" Text='<%#Eval("PriorityName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="PriorityID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPriorityID" Text='<%#Eval("Priority") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Service Status" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblServiceStatus" Text='<%#Eval("ServiceStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                            CommandName="EditServices" ToolTip="Edit" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnAddressDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                            CommandName="Delete" ToolTip="Delete" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

            </div>
        </div>


        <!-- delete user Modal2 -->
        <%--<div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-hidden="true">
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
        </div>--%>


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
                                        <asp:Label ID="message" runat="server" class="control-label"/>
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

