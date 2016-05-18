'use strict';

bofiApp.controller('bofiDetailsController',
    function ($scope, $route, $location, bofiService) {
        $scope.boardGame = $route.current.locals.boardGame.Response;

        $scope.editBoardGame = function(id) {
            $location.url('/BOFI.Web/edit/' + id);
        };

        $scope.delete = function(id) {
            bofiService.deleteBoardGame(id)
                .$promise
                .then(function(data) {
                    goToRoot();
                });
        };

        $scope.back = function() {
            goToRoot();
        };

        function goToRoot() {
            $location.url('/BOFI.Web');
        }
    });