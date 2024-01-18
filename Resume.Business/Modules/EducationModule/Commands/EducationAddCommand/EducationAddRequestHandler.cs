using Ganss.Xss;
using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.Services.Abstracts;

namespace Resume.Business.Modules.EducationModule.Commands.EducationAddCommand
{
    internal class EducationAddRequestHandler : IRequestHandler<EducationAddRequest, Education>
    {
        private readonly IIdentityService identityService;
        private readonly IEducationRepository educationRepository;

        public EducationAddRequestHandler(IIdentityService identityService, IEducationRepository educationRepository)
        {
            this.identityService = identityService;
            this.educationRepository = educationRepository;
        }
        public async Task<Education> Handle(EducationAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Education
            {
                UserId = identityService.GetPrincipalId().Value,
                StudyPlace = request.StudyPlace,
                Duration = request.Duration,
                Profession = request.Profession
            };

            educationRepository.Add(entity);
            educationRepository.Save();
            return entity;
        }
    }
}
