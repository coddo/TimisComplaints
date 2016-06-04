angular
    .module('timisComplaints')
    .controller('DashboardController', function (AuthService, $routeParams, $scope, API, HelperService, $location) {
        $scope.unacceptedProblems = [];

        function init() {
            HelperService.StartLoading('checkAuthorization');
            API.checkAuthorization(function (success) {
                HelperService.StopLoading('checkAuthorization');

                HelperService.StartLoading('loadUnacceptedProblems');
                API.getAllUnacceptedProblems({}, function (success) {
                    $scope.unacceptedProblems = success;
                    HelperService.StopLoading('loadUnacceptedProblems');
                }, function (error) {
                    HelperService.StopLoading('loadUnacceptedProblems');
                    HelperService.ShowMessage('alert-danger', "Verificați conexiunea la internet și reîncărcați pagina!");
                });
            }, function (error) {
                HelperService.StopLoading('checkAuthorization');
                $location.path('/admin');
            });          
        }

        $scope.acceptProblem = function (problem) {
            HelperService.StartLoading('acceptProblem');
            API.acceptProblem({ id: problem.id }, function (success) {
                
                var index = $scope.unacceptedProblems.indexOf(problem);
                $scope.unacceptedProblems.splice(index, 1);

                HelperService.StopLoading('acceptProblem');
            }, function (error) {
                HelperService.StopLoading('acceptProblem');
                HelperService.ShowMessage('alert-danger', "Verificați conexiunea la internet și reîncărcați pagina!");
            });
        }

        $scope.deleteProblem = function (problem) {
        	HelperService.StartLoading('deleteProblem');
        	API.deleteProblem({ id: problem.id }, function (success) {

        		var index = $scope.unacceptedProblems.indexOf(problem);
        		$scope.unacceptedProblems.splice(index, 1);

        		HelperService.StopLoading('deleteProblem');
        	}, function (error) {
        		HelperService.StopLoading('deleteProblem');
        		HelperService.ShowMessage('alert-danger', "Verificați conexiunea la internet și reîncărcați pagina!");
        	});
        }

        init();
});