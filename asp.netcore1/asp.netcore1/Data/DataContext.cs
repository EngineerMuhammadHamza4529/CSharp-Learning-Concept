using Microsoft.EntityFrameworkCore;

namespace asp.netcore1.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        //Change sqlDataTable:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student_Table");
            modelBuilder.Entity<StudentCourse>().ToTable("StudentCourse_Table");
            modelBuilder.Entity<Course>().ToTable("Course_Table");
        }
    }
}
