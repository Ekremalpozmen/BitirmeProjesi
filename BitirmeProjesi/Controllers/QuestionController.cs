using BitirmeProjesi.Controllers.Abstract;
using BitirmeProjesi.Services.User;
using BitirmeProjesi.ViewModels.User;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    [Authorize]
    public class QuestionController : BaseController
    {
        private readonly QuestionService _questionService;
        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }
        public ActionResult Index(QuestionViewModel model)
        {
            var result = _questionService.QuestionList(model, CurrentUser);
            return View(result);
        }

        public ActionResult SendRating()
        {
            return PartialView("~/Views/Question/_SendRating.cshtml");
        }

        [HttpPost]
        public ActionResult SendRating(int star)
        {
            return View();
        }
    }
}
