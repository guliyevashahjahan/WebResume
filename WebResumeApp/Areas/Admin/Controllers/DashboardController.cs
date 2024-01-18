using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Business.Modules.EmployeeModule.Queries.EmployeeGetByIdQuery;
using Resume.Infrastructure.Services.Abstracts;

namespace WebResumeApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IMediator mediator;
        private readonly IIdentityService identityService;

        public DashboardController(IMediator mediator,IIdentityService identityService)
        {
            this.mediator = mediator;
            this.identityService = identityService;
        }

        [Authorize("admin.dashboard.index")]
        public async Task<IActionResult> Index(EmployeeGetByIdRequest request)
        {
            request.Id = identityService.GetPrincipalId().Value;
            var response = await mediator.Send(request);
            return View(response);
        }
    }
}
