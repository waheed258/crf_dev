﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="ClientList.aspx.cs" Inherits="AdminForms_ClientList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .multi-select-container {
            display: inline-block;
            position: relative;
        }

        .multi-select-menu {
            position: absolute;
            left: 0;
            top: 0.8em;
            float: left;
            min-width: 100%;
            background: #fff;
            margin: 1em 0;
            padding: 0.4em 0;
            border: 1px solid #aaa;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.2);
            display: none;
        }

            .multi-select-menu input {
                margin-right: 0.3em;
                vertical-align: 0.1em;
            }

        .multi-select-button {
            display: inline-block;
            font-size: 0.875em;
            padding: 0.2em 0.6em;
            max-width: 20em;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
            vertical-align: -0.5em;
            background-color: #fff;
            border: 1px solid #aaa;
            border-radius: 4px;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.2);
            cursor: default;
        }

            .multi-select-button:after {
                content: "";
                display: inline-block;
                width: 0;
                height: 0;
                border-style: solid;
                border-width: 0.4em 0.4em 0 0.4em;
                border-color: #999 transparent transparent transparent;
                margin-left: 0.4em;
                vertical-align: 0.1em;
            }

        .multi-select-container--open .multi-select-menu {
            display: block;
        }

        .multi-select-container--open .multi-select-button:after {
            border-width: 0 0.4em 0.4em 0.4em;
            border-color: transparent transparent #999 transparent;
        }
    </style>
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
        <section class="content-header">
            <div class="header-title">
                <h1>Prospect Clients</h1>
            </div>
        </section>
        <!-- Main content -->
        <section class="content" id="sectionClientList" runat="server">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Clients List</h5>
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
                                <asp:GridView ID="gvClientsList" runat="server" Width="100%"
                                    AutoGenerateColumns="False" DataKeyNames="ClientRegistartionID" CssClass="rounded-corners"
                                    EmptyDataText="There are no data records to display." OnPageIndexChanging="gvClientsList_PageIndexChanging"
                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100" OnRowEditing="gvClientsList_RowEditing"
                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvClientsList_RowCommand">
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
                                        <asp:TemplateField HeaderText="First Name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblFirstName" Text='<%#Eval("FirstName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblLastName" Text='<%#Eval("LastName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email ID">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblEmailID" Text='<%#Eval("EmailID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile Number">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblMobileNumber" Text='<%#Eval("MobileNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblStatus" Text='<%#Eval("ClientStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CStatus" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblCStatus" Text='<%#Eval("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Province" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblProvince" Text='<%#Eval("Province") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="City" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblCity" Text='<%#Eval("City") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Title" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblTitle" Text='<%#Eval("Title") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RegID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblRegID" Text='<%#Eval("ClientRegistartionID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Advisor" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblAdvisor" Text='<%#Eval("AssignTo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" ImageUrl="~/assets/dist/img/edit_new.png" data-toggle="modal" data-target="#Edit" runat="server" Width="23px" Height="23px"
                                                    CommandName="Edit" ToolTip="Edit" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
                                                <asp:ImageButton ID="btnValidate" ImageUrl="~/assets/dist/img/validateClient.png" data-toggle="modal" data-target="#Validate" runat="server" Width="23px" Height="23px"
                                                    CommandName="Validate" ToolTip="Validate" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
                                                <asp:ImageButton ID="btnFeedback" ImageUrl="~/assets/dist/img/feedback.png" data-toggle="modal" data-target="#Feedback" runat="server" Width="23px" Height="23px"
                                                    CommandName="Feedback" ToolTip="Feedback" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
                                                <asp:ImageButton ID="btnStatus" ImageUrl="~/assets/dist/img/status.png" data-toggle="modal" data-target="#Status" runat="server" Width="23px" Height="23px"
                                                    CommandName="Status" ToolTip="Status" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" />
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


        <section class="content" id="editSection" runat="server">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Update Client</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Title</label><span class="style1">*</span>
                                    <asp:DropDownList ID="ddlTitle" runat="server" class="form-control">
                                        <asp:ListItem Text="--Select Title--" Value="-1" />
                                        <asp:ListItem Value="Mr">Mr</asp:ListItem>
                                        <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                        <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                        <asp:ListItem Value="Miss">Miss</asp:ListItem>
                                        <asp:ListItem Value="Dr">Dr</asp:ListItem>
                                        <asp:ListItem Value="Prof">Prof</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="Please select Title" Display="Dynamic"
                                        ControlToValidate="ddlTitle" ValidationGroup="Client" ForeColor="#d0582e" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>First Name</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtFirstName" runat="server" class="form-control" placeholder="Enter Given Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Please Enter First Name" ControlToValidate="txtFirstName" Display="Dynamic"
                                        ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Last Name</label><%--<span class="style1">*</span>--%>
                                    <asp:TextBox ID="txtLastName" runat="server" class="form-control" placeholder="Enter Sur Name"></asp:TextBox>
                                   <%-- <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="Please Enter Last Name" ControlToValidate="txtLastName" Display="Dynamic"
                                        ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>SAID</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtSAID" runat="server" class="form-control" placeholder="SA ID" MaxLength="13"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSAID" runat="server" ErrorMessage="Please Enter Last Name" ControlToValidate="txtSAID" Display="Dynamic"
                                        ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Mobile</label><%--<span class="style1">*</span>--%>
                                    <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="Enter Mobile" MaxLength="10"></asp:TextBox>
<%--                                    <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ErrorMessage="Please Enter Mobile Number" ControlToValidate="txtMobile" Display="Dynamic" ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="rgvMobile" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                        ControlToValidate="txtMobile" ForeColor="#d0582e" ValidationGroup="Client"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Email</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Enter Email" TextMode="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFV_Email" runat="server" ErrorMessage="Please Enter EmailID" ControlToValidate="txtEmail" ValidationGroup="Client" Display="Dynamic" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmailId" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please check Email Format"
                                        ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Client">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label class="control-label">Province</label><%--<span class="style1">*</span>--%>
                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                  <%--  <asp:RequiredFieldValidator ID="rfvProvince" runat="server" ControlToValidate="ddlProvince" Display="Dynamic" ErrorMessage="Please select Province"
                                        ValidationGroup="Client" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <label class="control-label">City</label><%--<span class="style1">*</span>--%>
                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                 <%--   <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity" Display="Dynamic" ErrorMessage="Please select City"
                                        ValidationGroup="Client" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="Button_Update" runat="server" Text="Update" class="btn btn-add btn-sm" ValidationGroup="Client" OnClick="Button_Update_Click" />
                            <asp:Button ID="Button_Close" runat="server" class="btn btn-danger btn-sm" Text="Back to List" OnClick="Button_Close_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="content" id="validateSection" runat="server">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Validate</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Verified On</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtVerifiedOn" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvVerifiedOn" runat="server" ErrorMessage="Please Select Date" ControlToValidate="txtVerifiedOn" Display="Dynamic"
                                        ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Verified Via</label><span class="style1">*</span>
                                    <asp:DropDownList ID="ddlVerifiedThrough" runat="server" class="form-control">
                                        <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Phone" Value="Phone"></asp:ListItem>
                                        <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvVerifiedThrough" runat="server" ErrorMessage="Please Select Verified Through" ControlToValidate="ddlVerifiedThrough" Display="Dynamic"
                                        ValidationGroup="Client" ForeColor="#d0582e" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Advisor Feedback</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtAdvisorFeedback" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAdvisorFeedback" runat="server" ErrorMessage="Please Enter Feedback" ControlToValidate="txtAdvisorFeedback" Display="Dynamic"
                                        ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label>Assign To Advisor</label><span class="style1">*</span>
                                    <%--<asp:DropDownList ID="ddlAssignTo" runat="server" CssClass="form-control" AppendDataBoundItems="true" multiple="multiple">
                                        <%--<asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>--%>
                                    <%--</asp:DropDownList>--%>
                                    <asp:ListBox ID="ddlAssignTo" runat="server" CssClass="form-control" AppendDataBoundItems="true" SelectionMode="Multiple"></asp:ListBox>
                                    <asp:RequiredFieldValidator ID="rfvAssignTo" runat="server" ErrorMessage="Please Select an Advisor" ControlToValidate="ddlAssignTo" Display="Dynamic"
                                        ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="ButtonValidate" runat="server" Text="Validate" class="btn btn-add btn-sm" ValidationGroup="Client" OnClick="ButtonValidate_Click" />
                            <asp:Button ID="btnClose" runat="server" class="btn btn-danger btn-sm" Text="Back to List" OnClick="btnClose_Click" />
                        </div>

                        <div class="panel-body" id="Validatelist" runat="server">
                            <div class="row" id="searchValidate" runat="server">
                                <div class="col-lg-12">
                                    <div class="col-lg-1 form-group">
                                        <asp:DropDownList ID="DropPageValidate" runat="server"
                                            OnSelectedIndexChanged="DropPageValidate_SelectedIndexChanged" CssClass="form-control"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2 form-group">
                                        <label class="control-label">
                                            Records per page</label>
                                    </div>
                                    <div class="col-lg-6"></div>
                                    <div class="col-lg-3">
                                        <input id="target1" type="text" class="form-control" placeholder="Text To Search" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="gvValidate" runat="server" Width="100%"
                                    AutoGenerateColumns="False" CssClass="rounded-corners"
                                    EmptyDataText="There are no data records to display." OnPageIndexChanging="gvValidate_PageIndexChanging"
                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100"
                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3">
                                    <PagerStyle CssClass="pagination_grid" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Verified On">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblVerifiedOn" Text='<%#Eval("VerifiedDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Verified Though">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblVerifiedThough" Text='<%#Eval("VerifiedThough") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Advisor FeedBack">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblAdvisorFeedBack" Text='<%#Eval("AdvisorFeedBack") %>'></asp:Label>
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
        <section class="content" id="ClientFeedbackSection" runat="server">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Client Feedback</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12">
                                <div class="form-group col-sm-5">
                                    <label>Client Feedback</label><span class="style1">*</span>
                                    <asp:TextBox ID="txtClientFeedback" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvClientFeedback" runat="server" ErrorMessage="Please Enter Feedback" ControlToValidate="txtClientFeedback" Display="Dynamic"
                                        ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="btnSaveFeedback" runat="server" Text="Save" class="btn btn-add btn-sm" ValidationGroup="Client" OnClick="btnSaveFeedback_Click" />
                            <asp:Button ID="btnCancelFeedback" runat="server" class="btn btn-danger btn-sm" Text="Back to List" OnClick="btnCancelFeedback_Click" />
                        </div>
                        <div class="panel-body" id="feedbacklist" runat="server">
                            <div class="row" id="searchFeedback" runat="server">
                                <div class="col-lg-12">
                                    <div class="col-lg-1 form-group">
                                        <asp:DropDownList ID="DropPageFeedback" runat="server"
                                            OnSelectedIndexChanged="DropPageFeedback_SelectedIndexChanged" CssClass="form-control"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2 form-group">
                                        <label class="control-label">
                                            Records per page</label>
                                    </div>
                                    <div class="col-lg-6"></div>
                                    <div class="col-lg-3">
                                        <input id="target2" type="text" class="form-control" placeholder="Text To Search" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="gvFeedBack" runat="server" Width="100%"
                                    AutoGenerateColumns="False" CssClass="rounded-corners" DataKeyNames="FeedBackID"
                                    EmptyDataText="There are no data records to display." OnPageIndexChanging="gvFeedBack_PageIndexChanging"
                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="100"
                                    CellPadding="4" CellSpacing="2" Style="font-size: 100%;" ForeColor="Black" HeaderStyle-BackColor="#e8f1f3">
                                    <PagerStyle CssClass="pagination_grid" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client FeedBack">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblClientFeedBack" Text='<%#Eval("ClientFeedBack") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Updated On">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblUpdatedOn" Text='<%#Eval("UpdatedOn") %>'></asp:Label>
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
        <section class="content" id="statusSection" runat="server">
            <div class="row">
                <!-- Form controls -->
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Update Status</h5>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-sm-12">
                                <div class="form-group col-sm-3">
                                    <label>Status</label><span class="style1">*</span>
                                    <asp:DropDownList ID="ddlClientStatus" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlClientStatus_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvClientStatus" runat="server" ErrorMessage="Please select Status" Display="Dynamic"
                                        ControlToValidate="ddlClientStatus" ValidationGroup="Client" ForeColor="#d0582e" InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-sm-3">
                                    <asp:Label runat="server" ID="lblResignedDate">Resigned Date</asp:Label>
                                    <asp:TextBox ID="txtResignedDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="rfvResignedDate" runat="server" ErrorMessage="Please Select Resigned Date" ControlToValidate="txtResignedDate" Display="Dynamic"
                                        ValidationGroup="Client" ForeColor="#d0582e"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="col-sm-5"></div>
                            <asp:Button ID="btnStatusSubmit" runat="server" Text="Update" class="btn btn-add btn-sm" ValidationGroup="Client" OnClick="btnStatusSubmit_Click" />
                            <asp:Button ID="btnStatusCancel" runat="server" class="btn btn-danger btn-sm" Text="Back to List" OnClick="btnStatusCancel_Click" />
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#target").keyup(function () {
                if ($("[id *=target]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvClientsList]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvClientsList]").children
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


                    $("[id *=ContentPlaceHolder1_gvClientsList]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvClientsList]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
            $("#target1").keyup(function () {
                if ($("[id *=target1]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvValidate]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvValidate]").children
                    ('tbody').children('tr').each(function () {
                        var match = false;
                        $(this).children('td').each(function () {
                            if ($(this).text().toUpperCase().indexOf($("[id *=target1]").val().toUpperCase()) > -1) {
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


                    $("[id *=ContentPlaceHolder1_gvValidate]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvValidate]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
            $("#target2").keyup(function () {
                if ($("[id *=target2]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvFeedBack]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvFeedBack]").children
                    ('tbody').children('tr').each(function () {
                        var match = false;
                        $(this).children('td').each(function () {
                            if ($(this).text().toUpperCase().indexOf($("[id *=target2]").val().toUpperCase()) > -1) {
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


                    $("[id *=ContentPlaceHolder1_gvFeedBack]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvFeedBack]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
            $("#ContentPlaceHolder1_ddlAssignTo").multiSelect();
        });
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show');
        }
    </script>
</asp:Content>

