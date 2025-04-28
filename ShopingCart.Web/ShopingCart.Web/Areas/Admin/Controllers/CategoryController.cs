using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopingCart.DataAccess.Repositories;
using ShopingCart.DataAccess.ViewModels;
using ShopingCart.Models;

namespace ShopingCart.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize (Roles = "Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _UnitOfWork;

        public CategoryController(IUnitOfWork unitOfWork) 
        {
            _UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.categories = _UnitOfWork.Category.GetAll();
            return View(categoryVM);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVM vm = new CategoryVM();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Category = _UnitOfWork.Category.GetT(x => x.Id == id);
                if (vm.Category == null)
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

        public IActionResult CreateUpdate(CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Category.Id == 0)
                {
                    _UnitOfWork.Category.add(vm.Category);
                    TempData["success"] = "Category Created Done";
                }
                else
                {
                    _UnitOfWork.Category.Update(vm.Category);
                    TempData["success"] = "Category Update Done";
                }

                _UnitOfWork.save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var Category = _UnitOfWork.Category.GetT(x => x.Id == id);
            if (Category == null)
            {
                return NotFound();
            }
            return View(Category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var Category = _UnitOfWork.Category.GetT(x => x.Id == id);
            if (Category == null)
            {
                return NotFound();
            }
            _UnitOfWork.Category.Delete(Category);
            _UnitOfWork.save();
            TempData["success"] = "Category Deleted Done!!";
            return RedirectToAction("Index");
        }
        


    }
}
