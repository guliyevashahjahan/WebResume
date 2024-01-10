using MediatR;
using Microsoft.AspNetCore.Http;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.PortfolioModule.Commands.PortfolioAddCommand
{
    public class PortfolioAddRequest : IRequest<Portfolio>
    {
        public string ProjectName { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
    }
}
