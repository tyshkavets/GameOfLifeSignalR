using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tyshka.GameOfLife.Models;

namespace Tyshka.GameOfLife.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Seconds = GameThreadContainer.Seconds;
            ViewBag.Paused = GameThreadContainer.GetPaused() ? "Pause" : "Resume";
            return View();
        }

    }
}
