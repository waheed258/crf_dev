<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="InvoicePayment.aspx.cs" Inherits="AdminForms_InvoicePayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#target").keyup(function () {
                if ($("[id *=target]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvInvoice]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvInvoice]").children
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


                    $("[id *=ContentPlaceHolder1_gvInvoice]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvInvoice]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
        });

    </script>
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
        .style1 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="header-title">
                <h1>Invoice Payment</h1>
            </div>
        </div>
        <!-- Main content -->
        <div class="content">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Invoice Payment</h5>
                            </div>
                        </div>
                        <div class="panel-body" id="Tabs">
                            <div class="panel-body">
                                <div class="col-md-12">
                                    <div class="form-group col-sm-3">
                                        <label>Total Amount</label>
                                        <asp:TextBox ID="txtTotalAmount" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-sm-3">
                                        <label>Received Amount</label>
                                        <asp:TextBox ID="txtReceivedAmount" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-sm-3">
                                        <label>Due Amount</label>
                                        <asp:TextBox ID="txtDueAmount" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-sm-3">
                                        <label>Next FollowUp Date</label><span class="style1">*</span>
                                        <asp:TextBox ID="txtNextFollowUpDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="rfvNextFollowUpDate" runat="server" ControlToValidate="txtNextFollowUpDate" ForeColor="red"
                                            ErrorMessage="Please Enter Next FollowUp Date" ValidationGroup="Invoice" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group col-sm-3">
                                        <label>Payment Received</label><span class="style1">*</span>
                                        <asp:TextBox ID="txtPaymentReceived" class="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPaymentReceived" runat="server" ControlToValidate="txtPaymentReceived" ForeColor="red"
                                            ErrorMessage="Please Enter Payment Received" ValidationGroup="Invoice" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-sm-3">
                                        <label>Payment Mode</label><span class="style1">*</span>
                                        <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                            <asp:ListItem Value="Credit/Debit Card">Credit/Debit Card</asp:ListItem>
                                            <asp:ListItem Value="EFT">EFT</asp:ListItem>
                                            <asp:ListItem Value="CHQ">CHQ</asp:ListItem>
                                            <asp:ListItem Value="DD">DD</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvPaymentMode" runat="server" ControlToValidate="ddlPaymentMode" ForeColor="red" InitialValue="-1"
                                            ErrorMessage="Please Select Payment Mode" ValidationGroup="Invoice" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-sm-3">
                                        <label>Notes</label>
                                        <asp:TextBox ID="txtNotes" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                               
                            </div>
                            <div class="panel-footer" style="border-top: 0px !important;">
                                <div class="col-sm-5"></div>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Invoice" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnBack" runat="server" Text="Back To List" CssClass="btn btn-danger" OnClick="btnBack_Click" />
                            </div>
                            <div class="panel panel-bd" id="invoicelist" runat="server">
                                <div class="panel-heading">
                                    <div class="panel-title">
                                        <h5>Invoice List</h5>
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
                                        <asp:GridView ID="gvInvoice" runat="server" Width="100%"
                                            AutoGenerateColumns="False" DataKeyNames="InvoiceNum" CssClass="rounded-corners" OnPageIndexChanging="gvInvoice_PageIndexChanging"
                                            EmptyDataText="There are no data records to display."
                                            BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" 
                                            CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" >
                                            <PagerStyle CssClass="pagination_grid" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S No.">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Invoice Number">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblInvoiceNum" Text='<%#Eval("InvoiceNum") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Payment Date">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblPaymentDate" Text='<%#Eval("PaymentDate1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Payment Amount">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblPaymentAmount" Text='<%#Eval("PaymentReceived") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Payment Mode">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblPaymentMode" Text='<%#Eval("PaymentMode") %>'></asp:Label>
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
                </div>
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
</asp:Content>

