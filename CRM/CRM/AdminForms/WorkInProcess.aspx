<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="WorkInProcess.aspx.cs" Inherits="AdminForms_WorkInProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                <h1>Work In Process Service Requests</h1>
            </div>
        </section>
        <!-- Main content -->
        <section class="content" id="sectionRequestList" runat="server">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Work In Process Service Requests List</h5>
                            </div>
                        </div>

                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView ID="gvWorkInProcess" runat="server" Width="100%"
                                    AutoGenerateColumns="False" DataKeyNames="ClientServiceID" CssClass="rounded-corners"
                                    EmptyDataText="There are no data records to display."
                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100"
                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvWorkInProcess_RowCommand">
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
                                        <asp:TemplateField HeaderText="Client Name" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblName" Text='<%#Eval("FIRSTNAME") +" "+ Eval("LASTNAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Allocated To" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblAllocatedTo" Text='<%#Eval("FirstName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AdvisorID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblAdvisorID" Text='<%#Eval("AdvisorID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AdvisorName" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblAdvisorName" Text='<%#Eval("Name") %>'></asp:Label>
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

    </div>
</asp:Content>

