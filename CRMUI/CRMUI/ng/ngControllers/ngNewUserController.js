app.controller('newUserController', ['$scope', 'CrudService', function ($scope, CrudService) {

    debugger;
    $scope.Save = function () {
        debugger;
        var user = {
            LoginId: $scope.LoginId,
            UserType: $scope.UserType,
            Password: $scope.Password,
            CenterName: $scope.CenterName,
            ActiveStatus: $scope.ActiveStatus,
            IsLogin: $scope.IsLogin,
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            MobileNumber: $scope.MobileNumber,
            PhoneNumber: $scope.PhoneNumber,
            EmailId: $scope.EmailId
            //UserImage: $scope.UserImage,

        }
        // Base Url 

        var apiRoute = 'http://localhost:17746/api/UserAdmin';

        var saveUser = CrudService.post(apiRoute, user);
        saveUser.then(function (response) {
            if (response.data != "") {
                alert("Data Save Successfully");
                $scope.Clear();
            } else {
                alert("Some error");
            }

        }, function (error) {
            console.log("Error: " + error);
        });
    }
    $scope.Clear = function () {
        $scope.LoginId = "";
        $scope.UserType = "";
        $scope.Password = "";
        $scope.CenterName = "";
        $scope.ActiveStatus = "";
        $scope.IsLogin = "";
        $scope.FirstName = "";
        $scope.LastName = "";
        $scope.MobileNumber = "";
        $scope.PhoneNumber = "";
        $scope.EmailId = "";
    }

    $scope.UserList = function () {
        var apiRoute = 'http://localhost:17746/api/UserAdmin';
        var student = CrudService.getAll(apiRoute);
        student.then(function (response) {
            debugger
            $scope.UserList = response.data;

        },
    function (error) {
        console.log("Error: " + error);
    });


    }
    $scope.UserList();

  
    $scope.UserTypes = function () {
        var apiRoute = 'http://localhost:17746/api/UserType';
        var usertype = CrudService.getAll(apiRoute);
        usertype.then(function (response) {
            debugger
            $scope.UserTypes = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.UserTypes();


    $scope.ActiveStatues = function () {
        var apiRoute = 'http://localhost:17746/api/Status';
        var status = CrudService.getAll(apiRoute);
        status.then(function (response) {
            debugger
            $scope.ActiveStatues = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });
    }
    $scope.ActiveStatues();
}]);


