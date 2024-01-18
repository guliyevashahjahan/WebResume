using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.LanguageSkillsModule.Queries.LanguageSkillGetAllQuery
{
    internal class LanguageSkillGetAllRequestHandler : IRequestHandler<LanguageSkillGetAllRequest, IEnumerable<LanguageSkill>>
    {
        private readonly ILanguageSkillRepository languageSkillRepository;

        public LanguageSkillGetAllRequestHandler(ILanguageSkillRepository languageSkillRepository)
        {
            this.languageSkillRepository = languageSkillRepository;
        }
        public async Task<IEnumerable<LanguageSkill>> Handle(LanguageSkillGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = languageSkillRepository.GetAll(m => m.DeletedBy == null);
            return await data.ToListAsync(cancellationToken);
        }
    }
}
