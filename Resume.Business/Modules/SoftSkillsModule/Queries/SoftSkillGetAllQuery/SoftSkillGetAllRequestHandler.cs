using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.SoftSkillsModule.Queries.SoftSkillGetAllQuery
{
    internal class SoftSkillGetAllRequestHandler : IRequestHandler<SoftSkillGetAllRequest, IEnumerable<SoftSkill>>
    {
        private readonly ISoftSkillRepository softSkillRepository;

        public SoftSkillGetAllRequestHandler(ISoftSkillRepository softSkillRepository)
        {
            this.softSkillRepository = softSkillRepository;
        }
        public async Task<IEnumerable<SoftSkill>> Handle(SoftSkillGetAllRequest request, CancellationToken cancellationToken)
        {
           var data = softSkillRepository.GetAll(m=>m.DeletedBy == null);

            return await data.ToListAsync(cancellationToken);
        }
    }
}
