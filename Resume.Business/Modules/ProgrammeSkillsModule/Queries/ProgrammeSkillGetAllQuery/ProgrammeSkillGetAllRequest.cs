using MediatR;
using Resume.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.ProgrammeSkillsModule.Queries.ProgrammeSkillGetAllQuery
{
    public class ProgrammeSkillGetAllRequest : IRequest<IEnumerable<ProgrammeSkill>>
    {
    }
}
