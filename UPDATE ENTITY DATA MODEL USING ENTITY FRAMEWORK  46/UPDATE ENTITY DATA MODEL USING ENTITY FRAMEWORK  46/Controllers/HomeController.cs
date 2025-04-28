using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPDATE_ENTITY_DATA_MODEL_USING_ENTITY_FRAMEWORK__46.Models;

namespace UPDATE_ENTITY_DATA_MODEL_USING_ENTITY_FRAMEWORK__46.Controllers
{
    public class HomeController : Controller
    {
        UpdateEntityEntities db = new UpdateEntityEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        public ActionResult employee()
        {
            var data = db.Employees.ToList();
            return View(data);
        }
    }
}