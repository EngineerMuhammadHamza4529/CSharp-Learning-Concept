using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopingCart.DataAccess.Repositories;
using ShopingCart.DataAccess.ViewModels;
using ShopingCart.Models;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using ZendeskApi_v2.Requests.HelpCenter;

namespace ShopingCart.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostingEnvioronment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvioronment = hostingEnvironment;
        }
        #region APICALL
        public IActionResult AllProducts()
        {       
            var products = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return Json(new { data = products });
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            ProductVM vm = new ProductVM();
            {
                vm.Product = new();
                vm.Categories = _unitOfWork.Category.GetAll().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            }
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Product = _unitOfWork.Product.GetT(x => x.Id == id);
                if (vm.Product == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(ProductVM vm, IFormFile? File)
        {
            if (ModelState.IsValid)
            {

                vm.Product.Description = Regex.Replace(vm.Product.Description, @"<\/?p>", "");

                string Filename = string.Empty;
                if (File != null)
                {
                    string uploadDir = Path.Combine(_hostingEnvioronment.WebRootPath, "ProductImage");
                    Filename = Guid.NewGuid().ToString() + "-" + File.FileName;
                    string FilePath = Path.Combine(uploadDir, Filename);

                    if (vm.Product.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(_hostingEnvioronment.WebRootPath,
                            vm.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(FilePath, FileMode.Create))
                    {
                        File.CopyTo(fileStream);
                    }
                    vm.Product.ImageUrl = @"\ProductImage\" + Filename;
                }
                if (vm.Product.Id == 0)
                {
                    _unitOfWork.Product.add(vm.Product);
                    TempData["success"] = "Product Created Done!!";
                }
                else
                {
                    _unitOfWork.Product.Update(vm.Product);
                    TempData["success"] = "Product Update Done!!";
                }
                _unitOfWork.save();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");           
        }


        #region DeleteAPICALL
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var Product = _unitOfWork.Product.GetT(x => x.Id == id);
            if (Product == null)
            {
                return Json(new { success = false, message = "Error in Fetching Data!!" });
            }
            else
            {
                var oldImagePath = Path.Combine(_hostingEnvioronment.WebRootPath, Product.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
                _unitOfWork.Product.Delete(Product);
                _unitOfWork.save();
                return Json(new { success = true, message = "Product Deleted!!" });
            }
           
        }


        #endregion









    }
}

