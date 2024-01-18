using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resume.Business.Modules.EmployeeModule.Queries.EmployeeGetAllQuery;
using Resume.Business.Modules.EmployeeModule.Queries.EmployeeGetByIdQuery;

namespace WebResumeApp.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(EmployeeGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Details(EmployeeGetByIdRequest request)
        {
            request.Id =int.Parse(Request.Cookies["userid"]);
            var response = await mediator.Send(request);
            return View(response);
        }

        public IActionResult Resume()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
