using MediatR;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.LanguageSkillsModule.Commands.LanguageSkillRemoveCommand
{
    internal class LanguageSkillRemoveRequestHandler : IRequestHandler<LanguageSkillRemoveRequest>
    {
        private readonly ILanguageSkillRepository languageSkillRepository;

        public LanguageSkillRemoveRequestHandler(ILanguageSkillRepository languageSkillRepository)
        {
            this.languageSkillRepository = languageSkillRepository;
        }
        public async Task Handle(LanguageSkillRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = languageSkillRepository.Get(m => m.Id == request.Id && m.DeletedBy ==null);
            languageSkillRepository.Remove(entity);
            languageSkillRepository.Save();

        }
    }
}
