using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreMVCImageUploadandRetrieve.Models
{
    public class ImageDbContext : DbContext
    {
        public ImageDbContext(DbContextOptions<ImageDbContext> options) : base(options) 
        {
             
        }

        public DbSet<ImageModel> Image { get; set;}
    }
}
