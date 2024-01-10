using MediatR;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.SoftSkillsModule.Commands.SoftSkillAddCommand
{
    public class SoftSkillAddRequest : IRequest<SoftSkill>
    {
        public string Name { get; set; }
    }
}
