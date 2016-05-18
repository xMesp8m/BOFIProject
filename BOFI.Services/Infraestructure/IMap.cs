using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BOFI.Services.Infraestructure
{
    public interface IMap
    {
        IMapper Mapper { get; set; }
    }
}
