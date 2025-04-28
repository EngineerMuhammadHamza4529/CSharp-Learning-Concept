using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_in_mvc_7.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["var1"] = "Massage from view data";
            ViewBag.var2 = "Massage from view bag ";
            TempData["var3"] = "Massage from Temp Data";

            string[] game = { "Hockey", "Circket", "FootBall" };
            TempData["mygame"] = game;
            return View();
        }

        public ActionResult AboutUs()
        { 
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}