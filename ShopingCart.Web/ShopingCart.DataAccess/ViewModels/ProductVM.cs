using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopingCart.Models;
//using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace ShopingCart.DataAccess.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; } = new Product();

        [ValidateNever]
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
