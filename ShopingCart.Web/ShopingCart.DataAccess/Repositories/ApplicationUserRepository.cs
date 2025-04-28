using Microsoft.EntityFrameworkCore;
using ShopingCart.DataAccess.Data;
using ShopingCart.Models;

namespace ShopingCart.DataAccess.Repositories
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Add(ApplicationUser applicationUser)
        {
            _context.Set<ApplicationUser>().Add(applicationUser);
        }
    }
}