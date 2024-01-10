using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.SoftSkillsModule.Commands.SoftSkillRemoveCommand
{
    public class SoftSkillRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
