using Microsoft.AspNetCore.Mvc;
using ProjectAsp.netcore.Data;
using ProjectAsp.netcore.Models;
using System.Linq;

namespace ProjectAsp.netcore.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _context;
        public CourseController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// HttpGet Request:
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var course = _context.Courses.Where(model => model.ID == id).FirstOrDefault();
            return View(course);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var course = _context.Courses.Where(model => model.ID == id).FirstOrDefault();

            return View(course);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _context.Courses.Where(model => model.ID == id).FirstOrDefault();

            return View(course);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.Where(model => model.ID == id).FirstOrDefault();

            return View(course);
        }

        /// <summary>
        /// HttpPost Request:
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpPost]
        public IActionResult Create(Course model)
        {
            _context.Courses.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Course model)
        {

            _context.Courses.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Course model)
        {

            _context.Courses.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Details(Course model)
        {

            _context.Courses.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
