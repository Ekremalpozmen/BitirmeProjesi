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

            List<FromVetToUserMessages> vetToUserMessage = db.FromVetToUserMessages.Where(x => x.QuestionsId == questionId).ToList();
            ViewBag.fromVetToUserMessages = vetToUserMessage;

            return PartialView("~/Areas/Vet/Views/Message/_VetMessagesDetail.cshtml");
        }
    }
}