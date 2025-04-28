using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp.net_in_mvc_COMPARE_DATA_ANNOTATION_25.Models
{
    public class Student
    {
        [DisplayName("ID")]
        [Required(ErrorMessage = "studentID is required :")]
        public int studentID { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "studentName is required :")]
        public string studentName { get; set; }

        [DisplayName("Age")]
        [Required(ErrorMessage = "studentAge is required :")]
        public string studentAge { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "studentEmail is required :")]
        public string studentEmail { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "StudentPassword is required :")]
        [DataType(DataType.Password)]
        public string studentPassword { get; set; }

        [DisplayName("ConformPassword")]
        [Required(ErrorMessage = "STDconformPassword is required :")]
        [Compare("studentPassword", ErrorMessage = "Password is not Identity :")]
        [DataType(DataType.Password)]
        public string STDconformPassword { get; set; }

        [DisplayName("Organization Name")]
        [Required(ErrorMessage = "StdOrganizationName is required :")]
        [ReadOnly(true)]
        public string StdOrganizationName { get; set; }
        [DisplayName("Address")]
        [Required(ErrorMessage = "Address is required :")]
        [DataType(DataType.MultilineText)]
        public string StdAddress { get; set; }

        [DisplayName("Joining Date")]
        [Required(ErrorMessage = "StdJoiningDate is required :")]
        [DataType(DataType.Date)]
        public string StdJoiningDate { get; set; }

        [DisplayName("Joining Time")]
        [Required(ErrorMessage = "StdJoiningTime is required :")]
        [DataType(DataType.Time)]
        public string StdJoiningTime { get; set; }

    }
}