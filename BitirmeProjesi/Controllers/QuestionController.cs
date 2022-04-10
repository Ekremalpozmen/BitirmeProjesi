using BitirmeProjesi.Controllers.Abstract;
using BitirmeProjesi.Services.User;
using BitirmeProjesi.ViewModels.User;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    [Authorize]
    public class QuestionController : BaseController
        
    {
        public class Ogrenci
        {
            public int OgrenciNumarasi { get; set; }
            public string Adi { get; set; }
            public string SoyAdi { get; set; }
            public int Yasi { get; set; }
            public string Memleketi { get; set; }
        }

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
        public JsonResult SendRating(int Stars)
        {
            return Json("Öğreci başarıyla POST edilmiştir.", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult OgrenciBilgisi(Ogrenci o)
        {
            return Json("Öğreci başarıyla POST edilmiştir.", JsonRequestBehavior.AllowGet);
        }

    }
}
