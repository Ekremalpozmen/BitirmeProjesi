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

        public ActionResult Index()
        {
            return View();
        }


      
        public ActionResult AnimalList(AnimalSearchViewModel searchViewModel, int? page)
        {
            var currentPageIndex = page - 1 ?? 0;

            var result = _animalsService.GetAnimalListIQueryable(searchViewModel, CurrentUser)
                .OrderBy(p => p.Name)
                .ToPagedList(currentPageIndex, 10);

            ModelState.Clear();
            return new ContentResult
            {
                ContentType = "application/json",
                Content = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue }.Serialize(new
                {
                    success = true,
                    responseText = RenderPartialViewToString("~/Views/Animals/AnimalList.cshtml", result)
                })
            };
        }




        public ActionResult AddAnimal()
        {
            return PartialView("~/Views/Animals/_AddAnimal.cshtml");
        }

        //[HttpPost]
        //public async Task<ActionResult> AddAnimal(AnimalListViewModel model)
        //{

        //    var callResult = await _animalsService.AddAnimalsAsync(model, CurrentUser);
        //    //if (callResult.Success)
        //    //{

        //    //    ModelState.Clear();
        //    //    var animalId = (int)callResult.Item;
        //    //    var viewModel =   _animalsService.AnimalsList(animalId, CurrentUser).ConfigureAwait(false);
        //    //    var jsonResult = Json(
        //    //        new
        //    //        {
        //    //            success = true,
        //    //            warningMessages = callResult.WarningMessages,
        //    //            successMessages = callResult.SuccessMessages,
        //    //            responseText = RenderPartialViewToString("~/Views/Animals/Index.cshtml", viewModel),
        //    //            item = viewModel
        //    //        });
        //    //    jsonResult.MaxJsonLength = int.MaxValue;
        //    //    return jsonResult;
        //    //}
        //    //foreach (var error in callResult.ErrorMessages)
        //    //{
        //    //    ModelState.AddModelError("", error);
        //    //}
        //    return Json(
        //        new
        //        {
        //            success = false,
        //            errorMessages = callResult.ErrorMessages,
        //            responseText = RenderPartialViewToString("~/Views/Animals/Index.cshtml", model)
        //        });

        //}

    }
}