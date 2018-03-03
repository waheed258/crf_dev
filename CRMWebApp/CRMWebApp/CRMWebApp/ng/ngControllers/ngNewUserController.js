app.controller('newUserController', ['$scope', 'CrudService', function ($scope, CrudService) {

    debugger;
    $scope.Save = function () {
        var user = {
            FirstName: $scope.firstname,
            LastName: $scope.lastname,
            EmailId: $scope.email
        }
        // Base Url 

        var apiRoute = 'http://localhost:29755/api/User';

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
        $scope.FirstName = 0;
        $scope.LastName = "";
        $scope.EmailId = "";
        $scope.Phone = "";
        $scope.Address = "";
    }
}]);