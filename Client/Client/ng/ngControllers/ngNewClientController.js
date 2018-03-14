app.controller('ClientController', ['$scope', 'CrudService', function ($scope, CrudService) {
    $scope.dtInstance = {};
    debugger;
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
            EmailId: $scope.EmailId,
            Trust: $scope.Trust,
            TrustRegNo: $scope.TrustRegNo
        }

        if (CrudService.post) {
            client.Status = '1';
            client.DeleteFlag = '1';
        }
        //// Base Url 

        var apiRoute = 'http://localhost:17746/api/ClientRegistration';

        var saveUser = CrudService.post(apiRoute, client);
        saveUser.then(function (response) {
            if (response.data != "") {
                $scope.successMessage = "Form Updated successfully";
                $scope.successMessagebool = true;
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
        $scope.Trust = "";
        $scope.TrustRegNo = "";
    }


    $scope.Cancel = function () {
        $scope.Clear();
    }



}]);
