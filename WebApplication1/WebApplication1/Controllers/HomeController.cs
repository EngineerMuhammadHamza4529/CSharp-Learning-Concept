 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public string show()
        {
            return "This the second action method  of home controller : ";
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public int studentID(int id)
        {
            return id;
        }
    }
}