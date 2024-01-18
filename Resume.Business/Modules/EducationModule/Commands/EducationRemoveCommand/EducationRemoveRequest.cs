using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.EducationModule.Commands.EducationRemoveCommand
{
    public class EducationRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
