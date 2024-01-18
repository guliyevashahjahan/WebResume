using Ganss.Xss;
using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.Services.Abstracts;

namespace Resume.Business.Modules.ExperienceModule.Commands.ExperienceAddCommand
{
    internal class ExperienceAddRequestHandler : IRequestHandler<ExperienceAddRequest, Experience>
    {
        private readonly IIdentityService identityService;
        private readonly IExperienceRepository experienceRepository;

        public ExperienceAddRequestHandler(IIdentityService identityService, IExperienceRepository experienceRepository)
        {
            this.identityService = identityService;
            this.experienceRepository = experienceRepository;
        }
        public async Task<Experience> Handle(ExperienceAddRequest request, CancellationToken cancellationToken)
        {
            var sanitizer = new HtmlSanitizer();
            var entity = new Experience
            {
                UserId = identityService.GetPrincipalId().Value,
                CompanyName = request.CompanyName,
                Duration = request.Duration,
                Description = sanitizer.Sanitize(request.Description)
            };

            experienceRepository.Add(entity);
            experienceRepository.Save();
            return entity;
        }
    }
}
