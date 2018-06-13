<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="AdminDocument.aspx.cs" Inherits="AdminForms_AdminDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show', { backdrop: 'static' });
        }
        function openDeleteModal() {
            $('#delete').modal('show', { backdrop: 'static' });
        }
        function CloseDocumentModal() {
            $('#ContentPlaceHolder1_documentclose').modal('show', { backdrop: 'static' });
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

        <div class="content-header">
            <div class="header-title">
                <h1>Admin Document</h1>
            </div>
        </div>
        <div class="content">
            <div style="text-align: center; margin-bottom: 10px;">
                <asp:Label ID="lblMessage" runat="server" Style="color: #006341; font-weight: bold; text-align: center"></asp:Label>
            </div>


            <div class="panel panel-bd" id="documentsection" runat="server">
                <div class="panel-heading">
                    <div class="panel-title">
                        <h5>Admin Document Form</h5>
                    </div>
                </div>
                <div class="panel-body">

                    <div>                       
                        <%--<asp:HiddenField ID="hfDocID" runat="server" Value="0" />--%>
                        <asp:HiddenField ID="hfDocID" runat="server" Value="0" />
                        <asp:HiddenField ID="hfDocumentName" runat="server" Value="0" />                        
                        <asp:HiddenField ID="hfSAID" runat="server" Value="0" />
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group col-sm-2">
                            <label class="control-label">SAID</label>
                        </div>
                        <div class="form-group col-sm-6">
                            <asp:TextBox ID="txtSaId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group col-sm-2">
                            <label class="control-label">Name</label>
                        </div>
                        <div class="form-group col-sm-6">
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group col-sm-2">
                            <label class="control-label">Document Type</label><span class="style1">*</span>
                        </div>
                        <div class="form-group col-sm-2">
                            <asp:DropDownList ID="ddlDocumentType" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvddlDocumentType" runat="server" ControlToValidate="ddlDocumentType" Display="Dynamic" ErrorMessage="Select Document Type"
                                ValidationGroup="Doc" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group col-sm-2">
                            <label class="control-label">Upload Document</label><span class="style1">*</span>
                        </div>
                        <div class="form-group col-sm-4">
                            <asp:FileUpload ID="fuDocument" runat="server"></asp:FileUpload>
                            <asp:Label ID="lblFileName" runat="server" CssClass="control-label"></asp:Label>
                             <asp:RequiredFieldValidator ID="rfvfuDocument" runat="server" ControlToValidate="fuDocument" Display="Dynamic" ErrorMessage="Select Document"
                                        ForeColor="Red" ValidationGroup="Doc"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ControlToValidate="fuDocument" runat="server" ID="revfuDocument" ForeColor="Red"
                                        Display="Dynamic" CssClass="span6 m-wrap" ErrorMessage="Select only Pdf Files." ValidationGroup="Doc"
                                        ValidationExpression="^.*\.(pdf|PDF)$" />
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="col-sm-4"></div>

                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="Doc" OnClick="btnSubmit_Click" CssClass="btn btn-primary"></asp:Button>                   
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger"></asp:Button>
                </div>

                <div class="panel panel-bd" id="divAddressDetails" runat="server">
                    <div class="panel-heading">
                        <div class="panel-title">
                            <h5>List of Document</h5>
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
                                ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvDocument_RowCommand" OnPageIndexChanging="gvDocument_PageIndexChanging" OnRowDataBound="gvDocument_RowDataBound">
                                <PagerStyle CssClass="pagination_grid" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Client Type">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblDocType" Text='<%#Eval("ClientDocumentsName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document Name">
                                        <ItemTemplate>
                                            <a id="anchorDocument" runat="server" href="#" target="_blank" ><%#Eval("DocumentName") %> </a>
                                                <asp:Label runat="server" ID="lblDocumentName" Text='<%#Eval("Document") %>' Visible="false"></asp:Label>                                          
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
        </div>


        <!-- delete user Modal2 -->
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
                                        <asp:Label ID="message" runat="server" class="control-label"  />
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

        <div class="modal fade" id="documentclose" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header modal-header-primary">
                        <h3><asp:Label ID="lblmsgdoc" runat="server" class="control-label" Style="color: red" Text="Warning!" /></h3>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <div class="col-md-12 form-group user-form-group">
                                        <asp:Label ID="messagedoc" runat="server" class="control-label" Style="color: red" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="buttoncancel" runat="server" Text="Close" class="btn btn-danger pull-left" OnClick="buttoncancel_Click"></asp:Button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
    </div>


</asp:Content>

