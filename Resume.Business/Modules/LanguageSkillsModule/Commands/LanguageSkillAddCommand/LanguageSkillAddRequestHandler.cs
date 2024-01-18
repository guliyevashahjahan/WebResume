using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.LanguageSkillsModule.Commands.LanguageSkillAddCommand
{
    internal class LanguageSkillAddRequestHandler : IRequestHandler<LanguageSkillAddRequest, LanguageSkill>
    {
        private readonly IIdentityService identityService;
        private readonly ILanguageSkillRepository languageSkillRepository;

        public LanguageSkillAddRequestHandler(IIdentityService identityService,ILanguageSkillRepository languageSkillRepository)
        {
            this.identityService = identityService;
            this.languageSkillRepository = languageSkillRepository;
        }
        public async Task<LanguageSkill> Handle(LanguageSkillAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new LanguageSkill
            {
                Language = request.Language,
                Percentage = request.Percentage,
                UserId = identityService.GetPrincipalId().Value
            };

            languageSkillRepository.Add(entity);
            languageSkillRepository.Save();
            return entity;
        }
    }
}
