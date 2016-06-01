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

        $scope.acceptProblem = function (problemId) {
            HelperService.StartLoading('acceptProblem');
            API.acceptProblem({ id: problemId }, function (success) {
                HelperService.StopLoading('acceptProblem');
            }, function (error) {
                HelperService.StopLoading('acceptProblem');
                HelperService.ShowMessage('alert-danger', "Verificați conexiunea la internet și reîncărcați pagina!");
            });
        }

        init();
});