using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMPLEMENTING_SEARCH_FUNCTIONALITY_42.Models;


namespace IMPLEMENTING_SEARCH_FUNCTIONALITY_42.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: Home
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Name")
            {
                var data = db.EmployeeDBs.Where(model => model.Name.StartsWith(search)).ToList();
                return View(data);
            }
            else if (searchBy == "Gender")
            {
                var data = db.EmployeeDBs.Where(model => model.Gender == search).ToList();
                return View(data);
            }
            else
            {
                var data = db.EmployeeDBs.ToList();
                return View(data);
            }

        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDB employeeDB = db.EmployeeDBs.Find(id);
            if (employeeDB == null)
            {
                return HttpNotFound();
            }
            return View(employeeDB);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Gender,Age,Designation")] EmployeeDB employeeDB)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeDBs.Add(employeeDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeDB);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDB employeeDB = db.EmployeeDBs.Find(id);
            if (employeeDB == null)
            {
                return HttpNotFound();
            }
            return View(employeeDB);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Gender,Age,Designation")] EmployeeDB employeeDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDB);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDB employeeDB = db.EmployeeDBs.Find(id);
            if (employeeDB == null)
            {
                return HttpNotFound();
            }
            return View(employeeDB);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDB employeeDB = db.EmployeeDBs.Find(id);
            db.EmployeeDBs.Remove(employeeDB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
