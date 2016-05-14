angular
    .module('timisComplaints')
    .controller('DistrictController', function (AuthService, $routeParams, $scope, API, HelperService) {
        
        $scope.districtId = $routeParams.districtId;

        $scope.selectedProblems = [];



        HelperService.StartLoading('loadTest');
        API.getTest({ userName: 'asdf' }, function (success) {
            $scope.problems = success;
            HelperService.StopLoading('loadTest');
        }, function (error) {
            HelperService.StopLoading('loadTest');
        });

        $scope.selectProblem = function (problem) {
            $scope.selectedProblems.push(problem);

            $scope.problemsChanged();
        }

        $scope.problemsChanged = function(){
            console.log($scope.selectedProblems);
        }


        $scope.sortableOptions = {
            //activate: function () {
            //    console.log("activate");
            //},
            //beforeStop: function () {
            //    console.log("beforeStop");
            //},
            //change: function () {
            //    console.log("change");
            //},
            //create: function () {
            //    console.log("create");
            //},
            //deactivate: function () {
            //    console.log("deactivate");
            //},
            //out: function () {
            //    console.log("out");
            //},
            //over: function () {
            //    console.log("over");
            //},
            //receive: function () {
            //    console.log("receive");
            //},
            //remove: function () {
            //    console.log("remove");
            //},
            //sort: function () {
            //    console.log("sort");
            //},
            //start: function () {
            //    console.log("start");
            //},
            //update: function (e, ui) {
            //    console.log("update");

            //    //var logEntry = tmpList.map(function (i) {
            //    //    return i.value;
            //    //}).join(', ');
            //    //$scope.sortingLog.push('Update: ' + logEntry);
            //},
            stop: function (e, ui) {
                console.log("stop");

                // this callback has the changed model
                //var logEntry = tmpList.map(function (i) {
                //    return i.value;
                //}).join(', ');
                //$scope.sortingLog.push('Stop: ' + logEntry);

                $scope.problemsChanged();

            }
        };

    });