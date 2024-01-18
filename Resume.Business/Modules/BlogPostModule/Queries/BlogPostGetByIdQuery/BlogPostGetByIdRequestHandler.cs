using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;

namespace Resume.Business.Modules.BlogPostModule.Queries.BlogPostGetByIdQuery
{
    internal class BlogPostGetByIdRequestHandler : IRequestHandler<BlogPostGetByIdRequest, BlogPost>
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogPostGetByIdRequestHandler(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public async Task<BlogPost> Handle(BlogPostGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = blogPostRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);
            return entity;
        }
    }
}
