using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Business.Modules.PortfolioModule.Commands.PortfolioAddCommand;
using Resume.Business.Modules.PortfolioModule.Commands.PortfolioEditCommand;
using Resume.Business.Modules.PortfolioModule.Commands.PortfolioRemoveCommand;
using Resume.Business.Modules.PortfolioModule.Queries.PortfolioGetAllQuery;
using Resume.Business.Modules.PortfolioModule.Queries.PortfolioGetByIdQuery;
using Resume.Business.Modules.ProgrammeSkillsModule.Commands.ProgrammeSkillEditCommand;
using Resume.Business.Modules.ProgrammeSkillsModule.Queries.ProgrammeSkillGetByIdQuery;
using Resume.Business.Modules.SoftSkillsModule.Commands.SoftSkillAddCommand;
using Resume.Business.Modules.SoftSkillsModule.Commands.SoftSkillRemoveCommand;

namespace WebResumeApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PortfolioController : Controller
    {
        private readonly IMediator mediator;

        public PortfolioController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.portfolio.index")]
        public async Task<IActionResult> Index(PortfolioGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.portfolio.details")]

        public async Task<IActionResult> Details(PortfolioGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }

        [Authorize("admin.portfolio.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.portfolio.create")]
        public async Task<IActionResult> Create(PortfolioAddRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }


        [Authorize("admin.portfolio.edit")]
        public async Task<IActionResult> Edit(PortfolioGetByIdRequest request)
        {

            var response = await mediator.Send(request);

            return View(response);
        }

        [HttpPost]
        [Authorize("admin.portfolio.edit")]
        public async Task<IActionResult> Edit(PortfolioEditRequest request)
        {

            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize("admin.portfolio.delete")]
        public async Task<IActionResult> Delete(PortfolioRemoveRequest request)
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
