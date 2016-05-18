using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOFI.API.Web.Infraestructure
{
    public class ResponseDto
    {
        public string StatusCode { get; set; }
        public int ErrorCount { get; set; }
        public List<string> Errors { get; set; }
        public dynamic Response { get; set; }
    }
}