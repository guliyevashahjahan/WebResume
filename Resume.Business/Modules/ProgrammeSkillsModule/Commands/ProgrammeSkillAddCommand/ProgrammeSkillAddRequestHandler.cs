using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ProgrammeSkillsModule.Commands.ProgrammeSkillAddCommand
{
    internal class ProgrammeSkillAddRequestHandler : IRequestHandler<ProgrammeSkillAddRequest, ProgrammeSkill>
    {
        private readonly IIdentityService identityService;
        private readonly IProgrammeSkillRepository programmeSkillRepository;

        public ProgrammeSkillAddRequestHandler(IIdentityService identityService,IProgrammeSkillRepository programmeSkillRepository)
        {
            this.identityService = identityService;
            this.programmeSkillRepository = programmeSkillRepository;
        }
        public async Task<ProgrammeSkill> Handle(ProgrammeSkillAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new ProgrammeSkill
            {
                Programme = request.Programme,
                Percentage = request.Percentage,
                UserId = identityService.GetPrincipalId().Value
            };

            programmeSkillRepository.Add(entity);
            programmeSkillRepository.Save();
            return entity;
        }
    }
}
