using MediatR;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ProgrammeSkillsModule.Commands.ProgrammeSkillEditCommand
{
    public class ProgrammeSkillEditRequest : IRequest<ProgrammeSkill>
    {
        public int Id { get; set; }
        public string Programme { get; set; }
        public int Percentage { get; set; }
    }
}
