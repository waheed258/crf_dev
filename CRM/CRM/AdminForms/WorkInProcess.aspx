<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="WorkInProcess.aspx.cs" Inherits="AdminForms_WorkInProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js"></script>
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
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show');
        }

    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#target").keyup(function () {
                if ($("[id *=target]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvWorkInProcess]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvWorkInProcess]").children
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


                    $("[id *=ContentPlaceHolder1_gvWorkInProcess]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvWorkInProcess]").children('tbody').
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
        <section class="content-header">
            <div class="header-title">
                <h1>Under Process Service Requests</h1>
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
                                <h5>Under Process Service Requests List</h5>
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
                            <div class="table-responsive">
                                <asp:GridView ID="gvWorkInProcess" runat="server" Width="100%"
                                    AutoGenerateColumns="False" DataKeyNames="ClientServiceID" CssClass="rounded-corners"
                                    EmptyDataText="There are no data records to display."
                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100"
                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvWorkInProcess_RowCommand" OnPageIndexChanging="gvWorkInProcess_PageIndexChanging">
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
                                                <asp:Label runat="server" ID="lblClientName" Text='<%#Eval("ClientName") %>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnFollowUp" ImageUrl="~/assets/dist/img/Trustee.jpg" data-toggle="modal" data-target="#FollowUp" runat="server" Width="23px" Height="23px"
                                                    CommandName="FollowUp" ToolTip="FollowUp" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
                                                <asp:ImageButton ID="btnGenerateInvoice" ImageUrl="~/assets/dist/img/invoice.jpg" data-toggle="modal" data-target="#GenerateInvoice" runat="server" Width="23px" Height="23px"
                                                    CommandName="GenerateInvoice" ToolTip="Generate Invoice" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />                                              
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

        <section class="content" id="FollowUpSection" runat="server">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>FollowUps</h5>
                            </div>
                        </div>
                        <div class="panel-body" id="Tabs">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#tab1" data-toggle="tab">Details</a></li>
                                <li><a href="#tab2" data-toggle="tab">Updates</a></li>

                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="tab1">
                                    <div class="panel-body">
                                        <div class="col-sm-12" style="text-align: center">
                                            <asp:Label ID="lblFollowmsg" runat="server" class="control-label" Style="color: green"></asp:Label>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="form-group col-sm-3">
                                                <label>Service Request</label>
                                                <asp:TextBox ID="txtServiceRequest" runat="server" class="form-control" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-sm-3">
                                                <label>SAID</label>
                                                <asp:TextBox ID="txtClientSAID" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-sm-3">
                                                <label>Client Name</label>
                                                <asp:TextBox ID="txtClientName" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-sm-3">
                                                <label>Assigned To</label>
                                                <asp:TextBox ID="txtAssignedTo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-sm-12">
                                            <div class="form-group col-sm-3">
                                                <label>Activity Type</label>
                                                <asp:DropDownList ID="dropActivityType" runat="server" class="form-control" AppendDataBoundItems="true">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvdropActivityType" runat="server" ControlToValidate="dropActivityType" Display="Dynamic"
                                                    ErrorMessage="Select Activity Type"
                                                    ValidationGroup="Follow" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="form-group col-sm-3">
                                                <h5><u>Follow Up Date & Time</u></h5>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="form-group col-sm-3">
                                                <label>Start Date & Time</label>
                                                <asp:TextBox ID="txtFollowDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFollowDate" runat="server" ControlToValidate="txtFollowDate" Display="Dynamic"
                                                    ErrorMessage="Select Start Date"
                                                    ValidationGroup="Follow" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <br />
                                            <div class="form-group col-sm-3">
                                                <asp:TextBox ID="txtFollowTime" TextMode="Time" runat="server" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFollowTime" runat="server" ControlToValidate="txtFollowTime" Display="Dynamic"
                                                    ErrorMessage="Enter Start Time"
                                                    ValidationGroup="Follow" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="form-group col-sm-3">
                                                <label>Due Date & Time</label>
                                                <asp:TextBox ID="txtDueDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtDueDate" runat="server" ControlToValidate="txtDueDate" Display="Dynamic"
                                                    ErrorMessage="Select Due Date"
                                                    ValidationGroup="Follow" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <br />
                                            <div class="form-group col-sm-3">
                                                <asp:TextBox ID="txtDueTime" TextMode="Time" runat="server" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvDueTime" runat="server" ControlToValidate="txtDueTime" Display="Dynamic"
                                                    ErrorMessage="Enter Due Time"
                                                    ValidationGroup="Follow" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="panel-footer">
                                        <div class="col-sm-5"></div>
                                        <asp:Button ID="FollowUpdate" runat="server" Text="Submit" class="btn btn-add btn-sm" ValidationGroup="Follow" OnClick="FollowUpdate_Click" />
                                        <asp:Button ID="FollowClose" runat="server" class="btn btn-danger btn-sm" Text="Back to List" OnClick="FollowClose_Click" />
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tab2">
                                    <div class="panel-body">
                                        <div class="table-responsive">
                                            <asp:GridView ID="gdvUpdatesList" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="ClientServiceID" CssClass="rounded-corners"
                                                EmptyDataText="There are no data records to display."
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100"
                                                CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Assigned To">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAssignedTo" Text='<%#Eval("AssignedTo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="FollowUpDate">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblFollowUpDate" Text='<%#Eval("FollowUpDates") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="FollowUpTime">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblFollowUpTime" Text='<%#Eval("FollowUpTime") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client ServiceID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblClientServiceID" Text='<%#Eval("ClientServiceID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="panel-footer">
                                        <div class="col-sm-5"></div>
                                        <asp:Button ID="btnFollowListCancel" runat="server" class="btn btn-danger btn-sm" Text="Back to List" OnClick="btnFollowListCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
        </section>

        <section class="content" id="InvoiceSection" runat="server">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Advisor List</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12" style="text-align: center">
                                <asp:Label ID="lblmessage" runat="server" class="control-label" Style="color: green"></asp:Label>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Description</label>
                                    <asp:TextBox ID="txtDescription" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" Display="Dynamic"
                                        ErrorMessage="Enter Description"
                                        ValidationGroup="Invoice" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                  <div class="form-group col-sm-3">
                                    <label>Amount</label>
                                    <asp:TextBox ID="txtAmount" runat="server" class="form-control"></asp:TextBox>
                                      <asp:CheckBox ID="chkVatInclusive" runat="server" Text="Inclusive Of Vat" AutoPostBack="true" OnCheckedChanged="chkVatInclusive_CheckedChanged" />
                                      <asp:Label ID="lblvat" runat="server">+ 15%</asp:Label>
                                    <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ControlToValidate="txtAmount" Display="Dynamic"
                                        ErrorMessage="Enter Amount"
                                        ValidationGroup="Invoice" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="btnInvoiceSubmit" runat="server" Text="Submit" CssClass="btn btn-add btn-sm" ValidationGroup="Invoice" OnClick="btnInvoiceSubmit_Click" />
                            <asp:Button ID="btnInvoiceCancel" runat="server" CssClass="btn btn-danger btn-sm" Text="Back to List" OnClick="btnInvoiceCancel_Click" OnClientClick="window.document.forms[0].target='_self';" />
                            <asp:Button ID="btnPDF" runat="server" CssClass="btn btn-primary btn-sm" Text="PDF" OnClick="btnPDF_Click" Enabled="false" OnClientClick="window.document.forms[0].target='_blank';"/>
                                                   
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

