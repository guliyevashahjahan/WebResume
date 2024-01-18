using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Business.Modules.LanguageSkillsModule.Commands.LanguageSkillAddCommand;
using Resume.Business.Modules.LanguageSkillsModule.Commands.LanguageSkillEditCommand;
using Resume.Business.Modules.LanguageSkillsModule.Commands.LanguageSkillRemoveCommand;
using Resume.Business.Modules.LanguageSkillsModule.Queries.LanguageSkillGetAllQuery;
using Resume.Business.Modules.LanguageSkillsModule.Queries.LanguageSkillGetByIdQuery;

namespace WebResumeApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LanguageSkillsController : Controller
    {
        private readonly IMediator mediator;

        public LanguageSkillsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Authorize("admin.languageskills.index")]
        public async Task<IActionResult> Index(LanguageSkillGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }


        [Authorize("admin.languageskills.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.languageskills.create")]
        public async Task<IActionResult> Create(LanguageSkillAddRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [Authorize("admin.languageskills.edit")]
        public async Task<IActionResult> Edit(LanguageSkillGetByIdRequest request)
        {

            var response = await mediator.Send(request);

            return View(response);
        }

        [HttpPost]
        [Authorize("admin.languageskills.edit")]
        public async Task<IActionResult> Edit(LanguageSkillEditRequest request)
        {

            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize("admin.languageskills.delete")]
        public async Task<IActionResult> Delete(LanguageSkillRemoveRequest request)
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
