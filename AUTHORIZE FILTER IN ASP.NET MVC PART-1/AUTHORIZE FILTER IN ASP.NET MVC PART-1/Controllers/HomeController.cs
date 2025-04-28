using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AUTHORIZE_FILTER_IN_ASP.NET_MVC_PART_1.Models;

namespace AUTHORIZE_FILTER_IN_ASP.NET_MVC_PART_1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        
       
        public ActionResult Contact()
        {
            return View();
        }
    }
}