//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LOGIN_FORM_WITH_SESSION_AND_LOGOUT_FUNCTIONALITY.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int id { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage ="Username is required :")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required :")]
        public string Password { get; set; }
    }
}
