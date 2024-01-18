using MediatR;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.LanguageSkillsModule.Queries.LanguageSkillGetByIdQuery
{
    public class LanguageSkillGetByIdRequest : IRequest<LanguageSkill>
    {
        public int Id { get; set; }
    }
}
