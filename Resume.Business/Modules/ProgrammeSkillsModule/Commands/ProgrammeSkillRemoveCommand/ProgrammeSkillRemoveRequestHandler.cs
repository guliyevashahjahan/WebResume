using MediatR;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ProgrammeSkillsModule.Commands.ProgrammeSkillRemoveCommand
{
    internal class ProgrammeSkillRemoveRequestHandler : IRequestHandler<ProgrammeSkillRemoveRequest>
    {
        private readonly IProgrammeSkillRepository programmeSkillRepository;

        public ProgrammeSkillRemoveRequestHandler(IProgrammeSkillRepository programmeSkillRepository)
        {
            this.programmeSkillRepository = programmeSkillRepository;
        }
        public async Task Handle(ProgrammeSkillRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = programmeSkillRepository.Get(m => m.Id == request.Id && m.DeletedBy ==null);
            programmeSkillRepository.Remove(entity);
            programmeSkillRepository.Save();

        }
    }
}
