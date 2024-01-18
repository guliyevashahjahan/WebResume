using MediatR;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.LanguageSkillsModule.Commands.LanguageSkillAddCommand
{
    public class LanguageSkillAddRequest : IRequest<LanguageSkill>
    {
        public string Language { get; set; }
        public int Percentage { get; set; }
    }
}
