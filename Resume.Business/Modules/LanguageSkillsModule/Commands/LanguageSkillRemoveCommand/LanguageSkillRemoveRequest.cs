using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.LanguageSkillsModule.Commands.LanguageSkillRemoveCommand
{
    public class LanguageSkillRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
