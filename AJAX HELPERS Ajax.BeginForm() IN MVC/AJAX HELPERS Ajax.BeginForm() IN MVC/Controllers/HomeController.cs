using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AJAX_HELPERS_Ajax.BeginForm___IN_MVC.Models;

namespace AJAX_HELPERS_Ajax.BeginForm___IN_MVC.Controllers
{
    
    public class HomeController : Controller
    {
        EmployeeDBEntities db = new EmployeeDBEntities();
        // GET: Home
        public ActionResult Index(Employee e)
        {
            
            return View(db.Employees.ToList());
        }

        [HttpPost]

        public ActionResult Index(string q)
        {
            if (string.IsNullOrEmpty(q) == false)
            {
                List<Employee> emp = db.Employees.Where(model => model.Name.StartsWith(q)).ToList();
                return PartialView("_SearchData",emp);
            }
            else
            {
                List<Employee> emp = db.Employees.ToList();
                return PartialView("_SearchData", emp);
            }
            return View();
        }
    }
}