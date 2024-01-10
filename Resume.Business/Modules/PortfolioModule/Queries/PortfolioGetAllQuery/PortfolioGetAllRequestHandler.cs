using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.PortfolioModule.Queries.PortfolioGetAllQuery
{
    internal class PortfolioGetAllRequestHandler : IRequestHandler<PortfolioGetAllRequest, IEnumerable<Portfolio>>
    {
        private readonly IPortfolioRepository portfolioRepository;

        public PortfolioGetAllRequestHandler(IPortfolioRepository portfolioRepository)
        {
            this.portfolioRepository = portfolioRepository;
        }
        public async Task<IEnumerable<Portfolio>> Handle(PortfolioGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = portfolioRepository.GetAll(m => m.DeletedBy == null);
            return await data.ToListAsync(cancellationToken);
        }
    }
}
