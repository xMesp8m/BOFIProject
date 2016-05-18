using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOFI.Dtos;

namespace BOFI.Contracts.Services
{
    public interface IBoardGameService : IGenericRepository<BoardGameDto>
    {
    }
}
