app.controller('newClientController', ['$scope', 'CrudService', function ($scope, CrudService) {

    debugger;
    $scope.Save = function () {
        debugger;
        var client = {
            Title: $scope.Title,
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            SAId: $scope.SAId,
            Company: $scope.Company,
            CompanyRegNo: $scope.CompanyRegNo,
            Mobile: $scope.Mobile,
            EmailId: $scope.EmailId
            //MobileNumber: $scope.MobileNumber,
            //PhoneNumber: $scope.PhoneNumber,
            //EmailId: $scope.EmailId
            //UserImage: $scope.UserImage,

        }
        // Base Url 

        var apiRoute = 'http://localhost:17746/api/clientreg';

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
    $scope.Clear = function () {
        $scope.Title = "";
        $scope.FirstName = "";
        $scope.LastName = "";
        $scope.SAId = "";
        $scope.Company = "";
        $scope.CompanyRegNo = "";
        $scope.Mobile = "";
        $scope.EmailId = "";
    }

    $scope.ClientList = function () {
        var apiRoute = 'http://localhost:17746/api/clientreg';
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
}]);
