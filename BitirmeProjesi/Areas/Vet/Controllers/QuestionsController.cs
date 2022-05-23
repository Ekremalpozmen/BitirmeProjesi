using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Areas.Vet.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: Vet/Questions
        public ActionResult Index()
        {
            return View();
        }
    }
}