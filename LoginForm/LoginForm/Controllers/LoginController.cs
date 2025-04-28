using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginForm.Models;
namespace LoginForm.Controllers
{
    public class LoginController : Controller
    {
        LogInEntities db = new LogInEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginUser s)
        {
            if (ModelState.IsValid == true)
            {
                var credentails = db.LoginUsers.Where
                    (
                    model => model.Name == s.Name && model.Password == s.Password
                    ).FirstOrDefault();
                if (credentails == null)
                {
                    ViewBag.ErrorMessage = "Login Failed";
                    return View();
                }
                else
                {
                    Session["username"] = s.Name;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}