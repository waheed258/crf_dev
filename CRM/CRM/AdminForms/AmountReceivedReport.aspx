<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="AmountReceivedReport.aspx.cs" Inherits="AdminForms_AmountReceivedReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show');
        }
    </script>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#target").keyup(function () {
                if ($("[id *=target]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvAmountReceived]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvAmountReceived]").children
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


                    $("[id *=ContentPlaceHolder1_gvAmountReceived]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvAmountReceived]").children('tbody').
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
            <div class="header-title">
                <h1>Invoices List</h1>
            </div>
        </section>
        <!-- Main content -->
        <asp:HiddenField ID="TabName" runat="server" />
        <section class="content" id="AmountList" runat="server">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Amount Received Reports</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row" id="search" runat="server">
                                <div class="col-lg-12">
                                    <div class="col-lg-1 form-group" style="margin-top: 15px;">
                                        <asp:DropDownList ID="DropPage" runat="server" CssClass="form-control"
                                            OnSelectedIndexChanged="DropPage_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2 form-group" style="margin-top: 20px">
                                        <label class="control-label">
                                            Records per page</label>
                                    </div>
                                    <div class="col-lg-3" style="margin-top: 15px">
                                        <input id="target" type="text" class="form-control" placeholder="Text To Search" />
                                    </div>
                                    <div class="col-lg-2"></div>
                                    <div class="col-lg-2"></div>
                                    <div class="col-lg-2 text-right form-group">
                                        <asp:ImageButton ID="imgbtnExcel" ImageUrl="../assets/dist/img/excel.png" runat="server" Height="35px" Style="margin-left: 10px; margin-top: 15px"
                                            ToolTip="Export To Excel" OnClick="imgbtnExcel_Click" />
                                        <asp:ImageButton ID="imgpdf" ImageUrl="../assets/dist/img/pdf-icon.jpg" runat="server" Height="35px" Style="margin-left: 10px; margin-top: 15px"
                                            ToolTip="Export To PDf" OnClick="imgpdf_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="gvAmountReceived" runat="server" Width="100%"
                                    AutoGenerateColumns="False" CssClass="rounded-corners"
                                    EmptyDataText="There are no data records to display."
                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100" OnPageIndexChanging="gvAmountReceived_PageIndexChanging" OnRowDataBound="gvAmountReceived_RowDataBound"
                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3">
                                    <PagerStyle CssClass="pagination_grid" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Sl No" ReadOnly="true" />
                                        <asp:BoundField DataField="InvoiceNum" HeaderText="Invoice Number" ReadOnly="true" />
                                        <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" ReadOnly="true" />
                                        <asp:BoundField DataField="AdvisorName" HeaderText="Advisor Name" ReadOnly="true" />
                                        <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" ReadOnly="true" />
                                        <asp:BoundField DataField="PaymentReceived" HeaderText="Amount Received" ReadOnly="true" />
                                        <asp:BoundField DataField="AmountStatus" HeaderText="Amount Status" ReadOnly="true" />

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
                        <h3>
                            <asp:Label ID="lblTitle" runat="server" class="control-label" /></h3>
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
    </div>
</asp:Content>

