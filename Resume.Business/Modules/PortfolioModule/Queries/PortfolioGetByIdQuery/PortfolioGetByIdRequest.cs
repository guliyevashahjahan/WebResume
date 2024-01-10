using MediatR;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.PortfolioModule.Queries.PortfolioGetByIdQuery
{
    public class PortfolioGetByIdRequest : IRequest<Portfolio>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProjectName { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }

}
