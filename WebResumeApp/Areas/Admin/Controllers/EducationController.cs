using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Business.Modules.EducationModule.Commands.EducationAddCommand;
using Resume.Business.Modules.EducationModule.Commands.EducationRemoveCommand;
using Resume.Business.Modules.EducationModule.Queries.EducationGetAllQuery;

namespace WebResumeApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class EducationController : Controller
    {
        private readonly IMediator mediator;

        public EducationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.education.index")]
        public async Task<IActionResult> Index(EducationGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

      

        [Authorize("admin.education.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.education.create")]
        public async Task<IActionResult> Create(EducationAddRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }


      
        [HttpPost]
        [Authorize("admin.education.delete")]
        public async Task<IActionResult> Delete(EducationRemoveRequest request)
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
