using Ganss.Xss;
using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.BlogPostModule.Commands.BlogPostEditCommand
{
    internal class BlogPostEditRequestHandler : IRequestHandler<BlogPostEditRequest, BlogPost>
    {
        private readonly IIdentityService identityService;
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IFileService fileService;

        public BlogPostEditRequestHandler(IIdentityService identityService,IBlogPostRepository blogPostRepository,IFileService fileService)
        {
            this.identityService = identityService;
            this.blogPostRepository = blogPostRepository;
            this.fileService = fileService;
        }
        public async Task<BlogPost> Handle(BlogPostEditRequest request, CancellationToken cancellationToken)
        {
            var sanitizer = new HtmlSanitizer();
            var entity = blogPostRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);
            entity.Title = request.Title;
            entity.Body = sanitizer.Sanitize(request.Body);
            entity.ImagePath = fileService.ChangeFile(request.File, entity.ImagePath);
            entity.UserId = identityService.GetPrincipalId().Value;
            blogPostRepository.Save();

            return entity;
        }
    }
}
