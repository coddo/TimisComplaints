(function () {
    'use strict';

    angular
        .module('timisComplaints')
        .factory('AuthService', AuthService);


    function AuthService($http, $q, $rootScope, API, HelperService) {
        var user = null;

        var service = {
            Authenticate: authenticate,
        };

        return service;

        /* IMPLEMENTATION */



        function getUser() {
            if (user === null) {
                return API.getMe(function (success) {
                    user = success;
                }, function (error) { $q.reject; }).$promise;
            } else {
                return $q.when(user);
            }
        }

        

        function authenticate(callback) {
            HelperService.StartLoading('authenticate');
            getUser().then(function (user) {
                if (user !== null && user.id !== undefined) {
                   callback(user);
                } else {
                    callback(null);
                }

                HelperService.StopLoading('authenticate');
            }, function (error) {
                HelperService.StopLoading('authenticate');
                HelperService.ShowMessage('alert-danger', 'Verificati conexiunea la internet si reincarcati pagina!');
            });
        }

    
    }
})();