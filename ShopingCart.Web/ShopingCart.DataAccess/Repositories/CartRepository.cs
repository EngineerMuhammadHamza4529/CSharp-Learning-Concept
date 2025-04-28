using ShopingCart.DataAccess.Data;
using ShopingCart.Models;
using System.Linq.Expressions;

namespace ShopingCart.DataAccess.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void DecrementCartItem(Cart cart, int v)
        {
            if (cart.Count > v)
            {
                cart.Count -= v;
            }
            else
            {
                cart.Count = 0;
            }
            _context.Update(cart);
        }

        public void IncrementCartItem(Cart cartItem, int count)
        {
            cartItem.Count += count;
            _context.Update(cartItem);
        }
    }
}