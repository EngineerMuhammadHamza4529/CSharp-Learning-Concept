using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCAFFOLD_COLUMN_DATA_ANNOTATION_IN_ASP.NET_MVC_36.Models
{
    public class Person
    {
        public String Name { get; set; }
        public String Gender { get; set; }
        public int Age { get; set; }

        [ScaffoldColumn(false)]
        public String Contact { get; set; }

        [ScaffoldColumn(false)]
        public String Address { get; set; }
    }
}