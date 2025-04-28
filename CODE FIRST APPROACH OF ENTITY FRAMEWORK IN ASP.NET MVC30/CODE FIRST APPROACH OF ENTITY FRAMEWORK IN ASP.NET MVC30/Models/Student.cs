using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CODE_FIRST_APPROACH_OF_ENTITY_FRAMEWORK_IN_ASP.NET_MVC30.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string  Age  { get; set; }
    }
}