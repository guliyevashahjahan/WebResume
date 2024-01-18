using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.LanguageSkillsModule.Commands.LanguageSkillEditCommand
{
    internal class LanguageSkillEditRequestHandler : IRequestHandler<LanguageSkillEditRequest, LanguageSkill>
    {
        private readonly ILanguageSkillRepository languageSkillRepository;
        private readonly IIdentityService identityService;

        public LanguageSkillEditRequestHandler(ILanguageSkillRepository languageSkillRepository,IIdentityService identityService)
        {
            this.languageSkillRepository = languageSkillRepository;
            this.identityService = identityService;
        }
        public async Task<LanguageSkill> Handle(LanguageSkillEditRequest request, CancellationToken cancellationToken)
        {
            var entity = new LanguageSkill 
            { 
                Id= request.Id,
                UserId = identityService.GetPrincipalId().Value,
                Language = request.language,
                Percentage = request.Percentage,
            };

            languageSkillRepository.Edit(entity);
            languageSkillRepository.Save();

            return entity;
        }
    }
}
