using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BOFI.Contracts;
using BOFI.Contracts.Dao;
using BOFI.Contracts.Services;
using BOFI.Dao;
using BOFI.Dtos;
using BOFI.Model;
using BOFI.Services.Infraestructure;

namespace BOFI.Services
{
    public class BoardGameService : IBoardGameService
    {
        private readonly IBoardGameDao _boardGameDao;
        private readonly IMapper _mappings;

        public BoardGameService(IBoardGameDao boardGameDao , IMap mappings)
        {
            _boardGameDao = boardGameDao;
            _mappings = mappings.Mapper;
        }

        public BoardGameService() :this(new BoardGameDao(), new Mappings())
        {
        }

        public BoardGameDto Add(BoardGameDto boardGame)
        {
            boardGame.DateCreated = DateTime.Now;
            boardGame.DateUpdated = DateTime.Now;
            boardGame.Id = Guid.NewGuid().ToString();
            var request = _mappings.Map<BoardGame>(boardGame);
            var response = _boardGameDao.Add(request);
            return response == null ? null : boardGame;
        }

        public bool Update(BoardGameDto boardGame)
        {
            boardGame.DateUpdated = DateTime.Now;
            var request = _mappings.Map<BoardGame>(boardGame);
            var response = _boardGameDao.Update(request);
            return response;

        }

        public bool Remove(string boardGameId)
        {
            var response = _boardGameDao.Remove(boardGameId);
            return response;
        }

        public IEnumerable<BoardGameDto> GetAll()
        {
            var query = _boardGameDao.GetAll();
            var response = _mappings.Map<IEnumerable<BoardGame>, IEnumerable<BoardGameDto>>(query);
            return response;
        }

        public BoardGameDto GetById(string boardGameId)
        {
            var query = _boardGameDao.GetById(boardGameId);
            var response = _mappings.Map<BoardGameDto>(query);
            return response;
        }
    }

}
