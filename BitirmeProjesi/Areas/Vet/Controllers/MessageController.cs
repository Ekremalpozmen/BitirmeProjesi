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
            var model = db.Messages.Where(x => x.QuestionsId == questionId).ToList();
            ViewBag.userId = model.Select(x => x.FromUserId).FirstOrDefault();
            ViewBag.vetId = model.Select(x => x.ToUserId).FirstOrDefault();
            ViewBag.questionId = questionId;

            return PartialView("~/Areas/Vet/Views/Message/_VetMessagesDetail.cshtml", model);
        }

        [HttpPost]
        public ActionResult VetSendMessage(string contentMessage, int userId, int vetId, int questionId)
        {

            var message = new Messages()
            {
                ContentMessage = contentMessage,
                FromUserId = vetId,
                ToUserId = userId,
                QuestionsId = questionId,
                CreateDate = DateTime.Now,
                Status = 2
            };
            db.Messages.Add(message);
            db.SaveChanges();
            return View();
        }
    }
}