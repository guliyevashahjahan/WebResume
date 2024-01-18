using MediatR;
using Microsoft.AspNetCore.Http;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ExperienceModule.Commands.ExperienceAddCommand
{
    public class ExperienceAddRequest : IRequest<Experience>
    {
        public string CompanyName { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }
}
