using Microsoft.EntityFrameworkCore;
using tEST.Models;

namespace tEST.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; }
    }
}
