angular
    .module('timisComplaints')
    .controller('DistrictController', function (AuthService, $routeParams, $scope, API, HelperService, $timeout, $filter, $location) {

        $scope.districtId = $routeParams.districtId;
        $scope.districtName = $routeParams.districtName;
        //$scope.totalScore = 0;
        $scope.maxPoints = 0;

        $scope.selectedProblems = [];
        $scope.newProblem = { name: '', description: '' };
        $scope.userAddedProblems = [];

        function init() {
            HelperService.StartLoading('loadProblems');
            API.getAllProblems({ districtId: $scope.districtId }, function (success) {
                $scope.problems = success;
                HelperService.StopLoading('loadProblems');

                $scope.totalScore = 0;
                success.forEach(function (prb) {
                    if (prb.points > $scope.maxPoints)
                        $scope.maxPoints = prb.points;

                    //$scope.totalScore += prb.points;
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

            //getMyCreatedProblems
            HelperService.StartLoading('getMyCreatedProblems');
            API.getMyCreatedProblems(function (success) {
                $scope.userAddedProblems = success;

                HelperService.StopLoading('getMyCreatedProblems');
            }, function (error) {
                HelperService.StopLoading('getMyCreatedProblems');
                HelperService.ShowMessage('alert-danger', "Verificați conexiunea la internet și reîncărcați pagina!");
            });
        }

        init();



        $scope.selectProblem = function (problem, $event) {
            var existingProblem = $filter('filter')($scope.selectedProblems, { problemId: problem.id }, true);
            if (existingProblem == null || existingProblem.length == 0) {
                var selectedProblem = {
                    problemId: problem.id,
                    districtId: $scope.districtId,
                    name: problem.name,
                    description: problem.description,
                    order: $scope.selectedProblems.length
                };
                $scope.selectedProblems.push(selectedProblem);
                problem.selected = true;
            }
        }

        $scope.removeProblem = function (problem, $event) {
            var index = $scope.selectedProblems.indexOf(problem);
            if (index >= 0) {
                $scope.selectedProblems.splice(index, 1);

                var originalProblem = $filter('filter')($scope.problems, { id: problem.problemId }, true);
                if (originalProblem != null && originalProblem.length == 1) {
                    originalProblem[0].selected = false;
                }

                $scope.problemsChanged();
            }
        }

        $scope.problemsChanged = function () {
            var problemsOrder = [];
            $scope.selectedProblems.forEach(function (prb, index) {
                prb.order = index;

                problemsOrder.push({ id: prb.id, order: index });
            });
        }

        $scope.sendNewProblem = function () {
            HelperService.StartLoading('sendNewProblem');
            API.createProblem($scope.newProblem, function (success) {
                $scope.userAddedProblems.push($scope.newProblem);

                $scope.newProblem = { name: '', description: '' };

                HelperService.ShowMessage('alert-success', "Problema a fost trimisă cu succes!");

                HelperService.StopLoading('sendNewProblem');
            }, function (error) {
                HelperService.StopLoading('sendNewProblem');
            });
        }

        $scope.sortableOptions = {
            stop: function (e, ui) {
                $scope.problemsChanged();
            }
        };

        $scope.confirmSelectedProblems = function () {
            HelperService.StartLoading('confirmSelectedProblems');
            API.confirmUserProblems($scope.selectedProblems, function(success) {
                HelperService.StopLoading('confirmSelectedProblems');
                $location.path('/probleme/' + $scope.districtId + '/' + $scope.districtName);
            }, function (error) {
                HelperService.StopLoading('confirmSelectedProblems');
                HelperService.ShowMessage('alert-danger', "Verificați conexiunea la internet și reîncărcați pagina!");
            });
        }
    });
