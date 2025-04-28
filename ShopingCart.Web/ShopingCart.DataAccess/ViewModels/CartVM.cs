using ShopingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.DataAccess.ViewModels
{
    public class CartVM
    {
        public Cart Carts { get; set; } = new Cart();
        public IEnumerable<Cart> Cart { get; set; } = new List<Cart>();
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<Cart> ListOfCart { get; set; }
    }
}
