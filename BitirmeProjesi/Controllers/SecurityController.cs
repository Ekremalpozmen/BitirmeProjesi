using BitirmeProjesi.Services.User.Security;
using BitirmeProjesi.ViewModels.User.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BitirmeProjesi.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        private readonly SecurityService _securityService;
        public SecurityController(SecurityService securityService)
        {
            _securityService = securityService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = _securityService.Login(model);
                if (loginResult != null)
                {
                    FormsAuthentication.SetAuthCookie(loginResult.UserName, false);
                    Session["UserName"] = model.UserName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }
            }
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult Register()
        {
            return PartialView();
        }
    }
}