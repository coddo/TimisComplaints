angular
    .module('timisComplaints')
    .controller('ProblemController', function (AuthService, $routeParams, $scope, API, HelperService) {
        $scope.districtId = $routeParams.districtId;
        $scope.districtName = $routeParams.districtName;
        $scope.maxPoints = 0;

        function init () {
            HelperService.StartLoading('loadProblems');
            API.getAllProblems( { districtId: $scope.districtId }, function (success) {
                $scope.problems = success;
                HelperService.StopLoading('loadProblems');

                $scope.totalScore = 0;
                success.forEach(function (prb) {
                    if (prb.points > $scope.maxPoints)
                        $scope.maxPoints = prb.points;
                });
            }, function (error) {
                HelperService.StopLoading('loadProblems');
                HelperService.ShowMessage('alert-danger', "Verificați conexiunea la internet și reîncărcați pagina!");
            });
        }

        init();
});
