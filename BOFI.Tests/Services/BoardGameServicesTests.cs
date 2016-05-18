using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOFI.Contracts.Dao;
using BOFI.Contracts.Services;
using BOFI.Dtos;
using BOFI.Model;
using BOFI.Services;
using BOFI.Services.Infraestructure;
using BOFI.Tests.Infraestructure;
using FluentAssertions;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace BOFI.Tests.Services
{
    public class BoardGameServicesTests
    {

        [Trait("Good Path","Board Game")]
        [Theory(DisplayName = "Add new Board Game Succeed")]
        [AutoFixtureMoqAutoData]
        public void AddNewBoardGameSucceed([Frozen] Mock<IBoardGameDao> iService, BoardGameDto boardGame)
        {
            iService.Setup(x => x.Add(It.IsAny<BoardGame>())).Returns(new BoardGame());

            var sut = new BoardGameService(iService.Object,new Mappings());

            var response =  sut.Add(boardGame);

            iService.Verify(z => z.Add(It.IsAny<BoardGame>()),Times.Once);
            response.Should().NotBeNull();

        }

        [Trait("Sad Path","Board Game")]
        [Theory(DisplayName = "Add new Board Game Not Succeed")]
        [AutoFixtureMoqAutoData]
        public void AddNewBoardGameNotSucceed([Frozen] Mock<IBoardGameDao> iService, BoardGameDto boardGame)
        {
            iService.Setup(x => x.Add(It.IsAny<BoardGame>())).Returns((BoardGame)null);

            var sut = new BoardGameService(iService.Object,new Mappings());

            var response = sut.Add(boardGame);

            response.Should().BeNull();
        }

        [Trait("Good Path", "Board Game")]
        [Theory(DisplayName = "Update Board Game Succeed")]
        [AutoFixtureMoqAutoData]
        public void UpdateBoardGameSucceed([Frozen] Mock<IBoardGameDao> iService, BoardGameDto boardGame)
        {
            iService.Setup(x => x.Update(It.IsAny<BoardGame>())).Returns(true);

            var sut = new BoardGameService(iService.Object, new Mappings());

            var response = sut.Update(boardGame);

            iService.Verify(z => z.Update(It.IsAny<BoardGame>()), Times.Once);
            response.Should().BeTrue();

        }

        [Trait("Sad Path", "Board Game")]
        [Theory(DisplayName = "Update Board Game Not Succeed")]
        [AutoFixtureMoqAutoData]
        public void UpdateBoardGameNotSucceed([Frozen] Mock<IBoardGameDao> iService, BoardGameDto boardGame)
        {
            iService.Setup(x => x.Update(It.IsAny<BoardGame>())).Returns(false);

            var sut = new BoardGameService(iService.Object, new Mappings());

            var response = sut.Update(boardGame);

            iService.Verify(z => z.Update(It.IsAny<BoardGame>()), Times.Once);
            response.Should().BeFalse();
        }

        [Trait("Good Path", "Board Game")]
        [Theory(DisplayName = "Get Board Game Collection")]
        [AutoFixtureMoqAutoData]
        public void GetAllBoardGamesCollection([Frozen] Mock<IBoardGameDao> iService, BoardGame boardGame)
        {
            iService.Setup(x => x.GetAll()).Returns(new List<BoardGame>{boardGame});

            var sut = new BoardGameService(iService.Object, new Mappings());

            var response = sut.GetAll();
            response.Should().NotBeEmpty();
        }

        [Trait("Sad Path", "Board Game")]
        [Theory(DisplayName = "Get Board Games empty Collection")]
        [AutoFixtureMoqAutoData]
        public void GetAllBoardGamesEmptyCollection([Frozen] Mock<IBoardGameDao> iService, BoardGame boardGame)
        {
            iService.Setup(x => x.GetAll()).Returns(new List<BoardGame>());

            var sut = new BoardGameService(iService.Object, new Mappings());

            var response = sut.GetAll();
            response.Should().BeEmpty();
        }

        [Trait("Good Path", "Board Game")]
        [Theory(DisplayName = "Get Board Game Succeed")]
        [AutoFixtureMoqAutoData]
        public void GetBoardGameSucced([Frozen] Mock<IBoardGameDao> iService, string boardGameId)
        {
            iService.Setup(x => x.GetById(It.IsAny<string>())).Returns(new BoardGame());

            var sut = new BoardGameService(iService.Object, new Mappings());

            var response = sut.GetById(boardGameId);
            response.Should().NotBeNull();
        }

        [Trait("Sad Path", "Board Game")]
        [Theory(DisplayName = "Get Board Game Not Succeed")]
        [AutoFixtureMoqAutoData]
        public void GetBoardGame([Frozen] Mock<IBoardGameDao> iService, string boardGameId)
        {
            iService.Setup(x => x.GetById(It.IsAny<string>())).Returns((BoardGame)null);

            var sut = new BoardGameService(iService.Object, new Mappings());

            var response = sut.GetById(boardGameId);
            response.Should().BeNull();
        }

        [Trait("Good Path", "Board Game")]
        [Theory(DisplayName = "Delete Board Game Succeed")]
        [AutoFixtureMoqAutoData]
        public void DeleteBoardGameSucced([Frozen] Mock<IBoardGameDao> iService, string boardGameId)
        {
            iService.Setup(x => x.Remove(It.IsAny<string>())).Returns(true);

            var sut = new BoardGameService(iService.Object, new Mappings());

            var response = sut.Remove(boardGameId);
            response.Should().Be(true);
        }

        [Trait("Sad Path", "Board Game")]
        [Theory(DisplayName = "Delete Board Game Not Succeed")]
        [AutoFixtureMoqAutoData]
        public void DeleteBoardGameNotSucced([Frozen] Mock<IBoardGameDao> iService, string boardGameId)
        {
            iService.Setup(x => x.Remove(It.IsAny<string>())).Returns(false);

            var sut = new BoardGameService(iService.Object, new Mappings());

            var response = sut.Remove(boardGameId);
            response.Should().Be(false);
        }
    }
}
