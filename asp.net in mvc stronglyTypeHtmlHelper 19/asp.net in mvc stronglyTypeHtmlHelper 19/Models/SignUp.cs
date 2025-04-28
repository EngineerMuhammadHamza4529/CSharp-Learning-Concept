using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net_in_mvc_stronglyTypeHtmlHelper_19.Models
{
    public class SignUp
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string userpassword { get; set; }
        public int useremail { get; set; }
        public string usercomment { get; set; }
    }
}