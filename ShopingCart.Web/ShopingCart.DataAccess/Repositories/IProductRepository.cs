﻿using ShopingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.DataAccess.Repositories
{

    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
