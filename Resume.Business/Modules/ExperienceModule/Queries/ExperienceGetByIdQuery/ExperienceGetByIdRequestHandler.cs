using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ExperienceModule.Queries.ExperienceGetByIdQuery
{
    internal class ExperienceGetByIdRequestHandler : IRequestHandler<ExperienceGetByIdRequest, Experience>
    {
        private readonly IExperienceRepository experienceRepository;

        public ExperienceGetByIdRequestHandler(IExperienceRepository experienceRepository)
        {
            this.experienceRepository = experienceRepository;
        }
        public async Task<Experience> Handle(ExperienceGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = experienceRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);

            return entity;
        }
    }
}
