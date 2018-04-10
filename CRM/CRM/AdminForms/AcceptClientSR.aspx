<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="AcceptClientSR.aspx.cs" Inherits="AdminForms_AcceptClientSR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
            <div class="header-title">
                <h1>Client Service Requests</h1>
            </div>
        </section>
        <!-- Main content -->
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
                            <div class="table-responsive">
                                <asp:GridView ID="gvClientSR" runat="server" Width="100%"
                                    AutoGenerateColumns="False" DataKeyNames="ClientServiceID" CssClass="rounded-corners"
                                    EmptyDataText="There are no data records to display."
                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100" OnRowEditing="gvClientSR_RowEditing"
                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvClientSR_RowCommand">
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
                                                <asp:Label runat="server" ID="lblName" Text='<%#Eval("FIRSTNAME") +" "+ Eval("LASTNAME") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Allocated To" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblAllocatedTo" Text='<%#Eval("FirstName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField headertext="AdvisorID" visible="false">
                                            <ItemTemplate>
                                                <asp:label runat="server" id="lblAdvisorID" text='<%#Eval("AdvisorID") %>'></asp:label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField headertext="AdvisorName" visible="false">
                                            <ItemTemplate>
                                                <asp:label runat="server" id="lblAdvisorName" text='<%#Eval("Name") %>'></asp:label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                   
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnAllocatedTo" ImageUrl="~/assets/dist/img/settler.png" data-toggle="modal" data-target="#AllocatedTo" runat="server" Width="23px" Height="23px"
                                                    CommandName="AllocatedTo" ToolTip="AllocatedTo" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
                                                <asp:ImageButton ID="btnFollowUp" ImageUrl="~/assets/dist/img/Trustee.jpg" data-toggle="modal" data-target="#FollowUp" runat="server" Width="23px" Height="23px"
                                                    CommandName="FollowUp" ToolTip="FollowUp" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
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
                                <h5>Advisor List</h5>
                             
                            </div>
                        </div>
                        <div class="panel-body">
                              <div class="col-sm-12" style="text-align:center">
                                  <asp:Label ID="lblmessage" runat="server" class="control-label" Style="color: green"></asp:Label>
                                  </div>
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Advisors</label>
                                    <asp:DropDownList ID="ddlAdvisors" runat="server" class="form-control">
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

        <section class="content" id="FollowUpSection" runat="server">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Details</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                             <div class="col-sm-12" style="text-align:center">
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
                                    <label>FollowUp Date & Time</label>
                                    <asp:TextBox ID="txtFollowDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox><br />
                                    <asp:TextBox ID="txtFollowTime" TextMode="Time" runat="server" class="form-control" ></asp:TextBox>
                                   
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Due Date</label>
                                   <asp:TextBox ID="txtDueDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox><br />
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Priority</label>
                                    <asp:DropDownList ID="dropPriority" runat="server" class="form-control" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Activity Type</label>
                                    <asp:DropDownList ID="dropActivityType" runat="server" class="form-control" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                </div>
                            </div>                           
                        </div>
                        <div class="panel-footer">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="FollowUpdate" runat="server" Text="Submit" class="btn btn-add btn-sm" ValidationGroup="Client" OnClick="FollowUpdate_Click" />
                            <asp:Button ID="FollowClose" runat="server" class="btn btn-danger btn-sm" Text="Back to List" OnClick="FollowClose_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- /.content -->

        


    </div>
</asp:Content>

