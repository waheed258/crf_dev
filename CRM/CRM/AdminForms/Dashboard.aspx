<%@ Page Title="" Language="C#" MasterPageFile="~/AdminForms/Layout.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="AdminForms_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

     <script src="../assets/plugins/jQuery/jquery-1.12.4.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

    <script type="text/javascript">

        var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

        function daysInThisMonth(month) {
            var now = new Date();
            return new Date(now.getFullYear(), month, 0).getDate();
        }

        $(function () {

            var d = new Date();
            var crrMonth = d.getMonth() + 1;
            $('#ddlMonth').val(crrMonth);
            getDashboardData(crrMonth, 1);
            $('#ddlPropMonth').val(crrMonth);
            getDashboardData(crrMonth, 2);


            $('#ddlMonth').change(function () {
                var value = $(this).val();
                getDashboardData(value, 1);
            });

            $('#ddlPropMonth').change(function () {
                var value = $(this).val();
                getDashboardData(value, 2);
            });

            function getDashboardData(month, type) {
                $.ajax({
                    type: "POST",
                    url: "/AdminForms/Dashboard.aspx/getData",
                    data: '{strMonth: "' + month + '",strType: "' + type + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var dashboardInfo = response.d;
                        Dashboard(dashboardInfo, type);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }


            var arrDashboard = [];
            function Dashboard(serviceData, type) {

                var monthName = $('#ddlMonth').val();
                var arrData = [];
                arrDashboard = [];

                var info = JSON.parse(serviceData);

                for (var i = 0; i < info.length; i++) {
                    arrData.push({ day: info[i].DAY, count: info[i].CNT, date: info[i].DATE });
                }

                var days = daysInThisMonth(monthName);
                var arrLabels = [];
                for (var j = 1; j <= days; j++) {
                    arrLabels[j] = j.toString();
                }

                // Data Available for the month
                if (arrData.length > 0) {
                    for (var k = 1; k <= arrLabels.length - 1; k++) {
                        for (var l = 0; l < arrData.length; l++) {
                            var cnt = l;
                            if (arrLabels[k] == arrData[l].day) {
                                arrDashboard[k] = [k + " - " + monthNames[monthName - 1], arrData[l].count, "#4285f4"]; // arrData[l].count;
                            } else {
                                if (l == 0)
                                    arrDashboard[k] = [k + " - " + monthNames[monthName - 1], 0, "#4285f4"]; //0;
                            }
                        }
                    }
                } else {
                    alert('There is no Service Requests for this month.');
                    // Data Not Available for the month
                    for (var k = 1; k <= arrLabels.length - 1; k++) {
                        arrDashboard[k] = [k + " - " + monthNames[monthName - 1], 0, "#4285f4"]; //0;                       
                    }
                }

                google.charts.load("current", { packages: ['corechart'] });
                if (type == 1) {
                    google.charts.setOnLoadCallback(drawChart);
                } else {
                    google.charts.setOnLoadCallback(proposaldrawChart);
                }


            }

            function drawChart() {
                arrDashboard[0] = ["Element", "Service Requests", { role: "style" }];

                var data = google.visualization.arrayToDataTable(arrDashboard);

                //var data = google.visualization.arrayToDataTable([
                //  ["Element", "Density", { role: "style" }],
                //  ["Copper", 1, "#4285f4"],
                //  ["Silver", 5, "#4285f4"],
                //  ["Gold", 2, "#4285f4"],
                //  ["Platinum", 30, "color: #4285f4"]
                //]);

                var view = new google.visualization.DataView(data);
                view.setColumns([0, 1,
                                 {
                                     calc: "stringify",
                                     sourceColumn: 1,
                                     type: "string",
                                     role: "annotation"
                                 },
                                 2]);

                var options = {
                    //title: "Outstanding Service Requests",
                    width: 1050,
                    height: 350,
                    bar: { groupWidth: "150%" },
                    legend: { position: "none" },
                    vAxis: {
                        minValue: 0,
                        viewWindow: {
                            min: 0
                        }
                    }
                };
                var chart = new google.visualization.ColumnChart(document.getElementById("columnchart_values"));

                chart.draw(view, options);
            }

            function proposaldrawChart() {
                arrDashboard[0] = ["Element", "Proposal Requests", { role: "style" }];

                var data = google.visualization.arrayToDataTable(arrDashboard);

                var view = new google.visualization.DataView(data);
                view.setColumns([0, 1,
                                 {
                                     calc: "stringify",
                                     sourceColumn: 1,
                                     type: "string",
                                     role: "annotation"
                                 },
                                 2]);

                var options = {
                    //title: "Outstanding Service Requests",
                    width: 1050,
                    height: 350,
                    bar: { groupWidth: "150%" },
                    legend: { position: "none" },
                    vAxis: {
                        minValue: 0,
                        viewWindow: {
                            min: 0
                        }
                    }
                };
                var chart = new google.visualization.ColumnChart(document.getElementById("proposal_chart"));

                chart.draw(view, options);
            }

        });


    </script>


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

                 <%-- chart code--%>

                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="width:97.3%">
                         <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="background-color:#e8f1f3;font-weight:bold"><h4>Outstanding Service Requests</h4></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="background-color:#ffffff;">
                            <div class="col-md-5"></div>
                            <div class="col-md-2 text-center">
                                <strong>Select Month</strong>                               
                                <select id="ddlMonth" class="form-control">
                                    <option value="1">January</option>
                                    <option value="2">February</option>
                                     <option value="3">March</option>
                                    <option value="4">April</option>
                                    <option value="5">May</option>
                                     <option value="6">June</option>
                                    <option value="7">July</option>
                                    <option value="8">August</option>
                                    <option value="9">September</option>
                                    <option value="10">October</option>
                                    <option value="11">November</option>
                                    <option value="12">December</option>
                                </select>
                            </div>
                            <div class="col-md-5"></div>                           
                        </div>
                        
                    </div>
                   <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="min-height:400px;">
                    <div id="columnchart_values" style="height: 300px;"></div>
                </div>
                </div>
                
                 <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="width:97.3%">
                         <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="background-color:#e8f1f3;font-weight:bold"><h4>Proposal Requests</h4></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="background-color:#ffffff;">
                            <div class="col-md-5"></div>
                            <div class="col-md-2 text-center">
                                <strong>Select Month</strong>                               
                                <select id="ddlPropMonth" class="form-control">
                                    <option value="1">January</option>
                                    <option value="2">February</option>
                                     <option value="3">March</option>
                                    <option value="4">April</option>
                                    <option value="5">May</option>
                                     <option value="6">June</option>
                                    <option value="7">July</option>
                                    <option value="8">August</option>
                                    <option value="9">September</option>
                                    <option value="10">October</option>
                                    <option value="11">November</option>
                                    <option value="12">December</option>
                                </select>
                            </div>
                            <div class="col-md-5"></div>                           
                        </div>
                        
                    </div>
                   <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="min-height:400px;">
                    <div id="proposal_chart" style="height: 300px;"></div>
                </div>
                </div>


            </div>

        </section>
        <!-- /.content -->
    </div>
</asp:Content>

