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

            List<FromVetToUserMessages> vetToUserMessage = db.FromVetToUserMessages.Where(x => x.QuestionsId == questionId).ToList();
            ViewBag.fromVetToUserMessages = vetToUserMessage;

            return PartialView("~/Views/Message/_MessagesDetail.cshtml");
        }
    }
}