app.controller('newClientController', ['$scope', 'CrudService', function ($scope, CrudService) {
    var SAID = '',GetDetailsSAID='';
    $scope.dtInstance = {};
    debugger;


    //Update client
    $scope.Update = function (client) {

        debugger;
        // Base Url 
     //   client.VerifiedBy = $scope.selectedOption;
     //   client.Status = $scope.selectedStatus;
       
        var apiRoute = 'http://localhost:17746/api/ClientRegistration/' + client.SAID;

        var saveUser = CrudService.put(apiRoute, client);
        saveUser.then(function (response) {
           
            $scope.successMessage = "Form Updated successfully";
            $scope.successMessagebool = true;
            $scope.PopupClear();

        }, function (error) {
            console.log("Error: " + error);
        });
    }


    //clear
    $scope.Clear = function () {
        $scope.Title = "";
        $scope.FirstName = "";
        $scope.LastName = "";
        $scope.SAID = "";
        $scope.Company = "";
        $scope.CompanyRegNo = "";
        $scope.Mobile = "";
        $scope.EmailId = "";
        $scope.VerifiedOn = "";
    }

    $scope.PopupClear = function () {
        $scope.client.Title = "";
        $scope.client.FirstName = "";
        $scope.client.LastName = "";
        $scope.client.SAID = "";
        $scope.client.Company = "";
        $scope.client.CompanyRegNo = "";
        $scope.client.Mobile = "";
        $scope.client.EmailId = "";
        $scope.client.VerifiedOn = "";
    }


    //Clients List
    $scope.ClientList = function () {
        
        var apiRoute = 'http://localhost:17746/api/GetClient';
            var student = CrudService.getAll(apiRoute);
            student.then(function (response) {
                debugger

                $scope.ClientList = response.data;

            },

        function (error) {
            console.log("Error: " + error);
        });
         
    }
    $scope.ClientList();


    //Delete client
    $scope.Delete = function (client) {
        var apiRoute = 'http://localhost:17746/api/ClientRegistration/' + client.SAID;
        CrudService.put(apiRoute,client);
        $scope.client.Status = '4';
        $scope.successMessage = "Client Deleted successfully";
        $scope.successMessagebool = true;
    }

    //Update status
    $scope.StatusUpdate = function (client) {
        var apiRoute = 'http://localhost:17746/api/ClientRegistration/' + client.SAID;
        CrudService.put(apiRoute, client);
        $scope.client.Status = $scope.selectedStatus;
        $scope.successMessage = "Form Updated successfully";
        $scope.successMessagebool = true;
    }


    //Update Advisor name
    $scope.AdvisorUpdate = function () {
        var client = {
            VerifiedOn: $scope.VerifiedOn,
            VerifiedBy : $scope.selectedAdvisor,
            VerifiedThough: $scope.VerifiedThrough,
            SAID: SAID,
            Title: $scope.client.Title,
            FirstName: $scope.client.FirstName,
            LastName: $scope.client.LastName,
            EmailID: $scope.client.EmailID,
            MobileNumber: $scope.client.MobileNumber,
            CompanyName: $scope.client.CompanyName,
            CompanyRegNo: $scope.client.CompanyRegNo,
            TrustName: $scope.client.TrustName,
            TrustRegNo: $scope.client.TrustRegNo,
            Status: $scope.client.Status
        }
        var apiRoute = 'http://localhost:17746/api/ClientRegistration/' + SAID;
        
        CrudService.put(apiRoute, client);
        var Feedback = {
            AdvisorID: $scope.client.VerifiedBy,
            AdvisorFeedBack: $scope.AdvisorFeedback,
            ClientSAID : SAID
        }
        CrudService.post('http://localhost:17746/api/FeedBack', Feedback)
        $scope.successMessage = "Form Updated successfully";
        $scope.successMessagebool = true;
    }


    //Get by ID
    $scope.GetDetails = function (client) {
        debugger
        var apiRoute = 'http://localhost:17746/api/ClientRegistration';
        GetDetailsSAID = client.SAID;
        var showclient = CrudService.getbyID(apiRoute, GetDetailsSAID);
        showclient.then(function (response) {
            if (response.data != "") {
                $scope.client = response.data;
               $scope.SAID = client.SAID;
                $scope.successMessagebool = false;

            } else {
                alert("Some error");
            }

        }, function (error) {
            console.log("Error: " + error);
        });
    }

    //Get by Name

    $scope.GetByName = function (client) {
        debugger
        var apiRoute = 'http://localhost:17746/api/ClientRegistration';
        SAID = client.SAID;
        var showclient = CrudService.getbyID(apiRoute, SAID);
        showclient.then(function (response) {
            if (response.data != "") {
                $scope.client = response.data;
                $scope.selectedAdvisor = $scope.client.VerifiedBy;
                $scope.VerifiedThrough = $scope.client.VerifiedThough;
                if ($scope.client.VerifiedOn == null) {
                    $scope.VerifiedOn = new Date();
                }
                else {
                    $scope.VerifiedOn = new Date($scope.client.VerifiedOn);
                }
            } else {
                $scope.selectedOption = "";
            }

        }, function (error) {
            console.log("Error: " + error);
        });
    }

    //Get Status By ID
    $scope.GetStatusByID = function (client) {
        debugger
        var apiRoute = 'http://localhost:17746/api/ClientRegistration';
        var ID = client.SAID;

        var showStatus = CrudService.getbyID(apiRoute, ID);
        showStatus.then(function (response) {
            if (response.data != "") {
                $scope.client = response.data;
                $scope.selectedStatus = $scope.client.Status;
            } else {
                $scope.selectedStatus = "";
            }

        }, function (error) {
            console.log("Error: " + error);
        });
    }

    //close
    $scope.Close = function () {
        //$scope.ClientList();
        location.reload();
    }

    //Getting Advisors
    $scope.Advisors = function () {
        var apiRoute = 'http://localhost:17746/api/Advisor';
        var student = CrudService.getAll(apiRoute);
        student.then(function (response) {
            debugger
            $scope.Advisors = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.Advisors();

    //Get Status
    $scope.Statues = function () {
        var apiRoute = 'http://localhost:17746/api/ClientRegStatus';
        var status = CrudService.getAll(apiRoute);
        status.then(function (response) {
            $scope.Statues = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.Statues();



    //Save client Feedback
    $scope.SaveFeedback = function () {
        debugger;
        var Feedback = {
            AdvisorID:$scope.client.VerifiedBy,
            ClientSAID: GetDetailsSAID,
            ClientFeedBack: $scope.ClientFeedBack
        }
        // Base Url 
        var apiRoute = 'http://localhost:17746/api/FeedBack';
        var saveUser = CrudService.post(apiRoute, Feedback);
        saveUser.then(function (response) {
            if (response.data != "") {
                $scope.successMessage = "Form Updated successfully";
                $scope.successMessagebool = true;
            }
        }, function (error) {
            console.log("Error: " + error);
        });
    }
}]);
