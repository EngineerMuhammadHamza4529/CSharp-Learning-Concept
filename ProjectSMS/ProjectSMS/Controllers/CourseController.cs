using Microsoft.AspNetCore.Mvc;
using ProjectSMS.Data;

namespace ProjectSMS.Controllers
{   
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _context.Courses.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
    }
}
