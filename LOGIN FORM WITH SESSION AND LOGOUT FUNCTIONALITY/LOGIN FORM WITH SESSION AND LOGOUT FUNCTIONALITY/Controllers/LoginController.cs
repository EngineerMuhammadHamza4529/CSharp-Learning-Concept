using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LOGIN_FORM_WITH_SESSION_AND_LOGOUT_FUNCTIONALITY.Models;

namespace LOGIN_FORM_WITH_SESSION_AND_LOGOUT_FUNCTIONALITY.Controllers
{
    public class LoginController : Controller
    {
        LogInDBEntities db = new LogInDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User s)
        {
            if (ModelState.IsValid == true)
            {
                var credentials = db.Users.Where(model => model.UserName == s.UserName && model.Password == s.Password).FirstOrDefault();
                if (credentials == null)
                {
                    ViewBag.ErrorMessage = "LogIn Failed :";
                    return View();
                }
                else
                {
                    Session["UserName"] = s.UserName;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();


        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}