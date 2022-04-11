using BitirmeProjesi.Controllers.Abstract;
using BitirmeProjesi.Services.User;
using BitirmeProjesi.ViewModels.User;
using System.Threading.Tasks;
using System.Web.Mvc;

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
            //if (callResult.Success)
            //{

            //    ModelState.Clear();
            //    var animalId = (int)callResult.Item;
            //    var viewModel =   _animalsService.AnimalsList(animalId, CurrentUser).ConfigureAwait(false);
            //    var jsonResult = Json(
            //        new
            //        {
            //            success = true,
            //            warningMessages = callResult.WarningMessages,
            //            successMessages = callResult.SuccessMessages,
            //            responseText = RenderPartialViewToString("~/Views/Animals/Index.cshtml", viewModel),
            //            item = viewModel
            //        });
            //    jsonResult.MaxJsonLength = int.MaxValue;
            //    return jsonResult;
            //}
            //foreach (var error in callResult.ErrorMessages)
            //{
            //    ModelState.AddModelError("", error);
            //}
            return Json(
                new
                {
                    success = false,
                    errorMessages = callResult.ErrorMessages,
                    responseText = RenderPartialViewToString("~/Views/Animals/Index.cshtml", model)
                });

        }

    }
}