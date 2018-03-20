app.controller('ClientProfileController', ['$scope', 'CrudService', function ($scope, CrudService) {
    debugger;
    // To Display Popup


    //Save A Record
    $scope.Save = function () {
        debugger;
        var ClientProfile = {
            SAId: $scope.SAId,
            //FirstName: $scope.FirstName,
            //LastName: $scope.LastName,
            //Mobile: $scope.MobileNo,
            //TAXreference: $scope.TaxRefNo,
            BankName: $scope.BankName,
            BranchNumber: $scope.BranchNumber,
            AccountNumber: $scope.AccountNumber,
            AccountType: $scope.AccountType,
            Currency: $scope.Currency,
            SWIFT: $scope.SWIFT,

            //UserImage: $scope.UserImage, 
        }

        var address = {
            SAId: $scope.SAId,
            HouseNo: $scope.HouseNo,
            BuildingName: $scope.BuildingName,
            Floor: $scope.Floor,
            Flat: $scope.FlatNo,
            RoadName: $scope.RoadName,
            RoadNo: $scope.RoadNo,
            SuburbName: $scope.SuburbName,
            City: $scope.City,
            PostalCode: $scope.PostalCode,
            Province: $scope.Province,
            Country: $scope.Country,
        }
        // Base Url 
        var apiRoute = 'http://localhost:17746/api/bank';
        var saveClientProfile = CrudService.post(apiRoute, ClientProfile);
        saveClientProfile.then(function (response) {
            if (response.data != "") {
                CrudService.post('http://localhost:17746/api/Address', address);
                alert("saved successfully");
            }
            else {
                alert("Some error");
            }
        }, function (error) {
            console.log("Error: " + error);

        });

    }
    //Clear the data

    $scope.Clear = function () {
        $scope.TaxRefNo = "";
        $scope.BankName = "";
        $scope.BranchNumber = "";
        $scope.AccountNumber = "";
        $scope.AccountType = "";
        $scope.Currency = "";
        $scope.SWIFT = "";

    }







    //GetUserList
    $scope.ClientProfileList = function () {
        var apiRoute = 'http://localhost:17746/api/Bank';
        var ClientProfile = CrudService.getAll(apiRoute);
        ClientProfile.then(function (response) {
            debugger
            $scope.ClientProfileList = response.data;
        },
    function (error) {
        console.log("Error: " + error);
    });

    }
    $scope.ClientProfileList();


    //GetClientRegisterlist shows 
    $scope.GetClientReg = function () {
        var apiRoute = 'http://localhost:17746/api/GetClientReg';
        var GetClient = CrudService.getAll(apiRoute);
        GetClient.then(function (response) {
            debugger;
            $scope.GetClientReg = response.data[0];
            $scope.SAId = $scope.GetClientReg.SAId;
            $scope.FirstName = $scope.GetClientReg.FirstName;
            $scope.LastName = $scope.GetClientReg.LastName;
            $scope.MobileNo = $scope.GetClientReg.CompanyRegNo;

        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    $scope.GetClientReg();





}])