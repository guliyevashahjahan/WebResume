using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.EmployeeModule.Queries.EmployeeGetByIdQuery
{
    public class EmployeeGetByIdRequest : IRequest<ResumeUser>
    {
        public int Id { get; set; }
    }
}
