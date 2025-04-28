using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDataBaseFirstApproach.Models;

namespace TestDataBaseFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        DataBaseFirstApproachEntities db = new DataBaseFirstApproachEntities();
        // GET: Home

        [HttpGet]
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            db.Students.Add(s);
            int data = db.SaveChanges();
            return View(data);
           
        }
          
        
    }
}