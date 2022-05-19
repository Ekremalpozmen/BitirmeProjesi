using BitirmeProjesi.Controllers.Abstract;
using BitirmeProjesi.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    public class VetController : BaseController
    {
        private readonly VetService _vetService;
        public VetController(VetService vetService)
        {
            _vetService = vetService;
        }

        public async Task<ActionResult> Index()
        {
           var model = await _vetService.GetVetListViewModel();
            return View(model);
        }

        public async Task<ActionResult> VetProfile(int vetId)
        {
            //var model = await _vetService.GetVetListViewModel();
            return View( );
        }


    }
}