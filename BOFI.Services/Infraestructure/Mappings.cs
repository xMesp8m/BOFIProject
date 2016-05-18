using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BOFI.Dtos;
using BOFI.Model;

namespace BOFI.Services.Infraestructure
{
    public class Mappings : IMap
    {
        public IMapper Mapper { get; set; }

        public Mappings()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BoardGameDto, BoardGame>();
                c.CreateMap<BoardGame, BoardGameDto>();
            });
            Mapper = config.CreateMapper();
        }
    }
}
