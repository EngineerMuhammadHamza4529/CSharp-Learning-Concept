using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEcomm.Data;
using ProjectEcomm.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// * Stauts Code:
// * 1xx : Informational
// * 2xx : Sucessful
// * 3xx : Redirection
// * 4xx : Client Error
// * 5xx : Server Error
//namespace ProjectEcomm.Controllers

namespace ProjectEcomm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>

        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id));
        }

        //// POST api/<CategoryController>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] Category category)
        //{
        //    string ConnectionString = @"DefaultEndPointProtocol=https;AccountName = shoppingstroage;AccountKey=...";
        //    string ContainerName = "shoppingcartphotos";
        //    BlobContainerClient containerClient = new BlobContainerClient(ConnectionString , ContainerName);
        //    BlobClient blobClient = containerClient.GetBlobClient(category.CategoryImage.FileName);
        //    MemoryStream ms = new MemoryStream();
        //    category.CategoryImage.CopyTo(ms);
        //    ms.Position = 0;
        //    await blobClient.UploadAsync(ms);
        //    category.CategoryImagePath = blobClient.Uri.AbsoluteUri;
        //    await _context.Categories.AddAsync(category);
        //    await _context.SaveChangesAsync();
        //    return StatusCode(StatusCodes.Status201Created);

        //}         

        [HttpPost]
        public  async Task<IActionResult> Post([FromBody] Category category) 
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        public async Task<string> UploadImage(IFormFile File)
        {
            var data = Guid.NewGuid().ToString();
            var filepath = Path.Combine(Directory.GetCurrentDirectory(),
                @"Utility\Image" , data + "-" + File.FileName);
            using (FileStream ms = new FileStream(filepath , FileMode.Create))
            {
                await File.CopyToAsync(ms);
            }
            var FileName = data + "-" + File.FileName;
            return filepath;
        }












        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            var data = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                data.Title = category.Title;
                data.DisplayOrder = category.DisplayOrder;
                 _context.Categories.Update(data);
                await _context.SaveChangesAsync();
                return Ok("Category Updated!!");
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Categories.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                _context.Categories.Remove(data);
                await _context.SaveChangesAsync();
                return Ok("Category Deleted!!");
            }
        }
    }
}
