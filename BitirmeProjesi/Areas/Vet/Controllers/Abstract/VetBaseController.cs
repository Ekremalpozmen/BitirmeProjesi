using BitirmeProjesi.Data;
using BitirmeProjesi.ViewModels.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Areas.Vet.Controllers.Abstract
{
    public abstract class VetBaseController : Controller
    {

        protected override void Initialize(System.Web.Routing.RequestContext context)
        {
            base.Initialize(context);
        }

        public UserModel CurrentUser { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                using (BitirmeProjesiEntities db = new BitirmeProjesiEntities())
                {
                    var contextUserId = Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name);
                    var user = db.Users.FirstOrDefault(x => x.Id == contextUserId);

                    if (user != null)
                    {
                        CurrentUser = new UserModel()
                        {
                            Id = (int)user.Id,
                            Name = user.Name,
                            SurName = user.SurName,
                            UserName = user.UserName,
                            Email = user.Email,
                        };
                    }
                }
            }
            base.OnActionExecuting(context);
        }

        public string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}