using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public PartialViewResult Register()
        {
            return PartialView();
        }
    }
}