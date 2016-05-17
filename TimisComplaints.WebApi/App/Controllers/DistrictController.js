angular
    .module('timisComplaints')
    .controller('DistrictController', function (AuthService, $routeParams, $scope, API, HelperService, $timeout, $filter) {

        $scope.districtId = $routeParams.districtId;
        $scope.districtName = $routeParams.districtName;
        $scope.totalScore = 0;

        $scope.selectedProblems = [];


        HelperService.StartLoading('loadProblems');
        API.getAllProblems({ districtId: $scope.districtId }, function (success) {
            $scope.problems = success;
            HelperService.StopLoading('loadProblems');

            success.forEach(function (prb) {
                $scope.totalScore = prb.points;
            });

            //Load user's problem
            HelperService.StartLoading('getUserProblems');
            API.getUserProblems({ districtId: $scope.districtId }, function (success) {
                $scope.selectedProblems = success;

                //remove selected problems from list
                $scope.selectedProblems.forEach(function (selPrb) {
                    var prb = $filter('filter')($scope.problems, { id: selPrb.problemId }, true);
                    if (prb != null && prb.length == 1) {
                        prb[0].selected = true;
                    }
                });


                HelperService.StopLoading('getUserProblems');
            }, function (error) {
                HelperService.StopLoading('getUserProblems');
                HelperService.ShowMessage('alert-danger', "Verificați conexiunea la internet și reîncărcați pagina!");
            });

        }, function (error) {
            HelperService.StopLoading('loadProblems');
            HelperService.ShowMessage('alert-danger', "Verificați conexiunea la internet și reîncărcați pagina!");
        });

        $scope.selectProblem = function (problem, $event) {

            var existingProblem = $filter('filter')($scope.selectedProblems, { problemId: problem.id }, true);
            if (existingProblem == null || existingProblem.length == 0) {

                HelperService.StartLoading('addProblem');
                API.addProblem({
                    problemId: problem.id,
                    districtId: $scope.districtId,
                    order: $scope.selectedProblems.length
                }, function (success) {
                    $scope.selectedProblems.push(success);
                    success.name = problem.name;
                    success.description = problem.description;

                    problem.selected = true;

                    HelperService.StopLoading('addProblem');
                }, function (error) {
                    HelperService.StopLoading('addProblem');
                });
            }


            //if ($scope.selectedProblems.length > 1) {
            //    var scrollHeight = $($event.target).parent().innerHeight();
            //    window.scrollBy(0, scrollHeight);
            //}
        }

        $scope.removeProblem = function (problem, $event) {
            var index = $scope.selectedProblems.indexOf(problem);
            if (index >= 0) {

                HelperService.StartLoading('removeProblem');
                API.removeProblem({ id: problem.id }, function (success) {
                    $scope.selectedProblems.splice(index, 1);

                    var originalProblem = $filter('filter')($scope.problems, { id: problem.problemId }, true);
                    if (originalProblem != null && originalProblem.length == 1) {
                        originalProblem[0].selected = false;
                    }

                    $scope.problemsChanged();

                    HelperService.StopLoading('removeProblem');
                }, function (error) {
                    HelperService.StopLoading('removeProblem');
                });


                //if ($event && $scope.selectedProblems.length > 0) {
                //    var scrollHeight = $($event.target).parent().innerHeight();
                //    window.scrollBy(0, -scrollHeight);
                //}
            }
        }

        $scope.problemsChanged = function () {
            var problemsOrder = [];
            $scope.selectedProblems.forEach(function (prb, index) {
                prb.order = index;

                problemsOrder.push({ id: prb.id, order: index });
            });

            HelperService.StartLoading('updateOrder');
            API.updateOrder(problemsOrder, function (success) {

                HelperService.StopLoading('updateOrder');
            }, function (error) {
                HelperService.StopLoading('updateOrder');
            });
        }


        $scope.sortableOptions = {
            stop: function (e, ui) {
                $scope.problemsChanged();
            }
        };

    });