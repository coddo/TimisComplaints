angular
    .module('timisComplaints')
    .controller('DashboardController', function (AuthService, $routeParams, $scope, API, HelperService, $timeout, $filter) {
        $scope.unacceptedProblems = [];

        function init() {
            HelperService.StartLoading('loadUnacceptedProblems');
            API.getAllUnacceptedProblems({}, function (success) {
                $scope.unacceptedProblems = success;
                HelperService.StopLoading('loadUnacceptedProblems');
            }, function (error) {
                HelperService.StopLoading('loadUnacceptedProblems');
                HelperService.ShowMessage('alert-danger', "Verificați conexiunea la internet și reîncărcați pagina!");
            });
        }

        init();
});