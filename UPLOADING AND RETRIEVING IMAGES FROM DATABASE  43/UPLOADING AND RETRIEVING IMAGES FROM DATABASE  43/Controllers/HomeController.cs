using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPLOADING_AND_RETRIEVING_IMAGES_FROM_DATABASE__43.Models;

namespace UPLOADING_AND_RETRIEVING_IMAGES_FROM_DATABASE__43.Controllers
{
    public class HomeController : Controller
    {
        NewDBEntities db = new NewDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            string filename = Path.GetFileNameWithoutExtension(s.ImageFile.FileName);
            string extension = Path.GetExtension(s.ImageFile.FileName);
            filename = filename + extension;
            s.Image_Path = "~/images/" + filename;
            filename = Path.Combine(Server.MapPath("~/images/"), filename);
            s.ImageFile.SaveAs(filename);
            db.Students.Add(s);

            int a = db.SaveChanges();
            if (a > 0)
            {
                ViewBag.Message = "<script>alert('Record Inserted :')</script>";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "<script>alert('Record Not Inserted :')</script>";
            }

            return View();
        }
    }
}