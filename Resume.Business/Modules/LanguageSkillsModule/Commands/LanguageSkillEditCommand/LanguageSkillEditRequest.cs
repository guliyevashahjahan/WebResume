using MediatR;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.LanguageSkillsModule.Commands.LanguageSkillEditCommand
{
    public class LanguageSkillEditRequest : IRequest<LanguageSkill>
    {
        public int Id { get; set; }
        public string language { get; set; }
        public int Percentage { get; set; }
    }
}
