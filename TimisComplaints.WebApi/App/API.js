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

        });

        return res;
    }
})();