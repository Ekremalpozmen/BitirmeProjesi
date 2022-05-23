using BitirmeProjesi.Areas.Vet.Controllers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Areas.Vet.Controllers
{
    public class SecurityController : VetBaseController
    {
        // GET: Vet/Security
        public ActionResult Login()
        {
            return View();
        }
    }
}