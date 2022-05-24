using BitirmeProjesi.Areas.Vet.Controllers.Abstract;
using BitirmeProjesi.Controllers.Abstract;
using BitirmeProjesi.ViewModels.User;
using System.Web.Mvc;

namespace BitirmeProjesi
{
    public abstract class AppBaseViewPage<TModel> : WebViewPage<TModel>
    {
        protected UserModel CurrentUser
        {
            get
            {
                if (ViewContext.Controller is BaseController baseController)
                {
                    return baseController.CurrentUser ?? new UserModel();

                }
                if (ViewContext.Controller is VetBaseController vetbaseController)
                {
                    return vetbaseController.CurrentUser ?? new UserModel();

                }
                return null;
            }
        }
    }
    public abstract class AppBaseViewPage : AppBaseViewPage<dynamic>
    {

    }
}