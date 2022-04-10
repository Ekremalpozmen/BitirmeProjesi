using BitirmeProjesi.Controllers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    public class MessageController : BaseController
    {
        // GET: Message
        public ActionResult MessagesDetail(int questionId)
        {
            return PartialView("~/Views/Message/_MessagesDetail.cshtml");
        }
    }
}