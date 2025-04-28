using ShopingCart.Models;

namespace ShopingCart.DataAccess.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        void Add(ApplicationUser applicationUser);
    }
}