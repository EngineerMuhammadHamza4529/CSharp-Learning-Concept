using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CREATING_SIGNUP_WITH_LOGIN_WITH_SESSION_AND_LOGOUT.Models;

namespace CREATING_SIGNUP_WITH_LOGIN_WITH_SESSION_AND_LOGOUT.Controllers
{
    public class LoginController : Controller
    {
        SignupLoginEntities db = new SignupLoginEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(User u)
        {
            var data = db.Users.Where(model => model.UserName == u.UserName && model.Password == u.Password).FirstOrDefault();
            if (data != null)
            {
                Session["userID"] = u.Id.ToString();
                Session["username"] = u.UserName.ToString();
                TempData["LoginSucessMessage"] = "<script>alert('Login Sucessfully!!')</script>";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Username & Password is Incorrect!!')</script>";
                return View();
            }

        }


        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User u)
        {
            if (ModelState.IsValid == true)
            {
                db.Users.Add(u);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Registered Sucessfully!!')</script>";
                    ModelState.Clear();
                    return RedirectToAction("login", "Login");

                }

            }
            return View();
        }
    }
}