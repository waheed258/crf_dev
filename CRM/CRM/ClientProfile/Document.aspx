<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/LayoutForClientProfile.master" AutoEventWireup="true" CodeFile="Document.aspx.cs" Inherits="ClientProfile_Document" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#target").keyup(function () {
                if ($("[id *=target]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvDocument]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvDocument]").children
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


                    $("[id *=ContentPlaceHolder1_gvDocument]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvDocument]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
        });
    </script>
    <script type="text/javascript">
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show', { backdrop: 'static' });
        }
        function openDeleteModal() {
            $('#delete').modal('show', { backdrop: 'static' });
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
                <h1>
                    <asp:Label ID="lblHeading" runat="server"></asp:Label></h1>
            </div>
        </div>
        <!-- Main content -->
        <div class="content">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-6">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Add Document</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div>
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                <asp:HiddenField ID="hfDocID" runat="server" Value="0" />
                                <asp:HiddenField ID="hfDocumentName" runat="server" Value="0" />
                                <asp:HiddenField ID="hfUIC" runat="server" Value="0" />
                                <asp:HiddenField ID="hfSAID" runat="server" Value="0" />

                            </div>
                            <div class="col-sm-12">
                                <div class="col-sm-4 form-group">
                                    <asp:Label ID="lblName" runat="server" CssClass="control-label"></asp:Label><span class="style1">*</span>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <asp:TextBox ID="txtSAID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxtSAID" runat="server" ControlToValidate="txtSAID" Display="Dynamic" ErrorMessage="Enter SAID"
                                        ForeColor="Red" ValidationGroup="Doc"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="col-sm-4 form-group">
                                    <label class="control-label">Type of Document</label><span class="style1">*</span>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <asp:DropDownList ID="ddlDocType" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvddlDocType" runat="server" ControlToValidate="ddlDocType" Display="Dynamic" ErrorMessage="Select type of document "
                                        ForeColor="Red" InitialValue="-1" ValidationGroup="Doc"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="col-sm-4 form-group">
                                    <label class="control-label">Document</label><span class="style1">*</span>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <asp:FileUpload ID="fuDoc" runat="server" AllowMultiple="true"></asp:FileUpload>
                                    <asp:Label ID="lblFileName" runat="server" CssClass="control-label"></asp:Label>
                                    <asp:RequiredFieldValidator ID="rfvfuDoc" runat="server" ControlToValidate="fuDoc" Display="Dynamic" ErrorMessage="Select Document"
                                        ForeColor="Red" ValidationGroup="Doc"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="fuDoc" runat="server" ID="revfuDoc" ForeColor="Red"
                                        Display="Dynamic" CssClass="span6 m-wrap" ErrorMessage="Select only Pdf Files." ValidationGroup="Doc"
                                        ValidationExpression="^.*\.(pdf|PDF)$" />
                                </div>
                            </div>

                        </div>
                        <div class="panel-footer">
                            <div class="col-sm-4"></div>
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="btn btn-primary" Text="Save" ValidationGroup="Doc" />
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" CssClass="btn btn-danger" Text="Cancel" />
                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="panel panel-bd" id="divTrustlist" runat="server">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>List of Documents</h5>
                            </div>
                        </div>

                        <div class="panel-body">
                            <div class="row" id="search" runat="server">
                                <div class="col-lg-12">
                                    <div class="col-lg-2 form-group">
                                        <asp:DropDownList ID="DropPage" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropPage_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-4 form-group">
                                        <label class="control-label">Records per page</label>
                                    </div>
                                    <div class="col-lg-2"></div>
                                    <div class="col-lg-4 form-group">
                                        <input id="target" type="text" class="form-control" placeholder="Text To Search" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="gvDocument" runat="server" Width="100%"
                                    AutoGenerateColumns="False" DataKeyNames="DocId" CssClass="rounded-corners" EmptyDataText="There are no data records to display."
                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" CellPadding="4" CellSpacing="2" Style="font-size: 100%;"
                                    OnRowDataBound="gvDocument_RowDataBound"
                                    ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvDocument_RowCommand" OnPageIndexChanging="gvDocument_PageIndexChanging">
                                    <PagerStyle CssClass="pagination_grid" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client Type">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblClientType" Text='<%#Eval("Type") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Document Type">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblDocType" Text='<%#Eval("DocumentType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Document Name">
                                            <ItemTemplate>
                                                <a id="anchorId" runat="server" href="#" target="_blank">
                                                    <%#Eval("DocumentName") %>  </a>
                                                <asp:Label ID="lblDoc" runat="server" OnClick="linkDoc_Click" Text='<%#Eval("Document") %>' Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                    CommandName="EditDoc" ToolTip="Edit" CommandArgument='<%#Eval("DocId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                    CommandName="DeleteDec" ToolTip="Delete Trust" CommandArgument='<%#Eval("DocId")+","+Eval("Document") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="modal fade" id="Success" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header modal-header-primary">
                                 <h3><asp:Label ID="lblTitle" runat="server" class="control-label"/></h3>
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
        </div>
    </div>
</asp:Content>


