using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ExperienceModule.Commands.ExperienceRemoveCommand
{
    public class ExperienceRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
