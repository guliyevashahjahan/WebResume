using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resume.Business.Modules.BlogPostModule.Commands.BlogPostAddCommand;
using Resume.Business.Modules.BlogPostModule.Commands.BlogPostEditCommand;
using Resume.Business.Modules.BlogPostModule.Commands.BlogPostRemoveCommand;
using Resume.Business.Modules.BlogPostModule.Queries.BlogPostGetAllQuery;
using Resume.Business.Modules.BlogPostModule.Queries.BlogPostGetByIdQuery;

namespace WebResumeApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly IMediator mediator;

        public BlogPostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Authorize("admin.blogposts.index")]
        public async Task<IActionResult> Index(BlogPostGetAllRequest request)
        {
            var model = await mediator.Send(request);
            return View(model);
        }
        [Authorize("admin.blogposts.create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize("admin.blogposts.create")]

        public async Task<IActionResult> Create(BlogPostAddRequest request)
        {

            var reponse = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize("admin.blogposts.delete")]

        public async Task<IActionResult> Delete(BlogPostRemoveRequest request)
        {
            await mediator.Send(request);
            return Json(new
            {
                error = false,
                message = "Item deleted successfully"

            });
        }
        [Authorize("admin.blogposts.details")]

        public async Task<IActionResult> Details(BlogPostGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }
        [Authorize("admin.blogposts.edit")]

        public async Task<IActionResult> Edit(BlogPostGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }
        [HttpPost]
        [Authorize("admin.blogposts.edit")]

        public async Task<IActionResult> Edit(BlogPostEditRequest request)
        {
            var response = await mediator.Send(request);

            return RedirectToAction(nameof(Index));
        }

    }
}
