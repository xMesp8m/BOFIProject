'use strict';

describe('Test bofiController', function() {
    var $controller, scope;

    beforeEach(angular.mock.module("bofiApp"));

      beforeEach(angular.mock.inject(function (_$controller_, $rootScope) {

          $controller = _$controller_;
        scope = $rootScope.$new();

      }));

    it('should get all the boardGames',
        function () {
            var mBoardGames = {};
            var boardGameServiceMock = { getAllBoardGames: function () { } };
            var mockBoardGamesService = sinon.stub(boardGameServiceMock);


            $controller("bofiController",
            { '$scope': scope, bofiService: mockBoardGamesService });

            mockBoardGamesService.getAllBoardGames.returns(mBoardGames);

            expect(scope.boardGames).toBe(mBoardGames);
        });
});