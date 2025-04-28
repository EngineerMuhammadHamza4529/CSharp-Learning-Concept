using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.net_in_mvc_COMPARE_DATA_ANNOTATION_25.Models;

namespace asp.net_in_mvc_COMPARE_DATA_ANNOTATION_25.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student s)
        {
            if (ModelState.IsValid == true)
            {
                ViewData["SucessMassage"] = "<script>alert('Data has been Submitted :')</script>";
                ModelState.Clear();
            }
            return View();
        }
    }
}