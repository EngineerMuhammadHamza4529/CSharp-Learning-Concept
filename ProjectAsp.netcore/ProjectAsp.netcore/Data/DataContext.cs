using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectAsp.netcore.Models;

namespace ProjectAsp.netcore.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
