using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOFI.Services
{
    public class ServicesContext
    {
        private BoardGameService _boardGame;

        public BoardGameService BoardGame
        {
            get { return _boardGame ?? new BoardGameService(); }
        }
    }
}
