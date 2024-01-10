using Ganss.Xss;
using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.Services.Abstracts;

namespace Resume.Business.Modules.PortfolioModule.Commands.PortfolioAddCommand
{
    internal class PortfolioAddRequestHandler : IRequestHandler<PortfolioAddRequest, Portfolio>
    {
        private readonly IIdentityService identityService;
        private readonly IPortfolioRepository portfolioRepository;
        private readonly IFileService fileService;

        public PortfolioAddRequestHandler(IIdentityService identityService, IPortfolioRepository portfolioRepository,IFileService fileService)
        {
            this.identityService = identityService;
            this.portfolioRepository = portfolioRepository;
            this.fileService = fileService;
        }
        public async Task<Portfolio> Handle(PortfolioAddRequest request, CancellationToken cancellationToken)
        {
            var sanitizer = new HtmlSanitizer();
            var entity = new Portfolio
            {
                UserId = identityService.GetPrincipalId().Value,
                ProjectName = request.ProjectName,
                Description = sanitizer.Sanitize(request.Description)
            };
            entity.ImagePath = fileService.Upload(request.File);
            portfolioRepository.Add(entity);
            portfolioRepository.Save();
            return entity;
        }
    }
}
