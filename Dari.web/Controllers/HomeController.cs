using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetSecurity.Controllers
{
    public class HomeController : Controller
    { // GET: Home public ActionResult Index() { return View(); }
        

        [Authorize(Roles = "Admin,User")]
        public ActionResult Index() { return View(); }
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "User")]
        public ActionResult Both() { return View(); }

    }
}