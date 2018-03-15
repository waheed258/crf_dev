app.controller('AdvisorController', ['$scope', 'CrudService', function ($scope, CrudService) {

    //Save A Record
    $scope.Save = function () {
        var advisor = {
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            MobileNumber: $scope.MobileNumber,
            PhoneNumber: $scope.PhoneNumber,
            EmailId: $scope.EmailId,
            LoginId: $scope.LoginId,
            Password: $scope.Password,
            Designation: $scope.Designation,
            Branch: $scope.Branch,
            AdvisorType: $scope.AdvisorType,
            Status: $scope.Status,
            AdvisorRole: $scope.AdvisorRole
            //UserImage: $scope.UserImage,
        }

        if (CrudService.post) {
            advisor.DeleteFlag = '1';
        }

        var apiRoute = 'http://localhost:17746/api/Advisor';
        var saveAdvisor = CrudService.post(apiRoute, advisor);
        saveAdvisor.then(function (response) {
            if (response.data != "") {
                $scope.successMessage = "Form Saved successfully";
                $scope.successMessagebool = true;
                $scope.Clear();
            } else {
                alert("Some error");
            }
        }, function (error) {
            console.log("Error: " + error);
        });


    }

    //Clear the data
    $scope.Clear = function () {
        $scope.FirstName = "";
        $scope.LastName = "";
        $scope.MobileNumber = "";
        $scope.PhoneNumber = "";
        $scope.EmailId = "";
        $scope.LoginId = "";
        $scope.Password = "";
        $scope.Designation = "";
        $scope.Branch = "";
        $scope.AdvisorType = "";
        $scope.Status = "";
        $scope.ConfirmPassword = "";
        $scope.AdvisorRole = ""
    }


    //GetList
    $scope.AdvisorList = function () {
        var apiRoute = 'http://localhost:17746/api/Advisor';
        var student = CrudService.getAll(apiRoute);
        student.then(function (response) {
            $scope.AdvisorList = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.AdvisorList();


    //Get Advisor Types
    $scope.AdvisorTypes = function () {
        var apiRoute = 'http://localhost:17746/api/AdvisorType';
        var usertype = CrudService.getAll(apiRoute);
        usertype.then(function (response) {
            $scope.AdvisorTypes = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.AdvisorTypes();


    //GetStatus
    $scope.Statues = function () {
        var apiRoute = 'http://localhost:17746/api/AdvisorStatus';
        var status = CrudService.getAll(apiRoute);
        status.then(function (response) {
            $scope.Statues = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.Statues();

    //Get Designation
    $scope.Designations = function () {
        var apiRoute = 'http://localhost:17746/api/Destination';
        var status = CrudService.getAll(apiRoute);
        status.then(function (response) {
            $scope.Designations = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.Designations();

    //Get Branch
    $scope.Branchs = function () {
        var apiRoute = 'http://localhost:17746/api/Branch';
        var status = CrudService.getAll(apiRoute);
        status.then(function (response) {
            $scope.Branchs = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.Branchs();


    //Get Role
    $scope.AdvisorRoles = function () {
        var apiRoute = 'http://localhost:17746/api/RoleMaster';
        var role = CrudService.getAll(apiRoute);
        role.then(function (response) {
            $scope.AdvisorRoles = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.AdvisorRoles();

    //Delete a Record
    $scope.Delete = function (Advisor) {
        var apiRoute = 'http://localhost:17746/api/Advisor/' + Advisor.AdvisorId
        var deleteAdvisor = CrudService.delete(apiRoute);
        deleteAdvisor.then(function (response) {
            if (response.data != "") {
                location.reload();
                // alert("Data Delete Successfully");                
            } else {
                alert("Some error");
            }
        }, function (error) {
            console.log("Error: " + error);
        });
    }

    //To get Details of Particular record
    $scope.GetDetails = function (Advisor) {

        var apiRoute = 'http://localhost:17746/api/Advisor';
        var ID = Advisor.AdvisorId;
        var showAdvisor = CrudService.getbyID(apiRoute, ID);
        showAdvisor.then(function (response) {
            if (response.data != "") {
                $scope.Advisor = response.data;
                $scope.successMessagebool = false;
                $scope.DestinationSelected = $scope.Advisor.Designation;
                $scope.BranchSelected = $scope.Advisor.Branch;
                $scope.AdvisorSelected = $scope.Advisor.AdvisorType;
                $scope.StatusSelected = $scope.Advisor.Status;
                $scope.RoleSelected = $scope.Advisor.AdvisorRole;

            } else {
                alert("Some error");
            }

        }, function (error) {
            console.log("Error: " + error);
        });
    }

    $scope.Update = function (Advisor) {
        Advisor.Designation = $scope.DestinationSelected
        Advisor.Branch = $scope.BranchSelected
        Advisor.Status = $scope.StatusSelected
        Advisor.AdvisorType = $scope.AdvisorSelected
        Advisor.AdvisorRole = $scope.RoleSelected
        var apiRoute = 'http://localhost:17746/api/Advisor/' + Advisor.AdvisorId;
        var saveAdvisor = CrudService.put(apiRoute, Advisor);
        saveAdvisor.then(function (response) {
            $scope.successMessage = "Form Updated successfully";
            $scope.successMessagebool = true;
            $scope.PopupClear();

        }, function (error) {
            console.log("Error: " + error);
        });
    }

    $scope.PopupClear = function () {
        $scope.Advisor.FirstName = "";
        $scope.Advisor.LastName = "";
        $scope.Advisor.MobileNumber = "";
        $scope.Advisor.PhoneNumber = "";
        $scope.Advisor.EmailId = "";
        $scope.Advisor.LoginId = "";
        $scope.Advisor.Password = "";
        $scope.DestinationSelected = "";
        $scope.BranchSelected = "";
        $scope.AdvisorSelected = "";
        $scope.StatusSelected = "";
        $scope.RoleSelected = ""
    }

    $scope.Close = function () {
        location.reload();
    }

}]);