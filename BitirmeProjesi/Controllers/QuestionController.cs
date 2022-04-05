using BitirmeProjesi.Controllers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    [Authorize]
    public class QuestionController : BaseController
    {
        // GET: Question
        public ActionResult Index()
        {
            return View();
        }
    }
}