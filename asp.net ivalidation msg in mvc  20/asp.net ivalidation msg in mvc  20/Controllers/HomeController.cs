using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_ivalidation_msg_in_mvc__20.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string fullname , string Age , string Email , string Submit)
        {
            if(fullname.Equals("") == true)
            {
                ModelState.AddModelError("fullname" , "Full name is reaquired : ");
            }
            if(Age.Equals("") == true)
            {
                ModelState.AddModelError("Age", "Age Is required : ");
            }
            if(Email.Equals("") == true)
            {
                ModelState.AddModelError("Email", "Email is required : ");
            }
            if(ModelState.IsValid == true)
            {
                ViewData["SucessMassage"] = "<script>alert('Data has been Submited !!')</script>";
                ModelState.Clear();
            }
            return View();
        }
    }
}