(function () {
    'use strict';
    var app = angular.module('timisComplaints', ['ui.sortable', 'ngResource', 'ngRoute', 'ui.bootstrap', 'ui.bootstrap.tooltip']);

    app.config(function ($routeProvider, $locationProvider) {

        $routeProvider
            .when('/', {
                templateUrl: '/Views/Index.html',
                controller: 'IndexController'
            })
            .when('/cartier/:districtId', {
                templateUrl: '/Views/District.html',
                controller: 'DistrictController'
            })

            .otherwise({
                templateUrl: '/Views/Inexistent.html',
            });
        //.when('/contact', {
        //    templateUrl : 'partials/contact.html',
        //    controller : mainController
        //});


        // use the HTML5 History API
        $locationProvider.html5Mode(true);
    });


})();