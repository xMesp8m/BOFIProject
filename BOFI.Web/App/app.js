'use strict';

var bofiApp = angular.module('bofiApp', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/BOFI.Web',
        {
            templateUrl: '/BOFI.Web/App/views/bofiIndex.html',
            controller: 'bofiController'
        });

        $routeProvider.when('/BOFI.Web/details/:id',
        {
            templateUrl: '/BOFI.Web/App/views/bofiDetails.html',
            controller: 'bofiDetailsController',
            resolve: {
                boardGame: function ($route, bofiService) {
                    return bofiService.getById($route.current.pathParams.id).$promise;
                }
            }
        });

        $routeProvider.when('/BOFI.Web/edit/:id',
        {
            templateUrl: '/BOFI.Web/App/views/bofiEdit.html',
            controller: 'bofiEditController',
            resolve: {
                boardGame: function ($route, bofiService) {
                    return bofiService.getById($route.current.pathParams.id).$promise;
                }
            }
        });

        $routeProvider.when('/BOFI.Web/new',
        {
            templateUrl: '/BOFI.Web/App/views/bofiNew.html',
            controller: 'bofiNewController'
        });

        $routeProvider.otherwise({ redirectTo: '/BOFI.Web' });
        $locationProvider.html5Mode(true);
    });