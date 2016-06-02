angular
	.module('timisComplaints')
	.controller('IndexController', function(AuthService, $scope, API, HelperService) {
		$scope.AllDistricts = [];
		$scope.usersCount = 0;

		HelperService.StartLoading('loadTest');
		API.getAllDistricts(function(success) {
			$scope.AllDistricts = success;

			API.getCount(function(success) {
				$scope.usersCount = success.value;
			});

			HelperService.StopLoading('loadTest');
		}, function(error) {
			HelperService.StopLoading('loadTest');
		});
	});