using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ExperienceModule.Queries.ExperienceGetAllQuery
{
    internal class ExperienceGetAllRequestHandler : IRequestHandler<ExperienceGetAllRequest, IEnumerable<Experience>>
    {
        private readonly IExperienceRepository experienceRepository;

        public ExperienceGetAllRequestHandler(IExperienceRepository experienceRepository)
        {
            this.experienceRepository = experienceRepository;
        }
        public async Task<IEnumerable<Experience>> Handle(ExperienceGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = experienceRepository.GetAll(m => m.DeletedBy == null);
            return await data.ToListAsync(cancellationToken);
        }
    }
}
