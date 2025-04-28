using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopingCart.DataAccess.Repositories;
using ShopingCart.DataAccess.ViewModels;
using ShopingCart.Models;
using ShopingCart.Utility;
using Stripe.Checkout;
using System.Security.Claims;

namespace ShopingCart.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private IUnitOfWork _unitOfWork;      
        public CartVM vm { get; set; }          
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            CartVM vm = new CartVM()
            {
               ListOfCart = _unitOfWork.Cart.GetAll(x => x.ApplicationUserId == claims.Value, includeProperties: "Product"),
               OrderHeader = new OrderHeader()
            };

            
            foreach (var item in vm.ListOfCart)
            {
                vm.OrderHeader.OrderTotal += (item.Product.Price * item.Count);
            }

            return View(vm);    
        }

        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            CartVM vm = new CartVM()
            {
                ListOfCart = _unitOfWork.Cart.GetAll(x => x.ApplicationUserId == claims.Value, includeProperties: "Product"),
                OrderHeader = new OrderHeader()
            };
            vm.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.GetT(x => x.Id == claims.Value);
            vm.OrderHeader.Name = vm.OrderHeader.ApplicationUser.Name;
            vm.OrderHeader.Phone = vm.OrderHeader.ApplicationUser.PhoneNumber;
            vm.OrderHeader.Address = vm.OrderHeader.ApplicationUser.Address;
            vm.OrderHeader.City = vm.OrderHeader.ApplicationUser.City;
            vm.OrderHeader.State = vm.OrderHeader.ApplicationUser.State;
            vm.OrderHeader.PostalCode = vm.OrderHeader.ApplicationUser.PinCode;

            foreach (var item in vm.ListOfCart)
            {
                vm.OrderHeader.OrderTotal += (item.Product.Price * item.Count);
            }
            
            return View(vm);
        }



        [HttpPost]
        public IActionResult Summary(CartVM vm)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            
            vm.ListOfCart = _unitOfWork.Cart.GetAll(x => x.ApplicationUserId == claims.Value, includeProperties: "Product");
            vm.OrderHeader.OrderStatus = OrderStatus.StatusPending;
            vm.OrderHeader.PaymentStatus = PaymentStatus.StatusPending;
            vm.OrderHeader.DateOfOrder = DateTime.Now;
            vm.OrderHeader.ApplicationUserId = claims.Value;

            foreach (var item in vm.ListOfCart)
            {
                vm.OrderHeader.OrderTotal += (item.Product.Price * item.Count);
            }
            _unitOfWork.OrderHeader.add(vm.OrderHeader);
            _unitOfWork.save();

            foreach (var item in vm.ListOfCart)
            {
                OrderDetail OD = new OrderDetail()
                {
                    ProductId = item.ProductId,
                    OrderHeaderId = vm.OrderHeader.Id,
                    Count = item.Count,
                    Price = item.Product.Price
                };
                _unitOfWork.OrderDetail.add(OD);
                _unitOfWork.save();
            }

            var domain = "http://localhost:7129";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment", // Updated mode value
                SuccessUrl = "http://localhost:7129/customer/cart/ordersuccess?id=" + vm.OrderHeader.Id,
                CancelUrl = "http://localhost:7129/customer/cart/Index"
            };

            foreach (var item in vm.ListOfCart)
            {
                var LineItemsOptions = new SessionLineItemOptions()
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Product.Price * 100),
                        Currency = "USD",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.Name,
                        },
                    },
                    Quantity = item.Count
                };
                options.LineItems.Add(LineItemsOptions);
            }

            var service = new SessionService();
            Session session = service.Create(options);
            _unitOfWork.OrderHeader.PaymentStatus(vm.OrderHeader.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.save();

            _unitOfWork.Cart.DeleteRange(vm.ListOfCart);
            _unitOfWork.save();

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }



        [HttpGet]
        public IActionResult OrderSuccess(int id)
        {
            var orderHeader = _unitOfWork.OrderHeader.GetT(x => x.Id == id);
            var sessionService = new SessionService();
            Session session = sessionService.Get(orderHeader.SessionId);

            if (session.PaymentStatus.ToLower() == "paid")
            {
                _unitOfWork.OrderHeader.UpdateStatus(id, OrderStatus.StatusApproved, PaymentStatus.StatusApproved);
            }

            List<Cart> cart = _unitOfWork.Cart.GetAll(x => x.ApplicationUserId == orderHeader.ApplicationUserId).ToList();
            _unitOfWork.Cart.DeleteRange(cart);
            _unitOfWork.save();

            return View(id);
        }


        //public IActionResult Ordersuccess(int id)
        //{
        //    var OrderHeader = _unitOfWork.OrderHeader.GetT(x => x.Id == id);
        //    var service = new SessionService();
        //    Session session = service.Get(OrderHeader.SessionId);
        //    if (session.PaymentStatus.ToLower() == "paid")
        //    {
        //        _unitOfWork.OrderHeader.UpdateStatus(id, OrderStatus.StatusApproved, PaymentStatus.StatusApproved);
        //    }

        //    List<Cart> cart = _unitOfWork.Cart.GetAll(x => x.ApplicationUserId == OrderHeader.ApplicationUserId).ToList();
        //    _unitOfWork.Cart.DeleteRange(cart);
        //    _unitOfWork.save();
        //    return View(id);
        //}


        [HttpGet]
        public IActionResult plus(int id)
        {
            var cart = _unitOfWork.Cart.GetT(x => x.Id == id);
            _unitOfWork.Cart.IncrementCartItem(cart, 1);
            _unitOfWork.save();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult minus(int id)
        {
            var cart = _unitOfWork.Cart.GetT(x => x.Id == id);
            if (cart.Count <= 1)
            {
                _unitOfWork.Cart.Delete(cart);
            }
            else
            {
                _unitOfWork.Cart.DecrementCartItem(cart, 1);
            }
            _unitOfWork.save();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var cart = _unitOfWork.Cart.GetT(x => x.Id == id);
            _unitOfWork.Cart.Delete(cart);
            _unitOfWork.save();
            return RedirectToAction(nameof(Index));
        }

    }
}
