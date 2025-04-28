using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectAsp.netcore.Data;
using ProjectAsp.netcore.Models;
using ProjectAsp.netcore.ViewModel;
using System.Linq;

namespace ProjectAsp.netcore.Controllers
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
            var course = _context.Courses.Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.ID.ToString()
            }).ToList();
            CreateStudentViewModel vm = new CreateStudentViewModel();
            vm.Courses = course;
            return View(vm);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Student = _context.Students.Include(x => x.Enrolment).ThenInclude(y => y.course).
                FirstOrDefault(model => model.ID == id);

            return View(Student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Student = _context.Students.Include(x => x.Enrolment).Where(y => y.ID == id).FirstOrDefault();
            var selectedIds = Student.Enrolment.Select(x => x.CourseID).ToList();
            var items = _context.Courses.Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.ID.ToString(),
                Selected =  selectedIds.Contains(x.ID)
            }).ToList();

            CreateStudentViewModel vm = new CreateStudentViewModel();

            vm.Name =  Student.Name;
            vm.Enrolled = Student.Enrolled;
            vm.Courses = items;
            return View(vm);
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentViewModel vm)
        {
            var student = new Student
            {
                Name = vm.Name,
                Enrolled = vm.Enrolled
            };

            var SelectedCourse = vm.Courses.Where(x => x.Selected).Select(y => y.Value).ToList();
            var SelectedCourse1 = vm.Courses.Where(x => x.Selected == true).ToList();
            foreach (var item in SelectedCourse)
            {
                student.Enrolment.Add(new StudentCourse()
                {
                    CourseID = int.Parse(item)
                });
            }
            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(CreateStudentViewModel vm)
        {
            var student = _context.Students.Find(vm.ID);
            
                student.Name = vm.Name;
                student.Enrolled = vm.Enrolled;

            var studentByIds = _context.Students.Include(x => x.Enrolment).FirstOrDefault(y => y.ID == vm.ID);
            var existingIds = studentByIds.Enrolment.Select(x => x.CourseID).ToList();
            var selectedIds = vm.Courses.Where(x => x.Selected).Select(y => y.Value).Select(int.Parse).ToList();
            var ToAdd = selectedIds.Except(existingIds);
            var ToRemove = existingIds.Except(selectedIds);
            student.Enrolment = student.Enrolment.Where(x => !ToRemove.Contains(x.CourseID)).ToList();

            foreach (var item in ToAdd)
            {
                student.Enrolment.Add(new StudentCourse()
                {
                    CourseID = item
                });
            }
            _context.Students.Update(student);
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
