using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Entities.Membership;

namespace Resume.Business.Modules.EmployeeModule.Queries.EmployeeGetAllQuery
{
    public class EmployeeGetAllRequest : IRequest<IEnumerable<ResumeUser>>
    {
     
    }
}
