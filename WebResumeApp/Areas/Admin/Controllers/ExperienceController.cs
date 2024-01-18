using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Business.Modules.ExperienceModule.Commands.ExperienceAddCommand;
using Resume.Business.Modules.ExperienceModule.Commands.ExperienceEditCommand;
using Resume.Business.Modules.ExperienceModule.Commands.ExperienceRemoveCommand;
using Resume.Business.Modules.ExperienceModule.Queries.ExperienceGetAllQuery;
using Resume.Business.Modules.ExperienceModule.Queries.ExperienceGetByIdQuery;

namespace WebResumeApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ExperienceController : Controller
    {
        private readonly IMediator mediator;

        public ExperienceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.experience.index")]
        public async Task<IActionResult> Index(ExperienceGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.experience.details")]

        public async Task<IActionResult> Details(ExperienceGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }

        [Authorize("admin.experience.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.experience.create")]
        public async Task<IActionResult> Create(ExperienceAddRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }


        [Authorize("admin.experience.edit")]
        public async Task<IActionResult> Edit(ExperienceGetByIdRequest request)
        {

            var response = await mediator.Send(request);

            return View(response);
        }

        [HttpPost]
        [Authorize("admin.experience.edit")]
        public async Task<IActionResult> Edit(ExperienceEditRequest request)
        {

            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize("admin.experience.delete")]
        public async Task<IActionResult> Delete(ExperienceRemoveRequest request)
        {
            await mediator.Send(request);
            return Json(new
            {
                error = false,
                message = "Item deleted successfully"
            });
        }
    }
}
