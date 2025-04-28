using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.net_in_mvc_DataAnotation_21.Models;
namespace asp.net_in_mvc_DataAnotation_21.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Employee e)
        {
            if(ModelState    .IsValid == true)
            {
                ViewData["SucessMassage"] = "<script>alert('Data has been Submited :')</script>";
                ModelState.Clear();
            }
            return View();
        }
    }
}