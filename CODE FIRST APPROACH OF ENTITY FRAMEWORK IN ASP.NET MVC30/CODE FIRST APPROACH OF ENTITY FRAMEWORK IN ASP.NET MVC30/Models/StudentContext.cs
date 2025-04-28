using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CODE_FIRST_APPROACH_OF_ENTITY_FRAMEWORK_IN_ASP.NET_MVC30.Models
{
    public class StudentContext : DbContext
    {
        public  DbSet<Student> Students { get; set; }
    }
}