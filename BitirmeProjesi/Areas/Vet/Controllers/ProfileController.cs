using BitirmeProjesi.Areas.Vet.Controllers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Areas.Vet.Controllers
{
    public class ProfileController : VetBaseController
    {
        //private readonly ProfileService _profileService;
        //public ProfileController(ProfileService profileService)
        //{
        //    _profileService = profileService;
        //}
        public ActionResult Index()
        {
            return View();
        }
    }
}