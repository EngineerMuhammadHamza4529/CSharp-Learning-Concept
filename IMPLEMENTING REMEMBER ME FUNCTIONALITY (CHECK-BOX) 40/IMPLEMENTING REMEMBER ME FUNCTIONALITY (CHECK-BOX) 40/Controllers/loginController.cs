using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMPLEMENTING_REMEMBER_ME_FUNCTIONALITY__CHECK_BOX__40.Models;

namespace IMPLEMENTING_REMEMBER_ME_FUNCTIONALITY__CHECK_BOX__40.Controllers
{
    public class loginController : Controller
    {
        HttpCookie cookie = new HttpCookie("User");
        LoginDBEntities db = new LoginDBEntities();
        // GET: login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User u)
        {          
            if (ModelState.IsValid == true)
            {
                if (u.RememberMe == true)
                {
                    cookie["username"] = u.Username;
                    cookie["password"] = u.Password;
                    cookie.Expires = DateTime.Now.AddDays(2);
                    HttpContext.Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Response.Cookies.Add(cookie);
                }

                var credential = db.Users.Where(model => model.Username == u.Username && model.Password == u.Password).FirstOrDefault();
                if(credential != null)
                {
                    ViewBag.Message = "Login Failed !! ";
                    return View();                 
                }
                else
                {
                    Session["username"] = u.Username;
                    
                    return RedirectToAction("Index" , "Home");

                }
            }
            return View();
        }

        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "login");
        }
    }
}