app.controller('newClientController', ['$scope', 'CrudService', function ($scope, CrudService) {
    $scope.dtInstance = {};
    debugger;


    // Save user
    $scope.Save = function () {
        debugger;
        var client = {
            Title:$scope.Title,
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            SAId: $scope.SAId,
            Company: $scope.Company,
            CompanyRegNo: $scope.CompanyRegNo,
            Mobile: $scope.Mobile,
            EmailId: $scope.EmailId          
        }
        if (CrudService.post) {
            client.Status= '1';
        }
        // Base Url 

        var apiRoute = 'http://localhost:17746/api/ClientRegistration';

        var saveUser = CrudService.post(apiRoute, client);
        saveUser.then(function (response) {
            if (response.data != "") {
                alert("Data Saved Successfully");
                $scope.Clear();
            } else {
                alert("Some error");
            }

        }, function (error) {
            console.log("Error: " + error);
        });        
    }


  //Update client
    $scope.Update = function (client) {
        client.VerifiedBy = client.AdvisorId;
        client.Status = client.StatusID;
        debugger;
        // Base Url 

        var apiRoute = 'http://localhost:17746/api/ClientRegistration/' + client.ClientID;

        var saveUser = CrudService.put(apiRoute, client);
        saveUser.then(function (response) {
            $scope.successMessage = "Form Updated successfully";
            $scope.successMessagebool = true;
            //$scope.ClientList();
            // $window.location.reload();
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
        $scope.SAId = "";
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
        $scope.client.SAId = "";
        $scope.client.Company = "";
        $scope.client.CompanyRegNo = "";
        $scope.client.Mobile = "";
        $scope.client.EmailId = "";
        $scope.client.VerifiedOn = "";
    }


    //Clients List
    $scope.ClientList = function () {
        var apiRoute = 'http://localhost:17746/api/ClientRegistration';
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


    //$scope.ActiveStatues = function () {
    //    var apiRoute = 'http://localhost:17746/api/Status';
    //    var status = CrudService.getAll(apiRoute);
    //    status.then(function (response) {
    //        debugger
    //        $scope.ActiveStatues = response.data;
    //    },
    //function (error) {
    //    console.log("Error: " + error);
    //});
    //}
    //$scope.ActiveStatues();



//Delete client
    $scope.Delete = function (client) {
        debugger
        var ID=client.ClientID;
        var apiRoute = 'http://localhost:17746/api/ClientRegistration/' + ID;
        var deleteclient = CrudService.delete(apiRoute);
        deleteclient.then(function (response) {
            if (response.data != "") {             
                location.reload();
                //$scope.Clear();
            } else {
                alert("Some error");
            }

        }, function (error) {
            console.log("Error: " + error);
        });
    }


    //Get by ID
    $scope.GetDetails = function (client) {
        debugger
        var apiRoute = 'http://localhost:17746/api/ClientRegistration';
        var ID = client.ClientID;
       
        var showclient = CrudService.getbyID(apiRoute,ID);
        showclient.then(function (response) {
            if (response.data != "") {
                $scope.client = response.data;
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
        var ID = client.ClientID;
        var showclient = CrudService.getbyID(apiRoute, ID);
        showclient.then(function (response) {
            if (response.data != "") {
                $scope.client = response.data;
                $scope.selectedOption = $scope.client.VerifiedBy;
                if ($scope.client.VerifiedOn == null) {
                    $scope.VerifiedOn = new Date();
                }
                else {
                    $scope.client.VerifiedOn = new Date($scope.client.VerifiedOn);
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
        var ID = client.ClientID;
        
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
    $scope.close = function () {
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
        var apiRoute = 'http://localhost:17746/api/Status';
        var status = CrudService.getAll(apiRoute);
        status.then(function (response) {
            $scope.Statues = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.Statues();
}]);
