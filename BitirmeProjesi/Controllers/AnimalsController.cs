﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    public class AnimalsController : Controller
    {
        // GET: Animals
        public ActionResult Index()
        {
            return View();
        }
    }
}