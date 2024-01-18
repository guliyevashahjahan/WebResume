using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Business.Modules.EmployeeModule.Commands.EmployeeEditCommand;
using Resume.Business.Modules.EmployeeModule.Queries.EmployeeGetAllQuery;
using Resume.Business.Modules.EmployeeModule.Queries.EmployeeGetByIdQuery;

namespace WebResumeApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class EmployeeController : Controller
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Authorize("admin.employee.index")]
        public async Task<IActionResult> Index(EmployeeGetAllRequest request)
        {
            var model = await mediator.Send(request);
            return View(model);
        }
           
        [Authorize("admin.employee.details")]

        public async Task<IActionResult> Details(EmployeeGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }
        [Authorize("admin.employee.edit")]

        public async Task<IActionResult> Edit(EmployeeGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }
        [HttpPost]
        [Authorize("admin.employee.edit")]

        public async Task<IActionResult> Edit(EmployeeEditRequest request)
        {
            var response = await mediator.Send(request);

            return RedirectToAction(nameof(Index));
        }

    }
}
