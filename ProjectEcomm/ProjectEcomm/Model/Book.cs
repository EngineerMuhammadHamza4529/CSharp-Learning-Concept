using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEcomm.Model
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public string ImageUrl { get; set; }
        public string BookUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ISBNNUMBER { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public IFormFile BookFile { get; set; }
        public int BookCoverID { get; set; }
        public BookCover BookCover { get; set; }
        public int BookWriterID { get; set; }
        public BookWriter BookWriter { get; set; }


    }
}
