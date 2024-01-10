using MediatR;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.PortfolioModule.Commands.PortfolioRemoveCommand
{
    internal class PortfolioRemoveRequestHandler : IRequestHandler<PortfolioRemoveRequest>
    {
        private readonly IPortfolioRepository portfolioRepository;

        public PortfolioRemoveRequestHandler(IPortfolioRepository portfolioRepository)
        {
            this.portfolioRepository = portfolioRepository;
        }
        public async Task Handle(PortfolioRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = portfolioRepository.Get(m => m.Id == request.Id);
            portfolioRepository.Remove(entity);
            portfolioRepository.Save();
        }
    }
}
