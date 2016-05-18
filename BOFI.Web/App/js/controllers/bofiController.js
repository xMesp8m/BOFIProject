'use strict';

bofiApp.controller('bofiController',
    function ($scope, bofiService, $location) {
        bofiService.getAllBoardGames()
            .$promise.then(function (data) {
                $scope.boardGames = data.Response;
            });

        $scope.newBoardGame = function() {
            $location.url('/BOFI.Web/new/');
        }

        $scope.viewDetails = function (id) {
            $location.url('/BOFI.Web/details/'+id);
        }

        
    });