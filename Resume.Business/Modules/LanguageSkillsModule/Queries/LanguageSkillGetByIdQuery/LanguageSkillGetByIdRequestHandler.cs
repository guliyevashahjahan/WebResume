using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.LanguageSkillsModule.Queries.LanguageSkillGetByIdQuery
{
    internal class LanguageSkillGetByIdRequestHandler : IRequestHandler<LanguageSkillGetByIdRequest, LanguageSkill>
    {
        private readonly ILanguageSkillRepository languageSkillRepository;

        public LanguageSkillGetByIdRequestHandler(ILanguageSkillRepository languageSkillRepository)
        {
            this.languageSkillRepository = languageSkillRepository;
        }
        public async Task<LanguageSkill> Handle(LanguageSkillGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = languageSkillRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);
            return entity;
        }
    }
}
