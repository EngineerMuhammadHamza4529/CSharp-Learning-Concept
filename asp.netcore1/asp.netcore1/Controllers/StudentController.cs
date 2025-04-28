using asp.netcore1.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace asp.netcore1.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _context;
        public StudentController(DataContext context)
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
            var Student = _context.Students.ToList();

            return View(Student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            //var courses = _context.Courses.Select(x => new SelectListItem()
            //{
            //    Text = x.Title,
            //    Value = x.ID.ToString(),

            //}).ToList();
            //CreateStudentViewModel vm = new CreateStudentViewModel();
            //vm.Course = courses;
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var Student = _context.Students.Where(model => model.ID == id).FirstOrDefault();

            return View(Student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Student = _context.Students.Where(model => model.ID == id).FirstOrDefault();

            return View(Student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Student = _context.Students.Where(model => model.ID == id).FirstOrDefault();

            return View(Student);
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
