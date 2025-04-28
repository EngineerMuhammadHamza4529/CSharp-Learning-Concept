using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class TransactionDbContext : DbContext
    {

        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
