using BitirmeProjesi.Controllers.Abstract;
using BitirmeProjesi.Data;
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
    public class MessageController : BaseController
    {
        BitirmeProjesiEntities db = new BitirmeProjesiEntities();
        private readonly MessageService _messageService;
        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }
        public ActionResult MessagesDetail(int questionId)
        {
            var model = db.Messages.Where(x => x.QuestionsId == questionId).ToList();
            ViewBag.userId = model.Select(x => x.FromUserId).FirstOrDefault();
            ViewBag.vetId = model.Select(x => x.ToUserId).FirstOrDefault();
            ViewBag.questionId = questionId;

            return PartialView("~/Views/Message/_MessagesDetail.cshtml", model);
        }

        [HttpPost]
        public ActionResult SendMessage(string contentMessage, int userId, int vetId, int questionId)
        {
            var message = new Messages()
            {
                ContentMessage = contentMessage,
                FromUserId = userId,
                ToUserId = vetId,
                QuestionsId = questionId,
                CreateDate = DateTime.Now,
                Status = 1
            };
            db.Messages.Add(message);
            db.SaveChanges();
            return View();
        }
    }
}