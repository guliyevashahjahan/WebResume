using MediatR;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ExperienceModule.Queries.ExperienceGetByIdQuery
{
    public class ExperienceGetByIdRequest : IRequest<Experience>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }

}
