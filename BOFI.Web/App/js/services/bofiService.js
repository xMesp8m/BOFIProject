'use strict';

bofiApp.service('bofiService',
    function($resource) {

        var boardGameResource = $resource('/BOFI.API.Web/api/boardgame/:id');
        return {
            getAllBoardGames: function() {
                return boardGameResource.get();
            },
            getById: function (idx) {
                return $resource('/BOFI.API.Web/api/boardgame/:id',
                {
                    id: idx
                }).get();
            },
            save: function(boardGame) {
                return boardGameResource.save(boardGame);
            },
            deleteBoardGame: function(idx) {
                return $resource('/BOFI.API.Web/api/boardgame/:id',
                {
                    id: idx
                }).remove();
            }


        };
    });