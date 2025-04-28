using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INTRODUCTION_TO_AJAX_WITH_ASP.NET_MVC.Models;

namespace INTRODUCTION_TO_AJAX_WITH_ASP.NET_MVC.Controllers
{

    public class HomeController : Controller
    {
        EmployeeDBEntities db = new EmployeeDBEntities();
        // GET: Home
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                db.Employees.Add(e);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    return Json("Data Inserted!!"); // json stands for javascriptobjectnotation:

                }
                else
                {
                    return Json("Data Not Inserted!!");
                }
            }
            return View();
        }
    }
}