using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;

namespace Resume.Business.Modules.BlogPostModule.Queries.BlogPostGetAllQuery
{
    internal class BlogPostGetAllRequestHandler : IRequestHandler<BlogPostGetAllRequest, IEnumerable<BlogPost>>
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogPostGetAllRequestHandler(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public async Task<IEnumerable<BlogPost>> Handle(BlogPostGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = await blogPostRepository.GetAll(m => m.DeletedBy == null).ToListAsync(cancellationToken);
         
            return data;
        }
    }
}
