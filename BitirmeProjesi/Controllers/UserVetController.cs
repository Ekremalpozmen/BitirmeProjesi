﻿using BitirmeProjesi.Controllers.Abstract;
using BitirmeProjesi.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    [Authorize]
    public class UserVetController : BaseController
    {
        private readonly VetService _vetService;
        public UserVetController(VetService vetService)
        {
            _vetService = vetService;
        }
        public async Task<ActionResult> Index()
        {
            var model =   _vetService.GetVetListViewModel();
            return View(model);
        }

        public ActionResult VetProfile(int vetId)
        {
            var model = _vetService.GetVetProfile(vetId);
            return View(model);
        }
    }
}