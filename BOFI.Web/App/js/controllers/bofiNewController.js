'use strict';

bofiApp.controller('bofiNewController',
    function($scope,bofiService,$location) {
        $scope.boardGame = {};

        $scope.save = function(boardGame, newBoardGame) {
            if (newBoardGame.$valid) {
                bofiService.save(boardGame)
                    .$promise
                    .then(function (data) { $location.url('/BOFI.Web') })
                    .catch(function(data) { console.log('Error saving'); });
            }
        }

        $scope.cancel = function() {
            $location.url('/BOFI.Web');
        };
    });