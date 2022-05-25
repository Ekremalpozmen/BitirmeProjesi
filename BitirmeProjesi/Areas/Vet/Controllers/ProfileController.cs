using BitirmeProjesi.Areas.Vet.Controllers.Abstract;
using BitirmeProjesi.Services.Vet;
using BitirmeProjesi.ViewModels.Vet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static BitirmeProjesi.ViewModels.Vet.VetModel;

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
        public async Task<ActionResult> EditProfile(int vetId)
        {
            var model = await _profileService.GetEditProfileViewModelAsync(vetId);
            return PartialView("~/Areas/Vet/Views/Profile/_EditProfile.cshtml", model);
        }

        [HttpPost]
        public ActionResult EditProfile(VetModel model)
        {
            _profileService.EditProfile(model);
            return RedirectToAction("Index");
        }

        public ActionResult EditPassword(int userId)
        {
            return PartialView("~/Areas/Vet/Views/Profile/_EditPassword.cshtml");
        }

        [HttpPost]
        public ActionResult EditPassword(EditPassword model)
        {
            _profileService.EditPassword(model, CurrentUser);
            return RedirectToAction("Index");
        }
    }
}