using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CODE_FIRST_APPROACH_OF_ENTITY_FRAMEWORK_IN_ASP.NET_MVC30.Models;

namespace CODE_FIRST_APPROACH_OF_ENTITY_FRAMEWORK_IN_ASP.NET_MVC30.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            List<Student> data = db.Students.ToList();
            return View(data);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted !!')</script>";
                    //ModelState.Clear();
                    TempData["InsertMessage"] = "Data Inserted !!";
                    ModelState.Clear();
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted !!')</script>";

                }
            }


            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Students.Find(id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            db.Entry(s).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                //ViewBag.UpdateMessage = "<script>alert('Data Updated !!')</script>";
                TempData["UpdateMessage"] = "Data Updated !!";
                ModelState.Clear();
                return RedirectToAction("Index");


            }
            else
            {
                ViewBag.UpdateMessage = "<script>alert('Data Not Updated !!')</script > ";
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var StudentID = db.Students.Find(id);
            return View(StudentID);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            db.Entry(s).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "Data Deleted !!";
                ModelState.Clear();
                return RedirectToAction("Index");

            }
            else
            {

                ViewBag.DeleteMessage = "<script>alert('Data Not Deleted !!')</script > ";

            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var DetailsID = db.Students.Find(id);
            return View(DetailsID);
        }
    }
}