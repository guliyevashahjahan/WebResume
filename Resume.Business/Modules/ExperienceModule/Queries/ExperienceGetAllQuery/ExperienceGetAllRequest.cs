using MediatR;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ExperienceModule.Queries.ExperienceGetAllQuery
{
    public class ExperienceGetAllRequest : IRequest<IEnumerable<Experience>>
    {
    }
}
