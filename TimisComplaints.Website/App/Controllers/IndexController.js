angular
    .module('timisComplaints')
    .controller('IndexController', function (AuthService,$scope, API, HelperService) {
        $scope.AllDistricts = [];

        HelperService.StartLoading('loadTest');
        API.getAllDistricts( function (success) {
            $scope.AllDistricts = success;
            HelperService.StopLoading('loadTest');
        }, function (error) {
            HelperService.StopLoading('loadTest');
        });

    });