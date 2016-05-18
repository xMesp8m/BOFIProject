'use strict';

bofiApp.controller('bofiEditController',
    function ($scope, $route, $location, bofiUpdateService) {

        $scope.boardGame = $route.current.locals.boardGame.Response;

        $scope.save = function (boardGame, newBoardGame) {
            if (newBoardGame.$valid) {
                bofiUpdateService.update({ id: $scope.boardGame.Id }, boardGame)
                    .$promise
                    .then(function(data) {
                        $location.url('/BOFI.Web');
                    })
                    .catch(function (data) { console.log('Error saving'); });
            }
        }

        $scope.cancel = function () {
            $location.url('/BOFI.Web');
        };
    });