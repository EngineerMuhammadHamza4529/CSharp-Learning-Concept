using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Linq;

namespace Project.Controllers
{
    public class StudentController : Controller
    {

        private readonly TransactionDbContext _context;
        public StudentController(TransactionDbContext context)
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
            var courses = _context.Students.ToList();
            return View(courses);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var course = _context.Students.Where(model => model.StudentID == id).FirstOrDefault();

            return View(course);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _context.Students.Where(model => model.StudentID == id).FirstOrDefault();

            return View(course);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _context.Students.Where(model => model.StudentID == id).FirstOrDefault();

            return View(course);
        }

        /// <summary>
        /// HttpPost Request:
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpPost]
        public IActionResult Create(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Student model)
        {

            _context.Students.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Student model)
        {

            _context.Students.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Details(Student model)
        {

            _context.Students.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
