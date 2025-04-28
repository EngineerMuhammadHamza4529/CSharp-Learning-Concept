using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CREATING_SIGNUP_WITH_LOGIN_WITH_SESSION_AND_LOGOUT.Models;

namespace CREATING_SIGNUP_WITH_LOGIN_WITH_SESSION_AND_LOGOUT.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("login" , "Login");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("login", "Login");
        }
    }
}