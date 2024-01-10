using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ProgrammeSkillsModule.Commands.ProgrammeSkillEditCommand
{
    internal class ProgrammeSkillEditRequestHandler : IRequestHandler<ProgrammeSkillEditRequest, ProgrammeSkill>
    {
        private readonly IProgrammeSkillRepository programmeSkillRepository;
        private readonly IIdentityService identityService;

        public ProgrammeSkillEditRequestHandler(IProgrammeSkillRepository programmeSkillRepository,IIdentityService identityService)
        {
            this.programmeSkillRepository = programmeSkillRepository;
            this.identityService = identityService;
        }
        public async Task<ProgrammeSkill> Handle(ProgrammeSkillEditRequest request, CancellationToken cancellationToken)
        {
            var entity = new ProgrammeSkill 
            { 
                Id= request.Id,
                UserId = identityService.GetPrincipalId().Value,
                Programme = request.Programme,
                Percentage = request.Percentage,
            };

            programmeSkillRepository.Edit(entity);
            programmeSkillRepository.Save();

            return entity;
        }
    }
}
