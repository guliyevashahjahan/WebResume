using MediatR;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.SoftSkillsModule.Commands.SoftSkillRemoveCommand
{
    internal class SoftSkillRemoveRequestHandler : IRequestHandler<SoftSkillRemoveRequest>
    {
        private readonly ISoftSkillRepository softSkillRepository;

        public SoftSkillRemoveRequestHandler(ISoftSkillRepository softSkillRepository)
        {
            this.softSkillRepository = softSkillRepository;
        }
        public async Task Handle(SoftSkillRemoveRequest request, CancellationToken cancellationToken)
        {
            var model = softSkillRepository.Get(m => m.Id == request.Id);
            softSkillRepository.Remove(model);
            softSkillRepository.Save();
        }
    }
}
