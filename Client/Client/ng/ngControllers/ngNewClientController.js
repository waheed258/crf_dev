app.controller('ClientController', ['$scope', 'CrudService', function ($scope, CrudService) {
    $scope.dtInstance = {};
    debugger;
    $scope.Save = function () {
        debugger;
        var client = {
            Title:$scope.Title,
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            SAID: $scope.SAID,
            CompanyName: $scope.Company,
            CompanyRegNo: $scope.CompanyRegNo,
            MobileNumber: $scope.Mobile,
            EmailId: $scope.EmailId,
            TrustName: $scope.Trust,
            TrustRegNo: $scope.TrustRegNo
        }

        
        //// Base Url 

        var apiRoute = 'http://localhost:17746/api/ClientRegistration';
        client.Status = '1';
        var saveUser = CrudService.post(apiRoute, client);
        saveUser.then(function (response) {
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
  
 
    $scope.Clear = function () {
        $scope.Title = "";
        $scope.FirstName = "";
        $scope.LastName = "";
        $scope.SAID = "";
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
