using Microsoft.EntityFrameworkCore;
using ProjectEcomm.Model;

namespace ProjectEcomm.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookWriter> BookWriters { get; set; }
        public DbSet<BookCover> BookCovers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Title = "Samsung",
                    DisplayOrder = 1,
                },
                new Category
                {
                    Id = 2,
                    Title = "Xiomi",
                    DisplayOrder = 2,
                },
                new Category
                {
                    Id = 3,
                    Title = "Nokia",
                    DisplayOrder = 3,
                });

        }
    }
}
