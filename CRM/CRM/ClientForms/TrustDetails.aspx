<%@ Page Title="" Language="C#" MasterPageFile="~/ClientForms/Layout.master" AutoEventWireup="true" CodeFile="TrustDetails.aspx.cs" Inherits="ClientForms_TrustDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtYearofFoundation").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0",
                dateFormat: 'yy-mm-dd',
                //numberOfMonths: 1,                

            });
        });
        </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#target").keyup(function () {
                if ($("[id *=target]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvTrust]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvTrust]").children
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


                    $("[id *=ContentPlaceHolder1_gvTrust]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvTrust]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
            $("#targetBank").keyup(function () {
                if ($("[id *=target1]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gdvBankList]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gdvBankList]").children
                    ('tbody').children('tr').each(function () {
                        var match = false;
                        $(this).children('td').each(function () {
                            if ($(this).text().toUpperCase().indexOf($("[id *=targetBank]").val().toUpperCase()) > -1) {
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
                    $("[id *=ContentPlaceHolder1_gdvBankList]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gdvBankList]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
            $("#targetAddress").keyup(function () {
                if ($("[id *=target2]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvAddress]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvAddress]").children
                    ('tbody').children('tr').each(function () {
                        var match = false;
                        $(this).children('td').each(function () {
                            if ($(this).text().toUpperCase().indexOf($("[id *=targetAddress]").val().toUpperCase()) > -1) {
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


                    $("[id *=ContentPlaceHolder1_gvAddress]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvAddress]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
            $("#targetAccountant").keyup(function () {
                if ($("[id *=target3]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvAccountDetails]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvAccountDetails]").children
                    ('tbody').children('tr').each(function () {
                        var match = false;
                        $(this).children('td').each(function () {
                            if ($(this).text().toUpperCase().indexOf($("[id *=targetAccountant]").val().toUpperCase()) > -1) {
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


                    $("[id *=ContentPlaceHolder1_gvAccountDetails]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvAccountDetails]").children('tbody').
                            children('tr').each(function () {
                                $(this).show();
                            });
                }
            });
            $("#targetPrivateBank").keyup(function () {
                if ($("[id *=target4]").val() != "") {
                    $("[id *=ContentPlaceHolder1_gvPrivateBank]").children
                    ('tbody').children('tr').each(function () {
                        $(this).show();
                    });
                    $("[id *=ContentPlaceHolder1_gvPrivateBank]").children
                    ('tbody').children('tr').each(function () {
                        var match = false;
                        $(this).children('td').each(function () {
                            if ($(this).text().toUpperCase().indexOf($("[id *=targetPrivateBank]").val().toUpperCase()) > -1) {
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


                    $("[id *=ContentPlaceHolder1_gvPrivateBank]").children('tbody').
                            children('tr').each(function (index) {
                                if (index == 0)
                                    $(this).show();
                            });
                }
                else {
                    $("[id *=ContentPlaceHolder1_gvPrivateBank]").children('tbody').
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

        .style1 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="header-title">
                <h1>Trust Information</h1>
            </div>
        </div>
        <!-- Main content -->
        <div class="content">
            <div class="row">
                <!-- Form controls -->
                <asp:HiddenField ID="TabName" runat="server" />
                <div class="col-sm-12">
                    <div class="panel panel-bd">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <h5>Trust Details</h5>
                            </div>
                        </div>
                        <div class="panel-body" id="Tabs">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#tabTrust" data-toggle="tab">Trust Details</a></li>
                                <li><a href="#tabAddress" data-toggle="tab">Address Details</a></li>
                                <li><a href="#tabBank" data-toggle="tab">Bank Details</a></li>
                                <li><a href="#tabAccountant" data-toggle="tab">Accountant Details</a></li>
                                <li><a href="#tabPrivateBanker" data-toggle="tab">Private Banker</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="tabTrust">
                                    <div class="panel-body">
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <div class="col-sm-11" style="padding: 0px;">
                                                    <label class="control-label">Registration #</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtUIC" CssClass="form-control" runat="server" MaxLength="13"
                                                        placeholder="Registration #"></asp:TextBox>
                                                    <asp:Label ID="lblUICError" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:RequiredFieldValidator ID="rfvtxtUIC" runat="server" ControlToValidate="txtUIC" Display="Dynamic" ErrorMessage="Enter UIC Number"
                                                        ValidationGroup="trust" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revtxtUIC" runat="server" ErrorMessage="Please enter 13 digits" ValidationExpression="[0-9]{13}" Display="Dynamic"
                                                        ControlToValidate="txtUIC" ForeColor="Red" ValidationGroup="trust"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-sm-1 form-group" style="padding: 0px; margin-top: 14px;">
                                                    <asp:ImageButton ID="imgSearchsaid" runat="server" ImageUrl="~/assets/dist/img/search-icon.png" Height="35" Width="35" ToolTip="Search" OnClick="imgSearchsaid_Click" />
                                                </div>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Trust Name</label><span class="style1">*</span>
                                                <asp:TextBox ID="txtTrustName" CssClass="form-control" runat="server" placeholder="Trust Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvTrustName" runat="server" ControlToValidate="txtTrustName" Display="Dynamic" ErrorMessage="Enter Trust Name"
                                                    ValidationGroup="trust" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Year of Trust Foundation</label><%--<span class="style1">*</span>--%>
                                                <asp:TextBox ID="txtYearofFoundation" CssClass="form-control" disabled="disabled" autocomplete="off" runat="server"></asp:TextBox>
                                                <%-- <asp:RequiredFieldValidator ID="rfvYearOfFoundation" runat="server" ControlToValidate="txtYearofFoundation" Display="Dynamic"
                                                    ErrorMessage="Enter year of Foundation"
                                                    ValidationGroup="trust" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Income Tax </label>
                                                <%--<span class="style1">*</span>--%>
                                                <asp:TextBox ID="txtVATRef" CssClass="form-control" runat="server" placeholder="Income Tax"></asp:TextBox>
                                                <%--  <asp:RequiredFieldValidator ID="rfvtxtVATRef" runat="server" ControlToValidate="txtVATRef" Display="Dynamic"
                                                    ErrorMessage="Enter Tax Reference"
                                                    ValidationGroup="trust" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Telephone</label><%--<span class="style1">*</span>--%>
                                                <asp:TextBox ID="txtTelephone" CssClass="form-control" MaxLength="10" runat="server" placeholder="Telephone"></asp:TextBox>
                                                <%-- <asp:RequiredFieldValidator ID="rfvTelephone" runat="server" ControlToValidate="txtTelephone" Display="Dynamic"
                                                    ErrorMessage="Enter Telephone" ValidationGroup="trust" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                <asp:RegularExpressionValidator ID="revtxtTelephone" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                    ControlToValidate="txtTelephone" ForeColor="Red" ValidationGroup="trust"></asp:RegularExpressionValidator>
                                            </div>
                                            <%-- <div class="col-sm-3 form-group">
                                                <label class="control-label">Fax</label>
                                                <asp:TextBox ID="txtFax" CssClass="form-control" runat="server" MaxLength="10" placeholder="Fax"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revtxtFax" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                    ControlToValidate="txtFax" ForeColor="Red" ValidationGroup="trust"></asp:RegularExpressionValidator>
                                            </div>--%>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Email Id</label><%--<span class="style1">*</span>--%>
                                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Email Id"></asp:TextBox>
                                                <%-- <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                                                    ErrorMessage="Enter Email ID" ValidationGroup="trust" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                <asp:RegularExpressionValidator ID="revtxtEmail" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please check Email Format"
                                                    ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="trust">
                                                </asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label">Website</label>
                                                <asp:TextBox ID="txtWebsite" CssClass="form-control" placeholder="http://www.example.com" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rgvWebsite" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please check Website Format"
                                                    ControlToValidate="txtWebsite" ValidationExpression="^((http|https|ftp|www):\/\/)?([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)(\.)([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]+)" ValidationGroup="Company">
                                                </asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="panel-footer" style="border-top: 0px !important;">
                                        <div class="col-sm-5"></div>
                                        <asp:Button ID="btnSubmitTrust" runat="server" Text="Save" ValidationGroup="trust" OnClick="btnSubmitTrust_Click" CssClass="btn btn-primary"></asp:Button>
                                        <asp:Button ID="btnCancleTrust" runat="server" Text="Cancel" OnClick="btnCancleTrust_Click" CssClass="btn btn-danger"></asp:Button>
                                    </div>

                                    <div class="panel panel-bd" id="divTrustlist" runat="server">
                                        <div class="panel-heading">
                                            <div class="panel-title">
                                                <h5>List of Trusts</h5>
                                            </div>
                                        </div>

                                        <div class="panel-body">
                                            <div class="row" id="search" runat="server">
                                                <div class="col-lg-12">
                                                    <div class="col-lg-1 form-group">
                                                        <asp:DropDownList ID="DropPage" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropPage_SelectedIndexChanged"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-lg-2 form-group">
                                                        <label class="control-label">Records per page</label>
                                                    </div>
                                                    <div class="col-lg-6"></div>
                                                    <div class="col-lg-3 form-group">
                                                        <input id="target" type="text" class="form-control" placeholder="Text To Search" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="table-responsive">
                                                <asp:GridView ID="gvTrust" runat="server" Width="100%" OnRowDataBound="gvTrust_RowDataBound"
                                                    AutoGenerateColumns="False" DataKeyNames="TrustID" CssClass="rounded-corners" EmptyDataText="There are no data records to display."
                                                    BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" CellPadding="4" CellSpacing="2" Style="font-size: 100%;"
                                                    ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvTrust_RowCommand" OnPageIndexChanging="gvTrust_PageIndexChanging">
                                                    <PagerStyle CssClass="pagination_grid" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S No.">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Registration #">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Client Identification #" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Trust Name">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblTrustName" Text='<%#Eval("TrustName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Year Of Foundation" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblYearOfFoundation" Text='<%#Eval("YearOfFoundation") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Telephone" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblTelephone" Text='<%#Eval("Telephone") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="EmailID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblEmailID" Text='<%#Eval("EmailID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="FaxNo" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblFaxNo" Text='<%#Eval("FaxNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Website" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblWebsite" Text='<%#Eval("Website") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Income Tax" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblTaxRefNo" Text='<%#Eval("VATNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Flag" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblFlag" Text='<%#Eval("Flag") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="AdvisorID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAdvisorID" Text='<%#Eval("AdvisorID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                        <%--                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                    CommandName="EditTrust" ToolTip="Edit" CommandArgument='<%#Eval("UIC") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Document">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnDocument" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/upload.png"
                                                                    CommandName="Document" ToolTip="Add Documents" CommandArgument='<%#Eval("UIC") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bank">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnBank" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/bank.png"
                                                                    CommandName="Bank" ToolTip="Bank Details" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Address">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnAddress" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/address.png"
                                                                    CommandName="Address" ToolTip="Address Details" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Accountant">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnAccountant" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/accountant.png"
                                                                    CommandName="Accountant" ToolTip="Accountant Details" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Private Banker">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnPrivateBanker" runat="server" Width="28px" Height="23px" ImageUrl="~/assets/dist/img/privatebank.png"
                                                                    CommandName="PrivateBanker" ToolTip="Private Banker" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Trustee">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnTrustee" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Beneficiary.jpg"
                                                                    CommandName="EditTrustee" ToolTip="Trustee Details" CommandArgument='<%#Eval("UIC") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Settlor">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnSettlor" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Beneficiary.jpg"
                                                                    CommandName="EditSettler" ToolTip="Trust Settlor Details" CommandArgument='<%#Eval("UIC") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Share Holder">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnBeneficiary" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Beneficiary.jpg"
                                                                    CommandName="EditBeneficiary" ToolTip="Beneficiary Details" CommandArgument='<%#Eval("UIC") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Validate">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgbtnValidate" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/tick.jpg"
                                                                    CommandName="Validate" ToolTip="Validate" CommandArgument='<%#Eval("UIC") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                    CommandName="DeleteTrust" ToolTip="Delete Trust" CommandArgument='<%#Eval("UIC") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="tab-pane fade" id="tabAddress">
                                    <div class="panel-body">
                                        <div class="row" id="searchaddress" runat="server">
                                            <div class="col-lg-12">
                                                <div class="col-lg-1 form-group">
                                                    <asp:DropDownList ID="dropAddress" runat="server" CssClass="form-control"
                                                        OnSelectedIndexChanged="dropAddress_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2 form-group">
                                                    <label class="control-label">Records per page</label>
                                                </div>
                                                <div class="col-lg-6"></div>
                                                <div class="col-lg-3 form-group">
                                                    <input id="targetAddress" type="text" class="form-control" placeholder="Text To Search" />
                                                </div>

                                            </div>
                                        </div>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvAddress" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="AddressDetailID" CssClass="rounded-corners" EmptyDataText="There are no data records to display."
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" CellPadding="4" CellSpacing="2" Style="font-size: 100%;"
                                                ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvAddress_RowCommand" OnPageIndexChanging="gvAddress_PageIndexChanging">
                                                <PagerStyle CssClass="pagination_grid" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Address Detail ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAddressDetailID" Text='<%#Eval("AddressDetailID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Identification #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSAID" Text='<%#Eval("SAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trust Registration #">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trust Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblFullName" Text='<%#Eval("TRUSTNAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Client Identification #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="HouseNo">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblHouseNo" Text='<%#Eval("HouseNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Building Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBuildingName" Text='<%#Eval("BuildingName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblType" Text='<%#Eval("Type") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="FloorNo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblFloorNo" Text='<%#Eval("FloorNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Flat No" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblFlatNo" Text='<%#Eval("FlatNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RoadName" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblRoadName" Text='<%#Eval("RoadName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RoadNo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblRoadNo" Text='<%#Eval("RoadNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SuburbName" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSuburbName" Text='<%#Eval("SuburbName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Postal Code" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblPostalCode" Text='<%#Eval("PostalCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Country" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCountry" Text='<%#Eval("Country") %>'></asp:Label>
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
                                                    <%--  <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                CommandName="EditAddress" ToolTip="Edit" CommandArgument='<%#Eval("AddressDetailID") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnAddressDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                CommandName="DeleteAddress" ToolTip="Delete" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabBank">
                                    <div class="panel-body">
                                        <div class="row" id="searchbank" runat="server">
                                            <div class="col-lg-12">
                                                <div class="col-lg-1 form-group">
                                                    <asp:DropDownList ID="dropBank" runat="server" CssClass="form-control"
                                                        OnSelectedIndexChanged="dropBank_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2 form-group">
                                                    <label class="control-label">Records per page</label>
                                                </div>
                                                <div class="col-lg-6"></div>
                                                <div class="col-lg-3 form-group">
                                                    <input id="targetBank" type="text" class="form-control" placeholder="Text To Search" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gdvBankList" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="BankDetailID" CssClass="rounded-corners" EmptyDataText="There are no data records to display."
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" CellPadding="4" CellSpacing="2" Style="font-size: 100%;"
                                                ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gdvBankList_RowCommand" OnPageIndexChanging="gdvBankList_PageIndexChanging">
                                                <PagerStyle CssClass="pagination_grid" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BankDetail ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBankDetailID" Text='<%#Eval("BankDetailID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Trust Registration #">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBankUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trust Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblTrustName" Text='<%#Eval("TRUSTNAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client Identification #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Bank Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBankName" Text='<%#Eval("BankName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Branch Number">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBranchNumber" Text='<%#Eval("BranchNumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Account Number" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAccountNumber" Text='<%#Eval("AccountNumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Account Type" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAccountType" Text='<%#Eval("AccountType") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Currency" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblCurrency" Text='<%#Eval("Currency") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SWIFT" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSWIFT" Text='<%#Eval("SWIFT") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%-- <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/edit_new.png"
                                                                CommandName="EditBank" CommandArgument='<%#Eval("BankDetailID") %>' ToolTip="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnbankDelete" runat="server" Width="23px" Height="23px" ImageUrl="~/assets/dist/img/Delete.png"
                                                                CommandName="DeleteBank" ToolTip="Delete" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabAccountant">
                                    <div class="panel-body">
                                        <div class="row" id="searchaccountant" runat="server">
                                            <div class="col-lg-12">
                                                <div class="col-lg-1 form-group">
                                                    <asp:DropDownList ID="dropAccountant" runat="server" CssClass="form-control"
                                                        OnSelectedIndexChanged="dropAccountant_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2 form-group">
                                                    <label class="control-label">Records per page</label>
                                                </div>
                                                <div class="col-lg-6"></div>
                                                <div class="col-lg-3 form-group">
                                                    <input id="targetAccountant" type="text" class="form-control" placeholder="Text To Search" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvAccountDetails" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="AccountantID" CssClass="rounded-corners" EmptyDataText="There are no data records to display."
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" CellPadding="4" CellSpacing="2" Style="font-size: 100%;"
                                                ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvAccountDetails_RowCommand" OnPageIndexChanging="gvAccountDetails_PageIndexChanging">
                                                <PagerStyle CssClass="pagination_grid" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Accountant ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAccountantID" Text='<%#Eval("AccountantID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Trust Registration #">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trust Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblTrustName" Text='<%#Eval("TrustName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client Identification #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Accountant Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAccountantName" Text='<%#Eval("AccountantName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Telephone Number">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAccountantTelNum" Text='<%#Eval("AccountantTelNum") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="AccountantEmail" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAccountantEmail" Text='<%#Eval("AccountantEmail") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="AccountantType" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAccountantType" Text='<%#Eval("Type") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Account UICNo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblAccountUICNo" Text='<%#Eval("UICNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabPrivateBanker">
                                    <div class="panel-body">
                                        <div class="row" id="searchprivatebank" runat="server">
                                            <div class="col-lg-12">
                                                <div class="col-lg-1 form-group">
                                                    <asp:DropDownList ID="dropPrivateBank" runat="server" CssClass="form-control"
                                                        OnSelectedIndexChanged="dropPrivateBank_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2 form-group">
                                                    <label class="control-label">Records per page</label>
                                                </div>
                                                <div class="col-lg-6"></div>
                                                <div class="col-lg-3 form-group">
                                                    <input id="targetPrivateBank" type="text" class="form-control" placeholder="Text To Search" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvPrivateBank" runat="server" Width="100%"
                                                AutoGenerateColumns="False" DataKeyNames="PrivateBankID" CssClass="rounded-corners" EmptyDataText="There are no data records to display."
                                                BorderStyle="Solid" BorderWidth="0px" AllowPaging="true" PageSize="5" CellPadding="4" CellSpacing="2" Style="font-size: 100%;"
                                                ForeColor="Black" HeaderStyle-BackColor="#e8f1f3" OnRowCommand="gvPrivateBank_RowCommand" OnPageIndexChanging="gvPrivateBank_PageIndexChanging">
                                                <PagerStyle CssClass="pagination_grid" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PrivateBank ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblPrivateBankID" Text='<%#Eval("PrivateBankID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Trust Registration #">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblUIC" Text='<%#Eval("UIC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trust Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblTrustName" Text='<%#Eval("TrustName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Client Identification #" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblReferenceSAID" Text='<%#Eval("ReferenceSAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Bank Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblPrivateBankName" Text='<%#Eval("PrivateBankName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Contact Number">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblPrivateContactNum" Text='<%#Eval("PrivateContactNum") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Banker UICNo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBankerUICNo" Text='<%#Eval("UICNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
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

        <!-- /.content -->


        <div class="modal fade" id="bankPopup" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header modal-header-primary">
                        <h3><i class="fa fa-bank m-r-5" id="bankmessage" runat="server"></i></h3>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <asp:UpdatePanel ID="upBank" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="col-md-12 form-group user-form-group">
                                                <div class="panel-body">
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Trust Reg No.</label>
                                                            <asp:TextBox ID="txtTrustUIC" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-8 form-group">
                                                            <label class="control-label">Trust Name</label>
                                                            <asp:TextBox ID="txtTrustNameBank" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Bank Name</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtBankName" runat="server" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBankName" Display="Dynamic" ErrorMessage="Enter Bank Name"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Branch Number</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtBranchNumber" runat="server" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBranchNumber" Display="Dynamic" ErrorMessage="Enter Branch Number"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Account Number</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtAccountNumber" runat="server" class="form-control"></asp:TextBox>
                                                            <asp:Label ID="lblBankMsg" runat="server" ForeColor="Red"></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAccountNumber" Display="Dynamic" ErrorMessage="Enter Account Number"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>

                                                    </div>

                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Account Type</label><span class="style1">*</span>
                                                            <asp:DropDownList ID="ddlAccountType" runat="server" class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlAccountType" Display="Dynamic" ErrorMessage="Please select Account Type"
                                                                ValidationGroup="Bank" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Currency</label><%--<span class="style1">*</span>--%>
                                                            <asp:TextBox ID="txtCurrency" runat="server" class="form-control"></asp:TextBox>
                                                            <%-- <asp:RequiredFieldValidator ID="rfvCurrency" runat="server" ControlToValidate="txtCurrency" Display="Dynamic" ErrorMessage="Enter Currency"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Swift</label><%--<span class="style1">*</span>--%>
                                                            <asp:TextBox ID="txtSwift" runat="server" class="form-control"></asp:TextBox>
                                                            <%-- <asp:RequiredFieldValidator ID="rfvtxtSwift" runat="server" ControlToValidate="txtSwift" Display="Dynamic" ErrorMessage="Enter Swift"
                                                                ValidationGroup="Bank" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <asp:Button ID="btnBankSubmit" runat="server" Text="Submit" ValidationGroup="Bank" CssClass="btn btn-primary" OnClick="btnBankSubmit_Click"></asp:Button>
                        <%--                        <asp:Button ID="btnUpdateBank" runat="server" Text="Update" ValidationGroup="Bank" CssClass="btn btn-primary" OnClick="btnUpdateBank_Click"></asp:Button>--%>
                        <asp:Button ID="btnBankCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnBankCancel_Click"></asp:Button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>

        <div class="modal fade" id="addressPopup" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header modal-header-primary">
                        <h3><i class="fa fa-home m-r-5" id="addressmessage" runat="server"></i></h3>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <div class="col-md-12 form-group user-form-group">
                                        <div class="panel-body">
                                            <div class="col-sm-12">
                                                <div class="col-sm-4">
                                                    <label class="control-label">Registration #</label>
                                                    <asp:TextBox ID="txtUICAddress" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-8 form-group">
                                                    <label class="control-label">Trust Name</label>
                                                    <asp:TextBox ID="txtTrustNameAddress" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="col-sm-12">

                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">House No</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtHouseNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvHouseNo" runat="server" ControlToValidate="txtHouseNo" Display="Dynamic" ErrorMessage="Enter House Number"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Building Name</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtBulding" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvBulding" runat="server" ControlToValidate="txtBulding" Display="Dynamic" ErrorMessage="Enter Building name"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Floor</label>
                                                    <asp:TextBox ID="txtFloor" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>

                                            <div class="col-sm-12">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Flat No</label>
                                                    <asp:TextBox ID="txtFlatNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Road Name</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtRoadName" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRoadName" Display="Dynamic" ErrorMessage="Enter Road Name"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Road No</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtRoadNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRoadNo" Display="Dynamic" ErrorMessage="Enter Road No"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>

                                            <div class="col-sm-12">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Suburb Name</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtSuburbName" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtSuburbName" Display="Dynamic" ErrorMessage="Enter Suburb Name"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">City</label><span class="style1">*</span>
                                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlCity" Display="Dynamic" ErrorMessage="Please select City"
                                                        ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Postal Code</label><span class="style1">*</span>
                                                    <asp:TextBox ID="txtPostalCode" CssClass="form-control" runat="server" MaxLength="6"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPostalCode" Display="Dynamic" ErrorMessage="Enter Postal Code"
                                                        ValidationGroup="Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Province</label><span class="style1">*</span>
                                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlProvince" Display="Dynamic" ErrorMessage="Please select Province"
                                                        ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label">Country</label><span class="style1">*</span>
                                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Please select Country"
                                                        ValidationGroup="Address" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <asp:Button ID="btnAddressSubmit" runat="server" Text="Submit" ValidationGroup="Address" CssClass="btn btn-primary" OnClick="btnAddressSubmit_Click"></asp:Button>
                        <%--                        <asp:Button ID="btnUpdateAddress" runat="server" Text="Update" ValidationGroup="Address" CssClass="btn btn-primary" OnClick="btnUpdateAddress_Click"></asp:Button>--%>
                        <asp:Button ID="btnAddressCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnAddressCancel_Click"></asp:Button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <div class="modal fade" id="accountantPopup" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header modal-header-primary">
                        <h3><i class="fa fa-bank m-r-5" id="accountmessage" runat="server"></i></h3>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="col-md-12 form-group user-form-group">
                                                <div class="panel-body">
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Trust Reg No.</label>
                                                            <asp:TextBox ID="txtaccTrustRegNum" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-8 form-group">
                                                            <label class="control-label">Trust Name</label>
                                                            <asp:TextBox ID="txtaccTrustName" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Accountant Name</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtAccountantName" runat="server" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtAccountantName" runat="server" ControlToValidate="txtAccountantName" Display="Dynamic" ErrorMessage="Enter Accountant Name"
                                                                ValidationGroup="Account" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Telephone Num</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtAccTelNum" runat="server" class="form-control" MaxLength="10"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtAccTelNum" runat="server" ControlToValidate="txtAccTelNum" Display="Dynamic" ErrorMessage="Enter Telephone Num"
                                                                ValidationGroup="Account" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revtxtAccTelNum" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                                ControlToValidate="txtAccTelNum" ForeColor="Red" ValidationGroup="Account"></asp:RegularExpressionValidator>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Email ID</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtAccEmailId" runat="server" class="form-control"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtAccEmailId" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please check Email Format"
                                                                ControlToValidate="txtAccEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Account">
                                                            </asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="rfvtxtAccEmailId" runat="server" ControlToValidate="txtAccEmailId" Display="Dynamic" ErrorMessage="Enter Email ID"
                                                                ValidationGroup="Account" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <asp:Button ID="btnAccountSubmit" runat="server" Text="Submit" ValidationGroup="Account" CssClass="btn btn-primary" OnClick="btnAccountSubmit_Click"></asp:Button>
                        <asp:Button ID="btnAccountantCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnAccountantCancel_Click"></asp:Button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <div class="modal fade" id="PrivateBankerPopup" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header modal-header-primary">
                        <h3><i class="fa fa-bank m-r-5" id="bankermessage" runat="server"></i></h3>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="col-md-12 form-group user-form-group">
                                                <div class="panel-body">
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Trust Reg No.</label>
                                                            <asp:TextBox ID="txtBankerTrustRegNo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-8 form-group">
                                                            <label class="control-label">Trust Name</label>
                                                            <asp:TextBox ID="txtBankerTrustname" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Bank Name</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtPrivBankName" runat="server" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtPrivBankName" runat="server" ControlToValidate="txtPrivBankName" Display="Dynamic" ErrorMessage="Enter Bank Name"
                                                                ValidationGroup="Banker" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Contact Number</label><span class="style1">*</span>
                                                            <asp:TextBox ID="txtPrivBankTelNum" runat="server" class="form-control" MaxLength="10"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtxtPrivBankTelNum" runat="server" ControlToValidate="txtPrivBankTelNum" Display="Dynamic" ErrorMessage="Enter Contact Number"
                                                                ValidationGroup="Banker" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revtxtPrivBankTelNum" runat="server" ErrorMessage="Please enter 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic"
                                                                ControlToValidate="txtPrivBankTelNum" ForeColor="Red" ValidationGroup="Banker"></asp:RegularExpressionValidator>
                                                        </div>



                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <asp:Button ID="btnBankerSubmit" runat="server" Text="Submit" ValidationGroup="Banker" CssClass="btn btn-primary" OnClick="btnBankerSubmit_Click"></asp:Button>
                        <asp:Button ID="btnBankerCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnBankerCancel_Click"></asp:Button>
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


        <div class="modal fade" id="validatepopup" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header modal-header-primary">
                        <h3><i class="fa fa-home m-r-5" id="validatemessage" runat="server"></i></h3>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-12 form-group user-form-group">
                                                <div class="panel-body">
                                                    <div class="col-md-12">
                                                        <div class="form-group col-sm-4">
                                                            <div class="col-sm-11" style="padding: 0px;">
                                                                <label class="control-label">Registration #</label>
                                                                <asp:TextBox ID="txtvalidUIC" CssClass="form-control" runat="server" MaxLength="13"
                                                                    ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="form-group col-sm-4">
                                                            <label class="control-label">Trust Name</label>
                                                            <asp:TextBox ID="txtvalidTrustName" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-sm-4">
                                                            <label class="control-label">Year of Foundation</label>
                                                            <asp:TextBox ID="txtvalidYearOfFoundation" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <div class="form-group col-sm-4">
                                                            <label class="control-label">Income Tax </label>
                                                            <asp:TextBox ID="txtvalidIncomeTax" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-sm-4">
                                                            <label class="control-label">Telephone</label>
                                                            <asp:TextBox ID="txtvalidTelephone" CssClass="form-control" MaxLength="10" runat="server" ReadOnly="true"></asp:TextBox>

                                                        </div>
                                                        <div class="form-group col-sm-4">
                                                            <label class="control-label">Email Id</label>
                                                            <asp:TextBox ID="txtvalidEmail" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <div class="form-group col-sm-4">
                                                            <label class="control-label">Website</label>
                                                            <asp:TextBox ID="txtvalidWebsite" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                        <asp:Button ID="btnValidOK" runat="server" Text="Validate" CssClass="btn btn-primary" OnClick="btnValidOK_Click" />
                        <asp:Button ID="btnValidCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnValidCancel_Click"></asp:Button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>

        <%--<div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-hidden="true">
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
        </div>--%>
    </div>

    <script type="text/javascript">
        $(document).ready(function (event) {
            $("#ContentPlaceHolder1_txtUIC,#ContentPlaceHolder1_txtTaxRef,#ContentPlaceHolder1_txtTelephone,#ContentPlaceHolder1_txtFax,#ContentPlaceHolder1_txtPostalCode,#ContentPlaceHolder1_txtAccountNumber,#ContentPlaceHolder1_txtAccTelNum,#ContentPlaceHolder1_txtPrivBankTelNum").bind('keypress', function (e) {
                if (e.keyCode == '9' || e.keyCode == '16') {
                    return;
                }
                var code;
                if (e.keyCode) code = e.keyCode;
                else if (e.which) code = e.which;
                if (e.which == 46)
                    return false;
                if (code == 8 || code == 46)
                    return true;
                if (code < 48 || code > 57)
                    return false;
            });
            $("#ContentPlaceHolder1_txtUIC,#ContentPlaceHolder1_txtTaxRef,#ContentPlaceHolder1_txtTelephone,#ContentPlaceHolder1_txtFax,#ContentPlaceHolder1_txtPostalCode,#ContentPlaceHolder1_txtAccountNumber,#ContentPlaceHolder1_txtAccTelNum,#ContentPlaceHolder1_txtPrivBankTelNum").bind('mouseenter', function (e) {
                var val = $(this).val();
                if (val != '0') {
                    val = val.replace(/[^0-9]+/g, "");
                    $(this).val(val);
                }
            });
        })
    </script>
    <script type="text/javascript">
        function openModal() {
            $('#ContentPlaceHolder1_Success').modal('show', { backdrop: 'static' });
        }
        function openBankModal() {
            $('#ContentPlaceHolder1_bankPopup').modal('show', { backdrop: 'static' });
        }
        function openAddressModal() {
            $('#ContentPlaceHolder1_addressPopup').modal('show', { backdrop: 'static' });
        }
        function openAccountantModal() {
            $('#ContentPlaceHolder1_accountantPopup').modal('show', { backdrop: 'static' });
        }
        function openPrivateBankerModal() {
            $('#ContentPlaceHolder1_PrivateBankerPopup').modal('show', { backdrop: 'static' });
        }
        function openValidateModal() {
            $('#ContentPlaceHolder1_validatepopup').modal('show');
        }
        //function openDeleteModal() {
        //    $('#delete').modal('show', { backdrop: 'static' });
        //}
    </script>
    <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "tabTrust";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });
    </script>
</asp:Content>

