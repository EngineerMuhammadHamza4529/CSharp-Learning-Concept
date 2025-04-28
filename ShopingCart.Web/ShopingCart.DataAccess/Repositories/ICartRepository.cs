using ShopingCart.Models;

namespace ShopingCart.DataAccess.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        void DecrementCartItem(Cart cart, int v);
        void IncrementCartItem(Cart cartItem, int count);
    }
}