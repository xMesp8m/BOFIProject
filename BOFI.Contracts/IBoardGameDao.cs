using System.Collections.Generic;
using BOFI.Model;

namespace BOFI.Contracts.Dao
{
    public interface IBoardGameDao
    {
        IEnumerable<BoardGame> GetAll();
        BoardGame Add(BoardGame boardGame);
        bool Update(BoardGame boardGame);
        bool Remove(string boardGameId);
        BoardGame GetById(string boardGameId);
    }
}
