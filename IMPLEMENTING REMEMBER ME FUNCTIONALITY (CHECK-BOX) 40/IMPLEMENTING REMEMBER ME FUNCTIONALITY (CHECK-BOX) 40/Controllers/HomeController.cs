using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMPLEMENTING_REMEMBER_ME_FUNCTIONALITY__CHECK_BOX__40.Models;

namespace IMPLEMENTING_REMEMBER_ME_FUNCTIONALITY__CHECK_BOX__40.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index" , "login");
            }
            return View();
        }
    }
}