using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOFI.Web.Controllers
{
    public class BoardGameController : Controller
    {
        // GET: BoardGame
        public ActionResult Index()
        {
            return View();
        }

    }
}