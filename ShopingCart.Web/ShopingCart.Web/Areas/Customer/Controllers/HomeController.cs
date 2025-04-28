using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopingCart.DataAccess.Repositories;
using ShopingCart.Models;
using System.Diagnostics;
using System.Security.Claims;
using Cart = ShopingCart.Models.Cart;

namespace ShopingCart.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitOfwork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfwork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfwork.Product.GetAll(includeProperties: "Category");
            return View(products);
        }


        [HttpGet]
        public IActionResult Details(int? productId) 
        {
            Cart cart = new Cart()
            {
                Product = _unitOfwork.Product.GetT(x => x.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = (int)productId
            };
            return View(cart);
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Cart cart)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                cart.ApplicationUserId = claims.Value;

                var cartItem = _unitOfwork.Cart.GetT(x => x.ProductId == cart.ProductId
                && x.ApplicationUserId == claims.Value);

                if (cartItem == null)
                {
                    _unitOfwork.Cart.add(cart);
                    _unitOfwork.save();
                    HttpContext.Session.SetInt32("SessionCart",
                    _unitOfwork.Cart.GetAll(x => x.ApplicationUserId == claims.Value).ToList().Count);
                }
                else
                {
                    _unitOfwork.Cart.IncrementCartItem(cartItem, cart.Count);
                    _unitOfwork.save();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}