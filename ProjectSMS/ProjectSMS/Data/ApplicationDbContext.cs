using Microsoft.EntityFrameworkCore;
using ProjectSMS.Models;

namespace ProjectSMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Course> Courses { get; set; }
    }
}
