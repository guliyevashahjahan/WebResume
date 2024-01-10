using MediatR;
using Microsoft.AspNetCore.Http;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.PortfolioModule.Commands.PortfolioEditCommand
{
    public class PortfolioEditRequest : IRequest<Portfolio>
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
