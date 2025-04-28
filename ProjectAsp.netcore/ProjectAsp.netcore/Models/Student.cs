using System.Collections.Generic;
using System;

namespace ProjectAsp.netcore.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Enrolled { get; set; }
        public ICollection<StudentCourse> Enrolment { get; set; } = new HashSet<StudentCourse>();
    }
}
