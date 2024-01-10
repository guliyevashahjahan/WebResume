using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ProgrammeSkillsModule.Commands.ProgrammeSkillRemoveCommand
{
    public class ProgrammeSkillRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
