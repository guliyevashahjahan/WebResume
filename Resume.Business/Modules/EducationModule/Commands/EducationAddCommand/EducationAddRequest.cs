using MediatR;
using Microsoft.AspNetCore.Http;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.EducationModule.Commands.EducationAddCommand
{
    public class EducationAddRequest : IRequest<Education>
    {
        public string Profession { get; set; }
        public string StudyPlace { get; set; }
        public string Duration { get; set; }
    }
}
