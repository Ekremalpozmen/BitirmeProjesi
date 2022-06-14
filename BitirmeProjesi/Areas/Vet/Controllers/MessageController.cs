using BitirmeProjesi.Areas.Vet.Controllers.Abstract;
using BitirmeProjesi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Areas.Vet.Controllers
{
    public class MessageController : VetBaseController
    {
        BitirmeProjesiEntities db = new BitirmeProjesiEntities();

        public ActionResult VetMessagesDetail(int questionId)
        {
            List<FromUserToVetMessages> userToVetMessage = db.FromUserToVetMessages.Where(x => x.QuestionsId == questionId).ToList();
            ViewBag.fromUserToVetMessages = userToVetMessage;

            ViewBag.userId = userToVetMessage.Select(x => x.FromUserId).FirstOrDefault();
            ViewBag.vetId = userToVetMessage.Select(x => x.ToVetId).FirstOrDefault();
            ViewBag.questionId = questionId;



            List<FromVetToUserMessages> vetToUserMessage = db.FromVetToUserMessages.Where(x => x.QuestionsId == questionId).ToList();
            ViewBag.fromVetToUserMessages = vetToUserMessage;

            return PartialView("~/Areas/Vet/Views/Message/_VetMessagesDetail.cshtml");
        }

        [HttpPost]
        public ActionResult VetSendMessage(string contentMessage, int userId, int vetId, int questionId)
        {
            var message = new FromVetToUserMessages()
            {
                ContentMessage = contentMessage,
                CreateDate = DateTime.Now,
                FromVetId = vetId,
                ToUserId = userId,
                QuestionsId = questionId,
                Status = 2
            };

            db.FromVetToUserMessages.Add(message);
            db.SaveChanges();
            return View();
        }
    }
}