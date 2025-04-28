using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.net_in_mvc_5.Models;

namespace asp.net_in_mvc_5.Controllers
{
    public class HoimeController : Controller
    {
        // GET: Hoime
        public ActionResult Index()
        {
            ViewData["Massage"] = "Massage from View Data  : ";
            ViewData["CurrentTime"] = DateTime.Now.ToLongTimeString();

           
            string[] Fruits = { "Apple", "Banana", "Graps", "Orange" };
            ViewData["FruitsArray"]=Fruits;

            ViewData["SportsList"] = new List<string>() { "Circkrt", "Hockey", "FootBall", "HolyBall" };

            Employee emp = new Employee();
            emp.EmpID = 201907002;
            emp.EmpName = "Hamza Shaikh";
            emp.EmpDesignation = "Manager";

            ViewData["Employee"] = emp;
            return View();
        }
    }
}