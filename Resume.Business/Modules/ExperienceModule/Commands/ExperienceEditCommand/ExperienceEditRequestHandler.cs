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

namespace Resume.Business.Modules.ExperienceModule.Commands.ExperienceEditCommand
{
    internal class ExperienceEditRequestHandler : IRequestHandler<ExperienceEditRequest, Experience>
    {
        private readonly IIdentityService identityService;
        private readonly IExperienceRepository experienceRepository;

        public ExperienceEditRequestHandler(IIdentityService identityService,IExperienceRepository experienceRepository)
        {
            this.identityService = identityService;
            this.experienceRepository = experienceRepository;
        }
        public async Task<Experience> Handle(ExperienceEditRequest request, CancellationToken cancellationToken)
        {
            var sanitizer = new HtmlSanitizer();
            var entity = new Experience
            {
                UserId = identityService.GetPrincipalId().Value,
                Id = request.Id,
                Description = sanitizer.Sanitize(request.Description),
                CompanyName = request.CompanyName,
                Duration = request.Duration
            };
            experienceRepository.Edit(entity);
            experienceRepository.Save();

            return entity;
        }
    }
}
