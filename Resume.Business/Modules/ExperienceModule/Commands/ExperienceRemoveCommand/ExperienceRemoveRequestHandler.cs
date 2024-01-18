using MediatR;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ExperienceModule.Commands.ExperienceRemoveCommand
{
    internal class ExperienceRemoveRequestHandler : IRequestHandler<ExperienceRemoveRequest>
    {
        private readonly IExperienceRepository experienceRepository;

        public ExperienceRemoveRequestHandler(IExperienceRepository experienceRepository)
        {
            this.experienceRepository = experienceRepository;
        }
        public async Task Handle(ExperienceRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = experienceRepository.Get(m => m.Id == request.Id);
            experienceRepository.Remove(entity);
            experienceRepository.Save();
        }
    }
}
