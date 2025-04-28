using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace ProjectAsp.netcore.ViewModel
{
    public class CreateStudentViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Enrolled { get; set; }

        public IList<SelectListItem> Courses { get; set; }
    }
}
