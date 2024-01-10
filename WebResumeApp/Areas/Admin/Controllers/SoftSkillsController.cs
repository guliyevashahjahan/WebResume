using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Business.Modules.SoftSkillsModule.Commands.SoftSkillAddCommand;
using Resume.Business.Modules.SoftSkillsModule.Commands.SoftSkillRemoveCommand;
using Resume.Business.Modules.SoftSkillsModule.Queries.SoftSkillGetAllQuery;

namespace WebResumeApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SoftSkillsController : Controller
    {
        private readonly IMediator mediator;

        public SoftSkillsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Authorize("admin.softskills.index")]
        public async Task<IActionResult>  Index(SoftSkillGetAllRequest request)
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
        [Authorize("admin.softskills.create")]
        public async Task<IActionResult> Create(SoftSkillAddRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize("admin.softskills.delete")]
        public async Task<IActionResult> Delete(SoftSkillRemoveRequest request)
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
