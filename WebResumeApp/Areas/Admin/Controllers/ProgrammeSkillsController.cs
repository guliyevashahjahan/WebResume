using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Business.Modules.ProgrammeSkillsModule.Commands.ProgrammeSkillAddCommand;
using Resume.Business.Modules.ProgrammeSkillsModule.Commands.ProgrammeSkillEditCommand;
using Resume.Business.Modules.ProgrammeSkillsModule.Commands.ProgrammeSkillRemoveCommand;
using Resume.Business.Modules.ProgrammeSkillsModule.Queries.ProgrammeSkillGetAllQuery;
using Resume.Business.Modules.ProgrammeSkillsModule.Queries.ProgrammeSkillGetByIdQuery;
using Resume.Business.Modules.SoftSkillsModule.Commands.SoftSkillAddCommand;
using Resume.Business.Modules.SoftSkillsModule.Commands.SoftSkillRemoveCommand;

namespace WebResumeApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProgrammeSkillsController : Controller
    {
        private readonly IMediator mediator;

        public ProgrammeSkillsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Authorize("admin.programmeskills.index")]
        public async Task<IActionResult> Index(ProgrammeSkillGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }


        [Authorize("admin.softskills.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.programmeskills.create")]
        public async Task<IActionResult> Create(ProgrammeSkillAddRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [Authorize("admin.programmeskills.edit")]
        public async Task<IActionResult> Edit(ProgrammeSkillGetByIdRequest request)
        {

            var response = await mediator.Send(request);

            return View(response);
        }

        [HttpPost]
        [Authorize("admin.programmeskills.edit")]
        public async Task<IActionResult> Edit(ProgrammeSkillEditRequest request)
        {

            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize("admin.programmeskills.delete")]
        public async Task<IActionResult> Delete(ProgrammeSkillRemoveRequest request)
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
