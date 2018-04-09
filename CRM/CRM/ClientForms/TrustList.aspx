<%@ Page Title="" Language="C#" MasterPageFile="~/ClientForms/Layout.master" AutoEventWireup="true" CodeFile="TrustList.aspx.cs" Inherits="Client_TrustList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="wrapper">

        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header content-head">

                <div class="header-title" style="margin-left: 0px !important;">
                    <h1>Trust Information</h1>
                </div>
            </section>

            <!-- Main content -->
            <section class="content">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-bd box">
                            <div class="panel-heading panel-head">
                                <div class="panel-title">
                                    <h5 style="color: #fff">Trust List</h5>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <asp:GridView ID="gvBookinglst" runat="server" AllowPaging="true" EmptyDataText="No records found" DataKeyNames="bk_id"
                                        AutoGenerateColumns="False" CssClass="table table-bordered table-striped table-hover"
                                        Width="100%" usecustompager="true">
                                        <AlternatingRowStyle CssClass="gridcolor" />
                                        <PagerSettings Mode="Numeric" Position="Bottom" />
                                        <PagerStyle BackColor="#efefef" ForeColor="black" HorizontalAlign="Left" CssClass="pagination" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="S.No" HeaderStyle-CssClass="panel-heading" ItemStyle-CssClass="gradeC">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UIC">
                                                <ItemTemplate>
                                                    <%#Eval("UIC")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Trust Name">
                                                <ItemTemplate>
                                                    <%#Eval("TrustName")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Tax Ref No">
                                                <ItemTemplate>
                                                    <%#Eval("TaxRefNo")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <%#Eval("EmailID")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Website">
                                                <ItemTemplate>
                                                    <%#Eval("Website")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Telephone">
                                                <ItemTemplate>
                                                    <%#Eval("Telephone")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <%#Eval("Status")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Actions">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnEditBooking" ImageUrl="~/Admin/Images/icons/icon-edit.png" runat="server" Width="20px" Height="20px"
                                                                    CommandName="Editbooking" ToolTip="Edit Booking Details" CommandArgument='<%# Eval("UIC") %>' />
                                                                <asp:ImageButton ID="imgExpWriting" ImageUrl="~/Admin/Images/icons/scenario.png" runat="server" Width="20px" Height="20px"
                                                                    CommandName="EditScenario" ToolTip="Edit Scenario writing" CommandArgument='<%# Eval("UIC")%>' />
                                                                <asp:ImageButton ID="imgupload" ImageUrl="~/Admin/Images/icons/icon-upload.png" runat="server" Width="20px" Height="20px"
                                                                    CommandName="UploadDoc" ToolTip="Upload word document " CommandArgument='<%# Eval("UIC")  %>' />
                                                                <asp:ImageButton ID="imgDownload" ImageUrl="~/Admin/Images/icons/download.png" runat="server" Width="20px" Height="20px"
                                                                    CommandName="downloadDoc" ToolTip="Download word document " CommandArgument='<%# Eval("UIC")  %>' />

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>




                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- customer Modal1 -->
                <div class="modal fade" id="customer1" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header modal-header-primary">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h3><i class="fa fa-user m-r-5"></i>Update Customer</h3>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <form class="form-horizontal">
                                            <fieldset>
                                                <!-- Text input-->
                                                <div class="col-md-4 form-group">
                                                    <label class="control-label">Customer Name:</label>
                                                    <input type="text" placeholder="Customer Name" class="form-control">
                                                </div>
                                                <!-- Text input-->
                                                <div class="col-md-4 form-group">
                                                    <label class="control-label">Email:</label>
                                                    <input type="email" placeholder="Email" class="form-control">
                                                </div>
                                                <!-- Text input-->
                                                <div class="col-md-4 form-group">
                                                    <label class="control-label">Mobile</label>
                                                    <input type="number" placeholder="Mobile" class="form-control">
                                                </div>
                                                <div class="col-md-6 form-group">
                                                    <label class="control-label">Address</label><br>
                                                    <textarea name="address" rows="3"></textarea>
                                                </div>
                                                <div class="col-md-6 form-group">
                                                    <label class="control-label">type</label>
                                                    <input type="text" placeholder="type" class="form-control">
                                                </div>
                                                <div class="col-md-12 form-group user-form-group">
                                                    <div class="pull-right">
                                                        <button type="button" class="btn btn-danger btn-sm">Cancel</button>
                                                        <button type="submit" class="btn btn-add btn-sm">Save</button>
                                                    </div>
                                                </div>
                                            </fieldset>
                                        </form>
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
                <!-- /.modal -->
                <!-- Modal -->

            </section>
            <!-- /.content -->
        </div>
    </div>
</asp:Content>

