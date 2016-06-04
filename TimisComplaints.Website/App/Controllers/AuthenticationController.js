angular
    .module('timisComplaints')
    .controller('AuthenticationController', function (AuthService, $routeParams, $scope, API, HelperService, $location) {
        $scope.user = {
            username: '',
            password: ''
        };

        HelperService.StartLoading('checkAuthorization');
        API.checkAuthorization(function (success) {
            HelperService.StopLoading('checkAuthorization');
            $location.path('/admin/dashboard');
        }, function (error) {
            HelperService.StopLoading('checkAuthorization');
        });

        $scope.authenticate = function () {
            HelperService.StartLoading('authenticate');
            API.authenticate($scope.user, function (success) {
                HelperService.StopLoading('authenticate');
                $location.path('/admin/dashboard');
            }, function (error) {
                HelperService.StopLoading('authenticate');
                HelperService.ShowMessage('alert-danger', "Nume de utilizator sau parola gresite");
            });
        }
    });