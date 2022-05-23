using BitirmeProjesi.Areas.Vet.Controllers.Abstract;
using BitirmeProjesi.Services.Vet;
using BitirmeProjesi.ViewModels.Vet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Areas.Vet.Controllers
{
    public class QuestionsController : VetBaseController
    {
        private readonly QuestionService _questionService;
        public QuestionsController(QuestionService questionService)
        {
            _questionService = questionService;
        }
        public ActionResult Index(QuestionListViewModel model)
        {
            var result = _questionService.QuestionList(model, CurrentUser);
            return View(result);
        }
    }
}