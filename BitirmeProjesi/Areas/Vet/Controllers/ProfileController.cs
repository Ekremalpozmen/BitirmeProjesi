using BitirmeProjesi.Areas.Vet.Controllers.Abstract;
using BitirmeProjesi.Services.Vet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Areas.Vet.Controllers
{
    public class ProfileController : VetBaseController
    {
        private readonly ProfileService _profileService;
        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
        }
        public ActionResult Index(int userId)
        {
            var model = _profileService.GetProfile(userId);
            return View(model);
        }
        public ActionResult EditPassword(int userId)
        {
            return PartialView("~/Areas/Vet/Views/Profile/_EditPassword.cshtml");
        }
    }
}