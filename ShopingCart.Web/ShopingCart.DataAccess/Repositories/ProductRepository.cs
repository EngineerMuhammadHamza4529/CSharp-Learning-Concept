using ShopingCart.DataAccess.Data;
using ShopingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void add(Microsoft.Build.Tasks.Deployment.Bootstrapper.Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Microsoft.Build.Tasks.Deployment.Bootstrapper.Product entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<Microsoft.Build.Tasks.Deployment.Bootstrapper.Product> entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Microsoft.Build.Tasks.Deployment.Bootstrapper.Product> GetAll(Expression<Func<Microsoft.Build.Tasks.Deployment.Bootstrapper.Product, bool>>? predicate = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Microsoft.Build.Tasks.Deployment.Bootstrapper.Product GetT(Expression<Func<Microsoft.Build.Tasks.Deployment.Bootstrapper.Product, bool>> predicate, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            var productDb = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productDb != null)
            {
                productDb.Name = product.Name;
                productDb.Description = product.Description;
                productDb.Price = product.Price;
                if (product.ImageUrl != null)
                {
                    productDb.ImageUrl = product.ImageUrl;
                }

            }
        }

        public void Update(Microsoft.Build.Tasks.Deployment.Bootstrapper.Product product)
        {
            throw new NotImplementedException();
        }
    }
}
