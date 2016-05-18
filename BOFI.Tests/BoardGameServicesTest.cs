using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOFI.Dtos;
using BOFI.Model;
using BOFI.Services;
using BOFI.Tests.Infraestructure;
using FluentAssertions;
using Xunit;

namespace BOFI.Tests
{
    public class BoardGameServicesTest
    {
        private readonly BoardGameService _boardService;
        public BoardGameServicesTest()
        {
            _boardService = new BoardGameService();
        }

        [Trait("Integration Test","BoardGame Service")]
        [Theory(DisplayName = "Save Challenge record on DataBase")]
        [AutoFixtureMoqAutoData]
        public void AddNewBoardGameSuccess(BoardGameDto boardGame)
        {
            var boardGameService = new BoardGameService();
            var response = boardGameService.Add(boardGame);

            response.Should().NotBeNull();
        }
        [Trait("Integration Test", "BoardGame Service")]
        [Fact(DisplayName = "Get All board games")]
        public void GetAllBoardGames()
        {
            var response = _boardService.GetAll();
            response.Should().NotBeEmpty();

        }

        [Trait("Integration Test", "BoardGame Service")]
        [Fact(DisplayName = "Remove Board Game")]
        public void RemoveBoardGame()
        {
            var response = _boardService.Remove("Ided4aec31-380b-4ec0-968e-8ebd3e144013");
            response.Should().BeTrue();

        }

        [Trait("Integration Test", "BoardGame Service")]
        [Fact(DisplayName = "Get Board Game By Id")]
        public void GetBoardGameById()
        {
            var response = _boardService.GetById("d18751a0-b140-4540-b574-073d8be1bfa7");
            response.Name.Should().Be("My first test");

        }
    }
}
