using MediatR;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ProgrammeSkillsModule.Commands.ProgrammeSkillAddCommand
{
    public class ProgrammeSkillAddRequest : IRequest<ProgrammeSkill>
    {

        public string Programme { get; set; }
        public int Percentage { get; set; }
    }
}
