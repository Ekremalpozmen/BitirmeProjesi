using BitirmeProjesi.Controllers.Abstract;
using BitirmeProjesi.Services.User;
using BitirmeProjesi.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    public class AnimalsController : BaseController
    {
        private readonly AnimalsService _animalsService;
        public AnimalsController(AnimalsService animalService)
        {
            _animalsService = animalService;
        }
        public ActionResult Index(AnimalsViewModel model)
        {
            var result = _animalsService.AnimalsList(model, CurrentUser);
            return View(result);
        }

    }
}