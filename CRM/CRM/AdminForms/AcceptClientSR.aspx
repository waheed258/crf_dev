<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="AcceptClientSR.aspx.cs" Inherits="AdminForms_AcceptClientSR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#target").keyup(function () {
                if ($("[id *=target]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvClientSR]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvClientSR]").children
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


                    $("[id *=ContentPlaceHolder1_gvClientSR]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvClientSR]").children('tbody').
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
    </style>
    <script type="text/javascript">
        function openActiveModal() {
            $('#Active').modal('show');
        }
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
            <div class="header-title">
                <h1>Client Service Requests</h1>
            </div>
        </section>
        <!-- Main content -->
        <asp:HiddenField ID="TabName" runat="server" />
        <section class="content" id="sectionRequestList" runat="server">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Client Service Requests List</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row" id="search" runat="server">
                                <div class="col-lg-12">
                                    <div class="col-lg-1 form-group">
                                        <asp:DropDownList ID="DropPage" runat="server"
                                            OnSelectedIndexChanged="DropPage_SelectedIndexChanged" CssClass="form-control"
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
                            <div class="table-responsive">
                                <asp:GridView ID="gvClientSR" runat="server" Width="100%"
                                    AutoGenerateColumns="False" DataKeyNames="ClientServiceID" CssClass="rounded-corners"
                                    EmptyDataText="There are no data records to display."
                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100" OnRowEditing="gvClientSR_RowEditing" OnPageIndexChanging="gvClientSR_PageIndexChanging"
                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvClientSR_RowCommand">
                                    <PagerStyle CssClass="pagination_grid" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client ServiceID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblClientServiceID" Text='<%#Eval("ClientServiceID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SRNO">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblSRNO" Text='<%#Eval("SRNO") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SAID">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Service Name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblServiceName" Text='<%#Eval("ServiceName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Detail Information">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblDetailInformation" Text='<%#Eval("DetailInformation") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Priority">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPriority" Text='<%#Eval("PriorityName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client Name" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblName" Text='<%#Eval("ClientName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Allocated To" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblAllocatedTo" Text='<%#Eval("AdvisorName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AdvisorID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblAdvisorID" Text='<%#Eval("AdvisorID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AdvisorName" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblAdvisorName" Text='<%#Eval("AdvisorName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action/Accept SR">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnAllocatedTo" ImageUrl="~/assets/dist/img/settler.png" data-toggle="modal" data-target="#AllocatedTo" runat="server" Width="23px" Height="23px"
                                                    CommandName="AllocatedTo" ToolTip="Allocate" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />                                             
                                                <asp:ImageButton ID="imgAccept" ImageUrl="~/assets/dist/img/Accept.jpg" data-toggle="modal" data-target="#Accept" runat="server" Width="23px" Height="23px"
                                                    CommandName="Validate" ToolTip="AcceptSR" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
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

        <section class="content" id="AdvisorSection" runat="server">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Allocate Advisor</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12" style="text-align: center">
                                <asp:Label ID="lblmessage" runat="server" class="control-label" Style="color: green"></asp:Label>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Select Advisor</label>
                                    <asp:DropDownList ID="ddlAdvisors" runat="server" class="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvAdvisors" runat="server" ErrorMessage="Please select Advisor" Display="Dynamic"
                                        ControlToValidate="ddlAdvisors" ValidationGroup="Advisor" ForeColor="#d0582e" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="btnAdvisorSubmit" runat="server" Text="Submit" class="btn btn-add btn-sm" ValidationGroup="Advisor" OnClick="btnAdvisorSubmit_Click" />
                            <asp:Button ID="btnAdvisorCancel" runat="server" class="btn btn-danger btn-sm" Text="Back to List" OnClick="btnAdvisorCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>

        

        <!-- /.content -->

        <div class="modal fade" id="Active" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header modal-header-primary">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h3><i class="fa fa-home m-r-5"></i>Activate</h3>
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
                                        <asp:Label ID="message1" runat="server" class="control-label" Style="color: red" />

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
    <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "tab1";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });
    </script>
</asp:Content>

