using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIBattles.Website.Controllers
{
    public class BattlesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            return View();
        }
    }
}