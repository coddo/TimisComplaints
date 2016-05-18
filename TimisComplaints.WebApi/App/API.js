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

            getMe: {
                url: baseUrl + 'account/whoAmI',
                method: 'GET',
                isArray: false
            },

            getAllDistricts: {
                url: baseUrl + 'district/GetAll',
                method: 'GET',
                isArray: true
            },
            getAllProblems: {
                url: baseUrl + 'problem/GetAll',
                method: 'GET',
                //params: { districtId: '@districtId' },
                isArray: true
            },

            //User problems
            getUserProblems: {
                url: baseUrl + 'userProblem/GetAll',///:districtId',
                method: 'GET',
                //params: { districtId: '@districtId' },
                isArray: true
            },
            addProblem: {
                url: baseUrl + 'userProblem/create',
                method: 'POST',
                isArray: false
            },
            removeProblem: {
                url: baseUrl + 'userProblem/delete',///:id',
                method: 'DELETE',
                //params: { id: '@id' },
                isArray: false
            },
            updateOrder: {
                url: baseUrl + 'userProblem/updateOrder',
                method: 'POST',
                isArray: true
            },

            //User created problems
            createProblem: {
                url: baseUrl + 'problem/Create',
                method: 'POST',
                isArray: false
            },
            getMyCreatedProblems: {
                url: baseUrl + 'problem/GetAllUnacceptedForUser',
                method: 'GET',
                isArray: true
            },

            //Letters
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