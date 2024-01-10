using Ganss.Xss;
using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.PortfolioModule.Commands.PortfolioEditCommand
{
    internal class PortfolioEditRequestHandler : IRequestHandler<PortfolioEditRequest, Portfolio>
    {
        private readonly IIdentityService identityService;
        private readonly IFileService fileService;
        private readonly IPortfolioRepository portfolioRepository;

        public PortfolioEditRequestHandler(IIdentityService identityService,IFileService fileService,IPortfolioRepository portfolioRepository)
        {
            this.identityService = identityService;
            this.fileService = fileService;
            this.portfolioRepository = portfolioRepository;
        }
        public async Task<Portfolio> Handle(PortfolioEditRequest request, CancellationToken cancellationToken)
        {
            var sanitizer = new HtmlSanitizer();
            var entity = new Portfolio
            {
                UserId = identityService.GetPrincipalId().Value,
                Id = request.Id,
                Description = sanitizer.Sanitize(request.Description),
                ProjectName = request.ProjectName,
                ImagePath = fileService.Upload(request.File)
            };
            portfolioRepository.Edit(entity);
            portfolioRepository.Save();

            return entity;
        }
    }
}
