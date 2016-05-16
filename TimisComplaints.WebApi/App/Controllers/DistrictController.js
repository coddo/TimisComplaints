angular
    .module('timisComplaints')
    .controller('DistrictController', function (AuthService, $routeParams, $scope, API, HelperService, $timeout) {

        $scope.districtId = $routeParams.districtId;

        $scope.selectedProblems = [];


        HelperService.StartLoading('loadProblems');
        API.getAllProblems(function (success) {
            $scope.problems = success;
            HelperService.StopLoading('loadProblems');

            //Load user's problem


        }, function (error) {
            HelperService.StopLoading('loadProblems');
            HelperService.ShowMessage('alert-danger', "Verificați conexiunea la internet și reîncărcați pagina!");
        });

        $scope.selectProblem = function (problem, $event) {
            if ($scope.selectedProblems.indexOf(problem) == -1) {
                $scope.selectedProblems.push(problem);
                problem.selected = true;
                //var ids = {};
                //ids.userId = "";
                //ids.districtId = $scope.districtId;
                //ids.problemId = problem.id;
                //API.addSelectedProblem({ids}, function (succes) {
                //}, function (error) {
                //});
                $scope.problemsChanged();

                //if ($scope.selectedProblems.length > 1) {
                //    var scrollHeight = $($event.target).parent().innerHeight();
                //    window.scrollBy(0, scrollHeight);
                //}
            }
        }

        $scope.removeProblem = function (problem, $event) {
            var index = $scope.selectedProblems.indexOf(problem);
            if (index >= 0) {
                $scope.selectedProblems.splice(index, 1);
                problem.selected = false;

                $scope.problemsChanged();

                //if ($event && $scope.selectedProblems.length > 0) {
                //    var scrollHeight = $($event.target).parent().innerHeight();
                //    window.scrollBy(0, -scrollHeight);
                //}
            }
        }

        $scope.problemsChanged = function () {
            $scope.selectedProblems.forEach(function (prb, index) {
                prb.order = index;
            });

            //TODO: Upload order
        }


        $scope.sortableOptions = {
            stop: function (e, ui) {
                $scope.problemsChanged();
            }
        };

    });