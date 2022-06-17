using BitirmeProjesi.Controllers.Abstract;
using BitirmeProjesi.Filters;
using BitirmeProjesi.Services.User;
using BitirmeProjesi.ViewModels.User;
using MvcPaging;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BitirmeProjesi.Controllers
{
    public class AnimalsController : BaseController
    {
        private readonly AnimalsService _animalsService;
        public AnimalsController(AnimalsService animalService)
        {
            _animalsService = animalService;
        }

        public ActionResult Index(AnimalsViewModel model)
        {
            var result = _animalsService.AnimalsList(model, CurrentUser);
            return View(result);
        }

        public ActionResult AddAnimal()
        {
            return PartialView("~/Views/Animals/_AddAnimal.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> AddAnimal(AnimalsViewModel model)
        {
            var callResult = await _animalsService.AddAnimalsAsync(model, CurrentUser);
            return Json(
                new
                {
                    success = false,
                    errorMessages = callResult.ErrorMessages,
                    responseText = RenderPartialViewToString("~/Views/Animals/Index.cshtml", model)
                });
        }


        public async Task<ActionResult> VaccineList(int animalId)
        {
            var model = await _animalsService.GetVaccineListViewModel(animalId);

            ViewBag.animalId = animalId;

            return PartialView("~/Views/Animals/_VaccineList.cshtml", model);
        }

        public ActionResult AddVaccine(int animalId)
        {
            ViewBag.AnimalId = animalId;
            return PartialView("~/Views/Animals/_AddVaccine.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> AddVaccine(VaccineListViewModel model)
        {
            var callResult = await _animalsService.AddVaccineAsync(model, CurrentUser);

            return Json(
                new
                {
                    success = false,
                    errorMessages = callResult.ErrorMessages,
                    responseText = RenderPartialViewToString("~/Views/Animals/_AddVaccine.cshtml", model)
                });
        }

        public async Task<ActionResult> DeleteVaccine(int id)
        {
            var callResult = await _animalsService.DeleteVaccine(id);
            return View();
        }

    }
}