angular
    .module('timisComplaints')
    .controller('DistrictController', function (AuthService, $routeParams, $scope) {
        
        $scope.districtId = $routeParams.districtId;

    });