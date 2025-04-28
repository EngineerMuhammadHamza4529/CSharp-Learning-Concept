using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_APPLICATION_WITH_IMAGES_44.Models;

namespace CRUD_APPLICATION_WITH_IMAGES_44.Controllers
{
    public class HomeController : Controller
    {
        ExampleDBEntities db = new ExampleDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.EmployeeDBs.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeDB e)
        {
            if (ModelState.IsValid == true)
            {
                string filename = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
            }
            return View();
        }
    }
}