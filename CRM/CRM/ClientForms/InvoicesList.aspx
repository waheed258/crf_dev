﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ClientForms/Layout.master" AutoEventWireup="true" CodeFile="InvoicesList.aspx.cs" Inherits="ClientForms_InvoicesList" %>

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
                    $("[id *=ContentPlaceHolder1_gvInvoiceList]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvInvoiceList]").children
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


                    $("[id *=ContentPlaceHolder1_gvInvoiceList]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvInvoiceList]").children('tbody').
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
        <section class="content" id="InvoiceList" runat="server">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Invoices List</h5>
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
                                <asp:GridView ID="gvInvoiceList" runat="server" Width="100%"
                                    AutoGenerateColumns="False" DataKeyNames="InvoiceNum" CssClass="rounded-corners"
                                    EmptyDataText="There are no data records to display."
                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100" OnPageIndexChanging="gvInvoiceList_PageIndexChanging"
                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3">
                                    <PagerStyle CssClass="pagination_grid" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SAID">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SRNO">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblSRNO" Text='<%#Eval("SRNO") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                             
                                        <asp:TemplateField HeaderText="Service Name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblServiceName" Text='<%#Eval("ServiceName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Detail Information">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblDetailInformation" Text='<%#Eval("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PDF">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgPDF" ImageUrl="../assets/dist/img/pdf-icon.jpg" runat="server" Width="30" Height="30" OnClick="imgPDF_Click" title="PDF" OnClientClick="window.document.forms[0].target='blank';" />
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

