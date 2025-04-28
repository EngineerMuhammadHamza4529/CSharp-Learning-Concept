using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp.net_in_mvc_StringLengthDataAnotation_22.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "ID is mandatory :")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "ID Should be 20 to 5")]
        public String ID { get; set; }

        [Required(ErrorMessage = "Name is required :")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name Should be 20 to 5")]
        public string Name { get; set; }

        [Required(ErrorMessage = "EmployeeID is required :")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "ID Should be 20 to 5")]
        public String EmployeeId { get; set; }

        [Required(ErrorMessage = "EmpEmail is required :")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Invalid Email")]
        public string EmpEmail { get; set; }

        [Required(ErrorMessage = "Gender is required :")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Gender should be 10 t0 5 : ")]
        public string Gender { get; set; }
       
        [Required(ErrorMessage = "Age is required :")]
        [Range(5, 10,ErrorMessage ="Age should be 5 to 10 :")]
        public int Age { get; set; }

    }
}