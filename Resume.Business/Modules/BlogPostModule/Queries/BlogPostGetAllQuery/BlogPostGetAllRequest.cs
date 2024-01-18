using MediatR;
using Resume.Infrastructure.Entities;

namespace Resume.Business.Modules.BlogPostModule.Queries.BlogPostGetAllQuery
{
    public class BlogPostGetAllRequest : IRequest<IEnumerable<BlogPost>>
    {
     
    }
}
