using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AUTHORIZE_FILTER_IN_ASP.NET_MVC_PART_1.Models;

namespace AUTHORIZE_FILTER_IN_ASP.NET_MVC_PART_1.Controllers
{
    public class LoginController : Controller
    {
        LoginDBEntities db = new LoginDBEntities();
        private object formAuthentication;

        // GET: Login
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult login(User u , string ReturnUrl)
        {
            if (Isvalid(u) == true)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                Session["username"] = u.Username.ToString();
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
        }

        public bool Isvalid(User u)
        {
            var credential = db.Users.Where(model => model.Username == u.Username && model.Password == u.Password).FirstOrDefault();
            return (u.Username == credential.Username && u.Password == credential.Password);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); //Cookie is distroyed.
            Session["Username"] = null;
            return RedirectToAction("login" , "Login");
           
        }
    }
}