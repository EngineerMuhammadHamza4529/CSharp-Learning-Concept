using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp.net_in_mvc_DataAnotation_21.Models

{
    public class Employee
    {
        [Required(ErrorMessage = "ID is mandatory :")]
        public int empid { get; set; }
        [Required(ErrorMessage = "Empname is mandatory :")]
        public string empname { get; set; }
        [Required(ErrorMessage = "Emppassword is mandotry :")]
        public int emppassword{ get; set; }
        [Required(ErrorMessage = "Empgender is mandotry :")]
        public string empgender { get; set; }
        [Required(ErrorMessage = "Empmail is mandotry")]
        public string empemail { get; set; }
    }
}