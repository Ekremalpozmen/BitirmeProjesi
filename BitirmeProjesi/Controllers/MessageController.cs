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
        public async Task<ActionResult> MessagesDetail(int questionId)
        {
            List<FromUserToVetMessages> userToVetMessage = db.FromUserToVetMessages.Where(x => x.QuestionsId == questionId).ToList();
            ViewBag.fromUserToVetMessage = userToVetMessage;
            ViewBag.userId = userToVetMessage.Select(x => x.FromUserId).FirstOrDefault();
            ViewBag.vetId = userToVetMessage.Select(x => x.ToVetId).FirstOrDefault();
            ViewBag.questionId = questionId;

            List<FromVetToUserMessages> vetToUserMessage = db.FromVetToUserMessages.Where(x => x.QuestionsId == questionId).ToList();
            ViewBag.fromVetToUserMessages = vetToUserMessage;

            return PartialView("~/Views/Message/_MessagesDetail.cshtml");
        }

        [HttpPost]
        public ActionResult SendMessage(/*string contentMessage*/string contentMessage, int userId, int vetId, int questionId)
        {
            var message = new FromUserToVetMessages()
            {
                ContentMessage = contentMessage,
                CreateDate = DateTime.Now,
                FromUserId = userId,
                ToVetId = vetId,
                QuestionsId = questionId,
                Status = 1
            };

            db.FromUserToVetMessages.Add(message);
            db.SaveChanges();
            return View();
        }
    }
}