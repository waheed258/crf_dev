app.controller('ConsultantController', ['$scope', 'CrudService', function ($scope, CrudService) {
    debugger;
    // To Display Popup

    //Save A Record
    $scope.Save = function () {
        debugger;
        var consultant = {
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            MobileNumber: $scope.MobileNumber,
            PhoneNumber: $scope.PhoneNumber,
            EmailId: $scope.EmailId,
            LoginId: $scope.LoginId,
            Password: $scope.Password,
            Designation: $scope.Designation,
            Branch: $scope.Branch,
            ConsultantType: $scope.ConsultantType,
            Status: $scope.Status
            //UserImage: $scope.UserImage,
        }
        // Base Url 
        var apiRoute = 'http://localhost:17746/api/Consultant';
        var saveConsultant = CrudService.post(apiRoute, consultant);
        saveConsultant.then(function (response) {
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
        $scope.ConsultantType = "";
        $scope.Status = "";
        $scope.ConfirmPassword = "";
    }
    //GetUserList
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


    //Get UserTypes
    $scope.ConsultantTypes = function () {
        var apiRoute = 'http://localhost:17746/api/UserType';
        var usertype = CrudService.getAll(apiRoute);
        usertype.then(function (response) {
            debugger
            $scope.ConsultantTypes = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.ConsultantTypes();
    //GetStatus
    $scope.Statues = function () {
        var apiRoute = 'http://localhost:17746/api/Status';
        var status = CrudService.getAll(apiRoute);
        status.then(function (response) {
            debugger
            $scope.Statues = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.Statues();
    //Get Designation
    $scope.Designations = function () {
        var apiRoute = 'http://localhost:17746/api/Designation';
        var status = CrudService.getAll(apiRoute);
        status.then(function (response) {
            debugger
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
            debugger
            $scope.Branchs = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.Branchs();
    //Delete a Record
    $scope.DeleteUser = function (user) {
        debugger
        var apiRoute = 'http://localhost:17746/api/Consultant/' + user.UserID
        var deleteUser = CrudService.delete(apiRoute);
        deleteUser.then(function (response) {
            if (response.data != "") {
                alert("Data Delete Successfully");
                var index = $scope.UserAdmin.indexOf(user.UserID);
                $scope.UserAdmin.splice(index, 1);
            } else {
                alert("Some error");
            }
        }, function (error) {
            console.log("Error: " + error);
        });
    }
}]);