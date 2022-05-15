using BitirmeProjesi.Controllers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    public class VetController : BaseController
    {
        // GET: Vet
        public ActionResult Index()
        {
            return View();
        }
    }
}