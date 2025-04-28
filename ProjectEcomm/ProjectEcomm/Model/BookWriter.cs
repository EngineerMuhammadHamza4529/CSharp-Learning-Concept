using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEcomm.Model
{
    public class BookWriter
    {
        public int BookWriterID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<BookCover> BookCovers { get; set; }
        
    }
}
