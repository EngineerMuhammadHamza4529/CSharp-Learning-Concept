using System;
using System.Collections.Generic;

namespace asp.netcore1.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Enrolled { get; set; }
        public ICollection<StudentCourse> Enrolment { get; set; }
    }
}
