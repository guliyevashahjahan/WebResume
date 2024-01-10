using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ProgrammeSkillsModule.Queries.ProgrammeSkillGetByIdQuery
{
    internal class ProgrammeSkillGetByIdRequestHandler : IRequestHandler<ProgrammeSkillGetByIdRequest, ProgrammeSkill>
    {
        private readonly IProgrammeSkillRepository programmeSkillRepository;

        public ProgrammeSkillGetByIdRequestHandler(IProgrammeSkillRepository programmeSkillRepository)
        {
            this.programmeSkillRepository = programmeSkillRepository;
        }
        public async Task<ProgrammeSkill> Handle(ProgrammeSkillGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = programmeSkillRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);
            return entity;
        }
    }
}
