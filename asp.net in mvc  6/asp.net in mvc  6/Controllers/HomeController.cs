using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.net_in_mvc__6.Models;
namespace asp.net_in_mvc__6.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Massage = "Massage from View Bag : ";
            ViewBag.CurrentDate = DateTime.Now.ToLongTimeString();
            string[] fruits = { "Apple", "Banana", "Grapes" };
            ViewBag.FruitsArray = fruits;

            ViewBag.sportslist = new List<string>() {  "Football", "Hockey", "Baseball" };

            Employee emp = new Employee();
            emp.empid = 201907001;
            emp.empname = "Zeeshan";
            emp.empDesination = "Developer";
           // ViewBag.Employee = emp;
            
            return View();
        }
    }
}