using BitirmeProjesi.Controllers.Abstract;
using BitirmeProjesi.Services.User;
using BitirmeProjesi.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
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

        public async Task<ActionResult> EditProfile(int userId)
        {
            var model = await _profileService.GetEditProfileViewModelAsync(userId);

            return PartialView("~/Views/Profile/_EditProfile.cshtml", model);
        }

        [HttpPost]
        public ActionResult EditProfile(UserModel model)
        {
            _profileService.EditProfile(model);
            return RedirectToAction("Index");
        }

        public ActionResult EditPassword(int userId)
        {
            return PartialView("~/Views/Profile/_EditPassword.cshtml");
        }

    }
}