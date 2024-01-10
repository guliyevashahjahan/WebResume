using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.PortfolioModule.Queries.PortfolioGetByIdQuery
{
    internal class PortfolioGetByIdRequestHandler : IRequestHandler<PortfolioGetByIdRequest, Portfolio>
    {
        private readonly IPortfolioRepository portfolioRepository;

        public PortfolioGetByIdRequestHandler(IPortfolioRepository portfolioRepository)
        {
            this.portfolioRepository = portfolioRepository;
        }
        public async Task<Portfolio> Handle(PortfolioGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = portfolioRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);

            return entity;
        }
    }
}
