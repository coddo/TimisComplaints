(function () {
    'use strict';

    angular
        .module('timisComplaints')
        .factory('API', API);

    API.$inject = ['$resource', '$rootScope'];

    function API($resource, $rootScope) {
        var baseUrl = '/api/';
        $rootScope.baseUrl = baseUrl;

        var res = $resource('/', {}, {
            //Users
            getMe: {
                url: baseUrl + 'users/me',
                method: 'GET',
                isArray: false
            },
            updateUserProblems: {
                url: baseUrl + 'admin/sourceProviders',
                method: 'POST',
                isArray: false
            },
            getTest: {
                url: baseUrl + 'test/test/:userName',
                method: 'GET',
                params: { userName: '@userName' },
                isArray: true
            },
            getAllDistricts: {
                url: baseUrl + 'district/GetAll',
                method: 'GET',
                isArray: true
            },
            getAllProblems: {
                url: baseUrl + 'problem/GetAll',
                method: 'GET',
                isArray: true
            },
            getAllLetters: {
                url: baseUrl + 'letter/GetAll',
                method: 'GET',
                isArray: true
            },
            createLetter: {
                url: baseUrl + 'letter/Create',
                method: 'POST',
                isArray: false
            },
            removeLetter: {
                url: baseUrl + 'letter/Delete',
                method: 'DELETE',
                isArray: false
            },
            //addSelectedProblem: {
            //    url: baseUrl + 'problem/:ids',
            //    method: 'POST',
            //    prams: {ids:'@ids'},
            //    isArray:false
            //},



        });

        return res;
    }
})();
