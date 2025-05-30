//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class LoginUser
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required :")]
        public string Name { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
