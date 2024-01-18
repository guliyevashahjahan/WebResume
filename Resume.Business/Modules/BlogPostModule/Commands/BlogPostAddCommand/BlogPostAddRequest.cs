using Resume.Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.BlogPostModule.Commands.BlogPostAddCommand
{
    public class BlogPostAddRequest : IRequest<BlogPost>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public IFormFile File { get; set; } 
    }
}
