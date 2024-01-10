using MediatR;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.PortfolioModule.Queries.PortfolioGetAllQuery
{
    public class PortfolioGetAllRequest : IRequest<IEnumerable<Portfolio>>
    {
    }
}
