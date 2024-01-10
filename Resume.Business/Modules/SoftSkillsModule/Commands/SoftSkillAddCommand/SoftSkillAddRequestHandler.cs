using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.SoftSkillsModule.Commands.SoftSkillAddCommand
{
    internal class SoftSkillAddRequestHandler : IRequestHandler<SoftSkillAddRequest, SoftSkill>
    {
        private readonly ISoftSkillRepository softSkillRepository;
        private readonly IIdentityService identityService;

        public SoftSkillAddRequestHandler(ISoftSkillRepository softSkillRepository,IIdentityService identityService)
        {
            this.softSkillRepository = softSkillRepository;
            this.identityService = identityService;
        }
        public async Task<SoftSkill> Handle(SoftSkillAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new SoftSkill
            {
                UserId = identityService.GetPrincipalId().Value,
                Name = request.Name,
            };
            softSkillRepository.Add(entity);
            softSkillRepository.Save();

            return entity;
        }
    }
}
