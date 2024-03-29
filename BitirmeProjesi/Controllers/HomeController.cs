﻿using BitirmeProjesi.Controllers.Abstract;
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
    public class HomeController : BaseController
    {
        private readonly AddQuestionService _addQuestionService;
        public HomeController(AddQuestionService questionService)
        {
            _addQuestionService = questionService;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.VetList = await _addQuestionService.GetVetListViewAsync();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddQuestion(QuestionViewModel model)
        {
            var result =await _addQuestionService.AddQuestion(model,CurrentUser);
            TempData["Message"] = "Soru Başarılı Şekilde Gönderildi";
            return RedirectToAction("Index");
        }
    }
}