using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ProgrammeSkillsModule.Queries.ProgrammeSkillGetAllQuery
{
    internal class ProgrammeSkillGetAllRequestHandler : IRequestHandler<ProgrammeSkillGetAllRequest, IEnumerable<ProgrammeSkill>>
    {
        private readonly IProgrammeSkillRepository programmeSkillRepository;

        public ProgrammeSkillGetAllRequestHandler(IProgrammeSkillRepository programmeSkillRepository)
        {
            this.programmeSkillRepository = programmeSkillRepository;
        }
        public async Task<IEnumerable<ProgrammeSkill>> Handle(ProgrammeSkillGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = programmeSkillRepository.GetAll(m => m.DeletedBy == null);
            return await data.ToListAsync(cancellationToken);
        }
    }
}
