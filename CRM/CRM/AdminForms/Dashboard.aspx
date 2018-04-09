<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="AdminForms_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="header-icon">
                <i class="fa fa-dashboard"></i>
            </div>
            <div class="header-title">
                <h1>CRM Admin Dashboard</h1>
                <small>Very detailed & featured admin.</small>
            </div>
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-3">
                    <ul style="list-style-type: none">
                        <li>
                            <a href="NewAdvisor.aspx">
                                <div id="cardbox1">
                                    <div class="statistic-box">
                                        <i class="fa fa-user-plus fa-3x"></i>
                                        <h3>Add Advisor</h3>
                                    </div>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-3">
                    <ul style="list-style-type: none">
                        <li>
                            <a href="AdvisorList.aspx">
                                <div id="cardbox2">
                                    <div class="statistic-box">
                                        <i class="fa fa-user-secret fa-3x"></i>
                                        <h3>List of Advisors</h3>
                                    </div>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-3">
                    <ul style="list-style-type: none">
                        <li>
                            <a href="ClientList.aspx">
                                <div id="cardbox3">
                                    <div class="statistic-box">
                                        <i class="fa fa-user-secret fa-3x"></i>

                                        <h3>Registered Clients</h3>
                                    </div>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-3">
                    <ul style="list-style-type: none">
                        <li>
                            <a href="#">
                                <div id="cardbox4">
                                    <div class="statistic-box">
                                        <i class="fa fa-files-o fa-3x"></i>
                                        <h3>Service Requests</h3>
                                    </div>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>

        </section>
        <!-- /.content -->
    </div>
</asp:Content>

