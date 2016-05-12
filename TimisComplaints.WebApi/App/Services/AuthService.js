(function () {
    'use strict';

    angular
        .module('timisComplaints')
        .factory('AuthService', AuthService);


    function AuthService($http, $q, $rootScope, API, HelperService) {
        var user = null;

        var service = {
            //Initialize: initialize,
            //User: getUser,
            //Login: login,
            //Register: register,
            //ToRegister: toRegister,
            //Logout: logout,
            //GetRangName: getRangName,
            //Authenticate: authenticate,
        };

        function initialize() {
        }

        //initialize();

        return service;

        /* IMPLEMENTATION */



        //function getUser() {
        //    if (user === null) {
        //        return API.getMe(function (success) {
        //            user = success;
        //        }, function (error) { $q.reject; }).$promise;
        //    } else {
        //        return $q.when(user);
        //    }
        //}

        //function login(username, password) {
        //    return API.login({ username: username, password: password }, function (success) {
        //        user = success;
        //    }, function (error) { $q.reject; }).$promise;
        //}

        //function logout() {
        //    return API.logout(function (success) {
        //        user = null;
        //    }, function (error) { $q.reject; }).$promise;
        //}

        //function register(registerUser) {
        //    return API.register(registerUser, function (success) {
        //    }, function (error) { $q.reject; }).$promise;
        //}

        //function toRegister() {
        //    return API.toRegister(function (success) {
        //    }, function (error) { $q.reject; }).$promise;
        //}

        //function authenticate(callback) {
        //    HelperService.StartLoading('authenticate');
        //    getUser().then(function (user) {
        //        if (user !== null && user.username !== undefined) {
        //           callback(user);
        //        } else {
        //            callback(null);
        //        }

        //        HelperService.StopLoading('authenticate');
        //    }, function (error) {
        //        HelperService.StopLoading('authenticate');
        //    });
        //}

    
    }
})();