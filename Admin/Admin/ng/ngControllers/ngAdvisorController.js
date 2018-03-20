app.controller('Advisor', ['$scope', 'CrudService', function ($scope, CrudService) {   
    $scope.phoneNumbr = /^\+?\d{2}[- ]?\d{3}[- ]?\d{5}$/;

    //Get Advisor Types
    $scope.AdvisorTypes = function () {
        var apiRoute = 'http://localhost:17746/api/AdvisorType';
        var usertype = CrudService.getAll(apiRoute);
        usertype.then(function (response) {
            $scope.ConsultantTypes = response.data;
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
    $scope.DesignationType = function () {
        var apiRoute = 'http://localhost:17746/api/Designation';
        var status = CrudService.getAll(apiRoute);
        status.then(function (response) {
            $scope.DesignationTypes = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.DesignationType();

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
            $scope.AdvisorRoleTypes = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.AdvisorRoles();

    //Save A Record
    $scope.Save = function () {
        var advisor = {
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            Mobile: $scope.MobileNumber,
            Phone: $scope.PhoneNumber,
            EmailId: $scope.EmailId,
            LoginId: $scope.LoginId,
            Password: $scope.Password,
            Designation: $scope.DType,
            Branch: $scope.Btype,
            AdvisorType: $scope.ConsultantType,
            Status: $scope.Status,
            AdvisorRole: $scope.RType
            //UserImage: $scope.UserImage,
        }

        var apiRoute = 'http://localhost:17746/api/Advisor';
        var saveAdvisor = CrudService.post(apiRoute, advisor);
        saveAdvisor.then(function (response) {
            if (response.data != "") {                
                $('#Success').modal('show');
                $scope.Clear();
            } else {
                $('#Failure').modal('show');
            }
        }, function (error) {
            $('#Failure').modal('show');
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
        $scope.DType = "";
        $scope.Btype = "";
        $scope.ConsultantType = "";
        $scope.Status = "";
        $scope.ConfirmPassword = "";
        $scope.RType = ""
    }


    //GetList
    $scope.AdvisorList = function () {
       
        var apiRoute = 'http://localhost:17746/api/GetActiveAdvisor';
        var student = CrudService.getAll(apiRoute);
        student.then(function (response) {
            $scope.AdvisorList = response.data;            
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.AdvisorList();


   
    //To get Details of Particular record
    $scope.GetDetails = function (Advisor) {

        var apiRoute = 'http://localhost:17746/api/Advisor';
        var ID = Advisor.AdvisorID;
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
        var apiRoute = 'http://localhost:17746/api/Advisor/' + Advisor.AdvisorID;
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
        $scope.Advisor.Mobile = "";
        $scope.Advisor.Phone = "";
        $scope.Advisor.EmailID = "";
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