using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectEcomm.Model
{
    public class Category
    {
        public int Id { get; set; }
        [ValidateNever]
        public string Title { get; set; }
        [ValidateNever]
        public int DisplayOrder { get; set; }
        [NotMapped]
        public IFormFile CategoryImage { get; set; }
        public string CategoryImagePath { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
