using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LOGIN_FORM_WITH_SESSION_AND_LOGOUT_FUNCTIONALITY.Models;


namespace LOGIN_FORM_WITH_SESSION_AND_LOGOUT_FUNCTIONALITY.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}