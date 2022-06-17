using BitirmeProjesi.Areas.Vet.Controllers.Abstract;
using BitirmeProjesi.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Areas.Vet.Controllers
{
    public class VetController : VetBaseController
    {
        private readonly VetService _vetService;
        public VetController(VetService vetService)
        {
            _vetService = vetService;
        }

        public async Task<ActionResult> Index()
        {
             var model =   _vetService.GetVetListViewModel();
            return View(model);
        }

        public ActionResult VetProfile(int vetId)
        {
            var model = _vetService.GetVetProfile(vetId);
            return View(model);
        }
    }
}