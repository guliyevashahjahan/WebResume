using Ganss.Xss;
using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Extensions;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.Services.Abstracts;

namespace Resume.Business.Modules.BlogPostModule.Commands.BlogPostAddCommand
{
    internal class BlogPostAddRequestHandler : IRequestHandler<BlogPostAddRequest, BlogPost>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IFileService fileService;
        private readonly IIdentityService identityService;

        public BlogPostAddRequestHandler(IBlogPostRepository blogPostRepository, IFileService fileService,IIdentityService identityService)
        {
            this.blogPostRepository = blogPostRepository;
            this.fileService = fileService;
            this.identityService = identityService;
        }
        public async Task<BlogPost> Handle(BlogPostAddRequest request, CancellationToken cancellationToken)
        {
            var sanitizer = new HtmlSanitizer();
            var model = new BlogPost
            {
                UserId = identityService.GetPrincipalId().Value,
                Title = request.Title,
                Body =sanitizer.Sanitize(request.Body)
            };
            model.ImagePath = fileService.Upload(request.File);
            blogPostRepository.Add(model);
            blogPostRepository.Save();

            return model;
        }
    }
}
