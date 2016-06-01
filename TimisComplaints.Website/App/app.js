(function () {
    'use strict';
    var app = angular.module('timisComplaints', ['ui.sortable', 'ngResource', 'ngRoute', 'ui.bootstrap', 'ui.bootstrap.tooltip']);

    app.config(function ($routeProvider, $locationProvider) {

        $routeProvider
            .when('/', {
                templateUrl: '/Views/Index.html',
                controller: 'IndexController'
            })
            .when('/cartier/:districtId/:districtName', {
                templateUrl: '/Views/District.html',
                controller: 'DistrictController'
            })
            //.when('/scrisoare', {
            //    templateUrl: '/Views/Letter.html',
            //    controller: 'LetterController'
            //})
            .when('/probleme/:districtId/:districtName', {
                templateUrl: '/Views/Problem.html',
                controller: 'ProblemController'
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
