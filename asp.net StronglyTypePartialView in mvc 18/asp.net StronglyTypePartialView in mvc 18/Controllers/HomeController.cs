using asp.net_StronglyTypePartialView_in_mvc_18.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace asp.net_StronglyTypePartialView_in_mvc_18.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        List<Product> productList = new List<Product>()
        {  new Product
        {id = 1 , name="Reyben" , price = 40000.00 , picture="~/Images/Reyben.png" },
            new Product
        {id = 2 , name="Reyben" , price = 40000.00 , picture="~/Images/Reyben.png" },
            new Product
        {id = 3 , name="Reyben" , price = 40000.00 , picture="~/Images/Reyben.png" },
              new Product
        {id = 4 , name="Reyben" , price = 40000.00 , picture="~/Images/Reyben.png" },
        };
        public ActionResult Index()
        {
            return View(productList);
        }
    }
}