using ASP.NETCoreMVCImageUploadandRetrieve.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ASP.NETCoreMVCImageUploadandRetrieve.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ImageDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImagesController(ImageDbContext context , IWebHostEnvironment hostEnvironment) 
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        /// <summary>
        /// HttpGet Request:
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Index()
        {
            var Image = _context.Image.ToList();

            return View(Image);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var Image = _context.Image.Where(model => model.ImageID == id).FirstOrDefault();
            return View(Image);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var Image = _context.Image.Where(model => model.ImageID == id).FirstOrDefault();

            return View(Image);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Image = _context.Image.Where(model => model.ImageID == id).FirstOrDefault();

            return View(Image);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Image = _context.Image.Where(model => model.ImageID == id).FirstOrDefault();

            return View(Image);
        }

        /// <summary>
        /// HttpPost Request:
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpPost]
        public IActionResult Create1(ImageModel model)
        {
            _context.Image.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ImageModel model)
        {

            _context.Image.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageModel = await _context.Image.FindAsync(id);
            //dDelete Image from wwwroot/image
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images", imageModel.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //Delete the  Record:
            _context.Image.Remove(imageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Details(ImageModel model)
        {

            _context.Image.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Post Imaage Create:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageID,Title,ImageFile")] ImageModel imageModel)
        {
            if (ModelState.IsValid == true)
            {
                //Save Image to wwwroot/image:
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                imageModel.ImageName = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Images/", filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record:
                _context.Add(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }




    }
}


