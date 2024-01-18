using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Entities.Membership;
using Resume.Infrastructure.Repositories;
using Resume.Infrastructure.Repositories.Membership;

namespace Resume.Business.Modules.EmployeeModule.Queries.EmployeeGetAllQuery
{
    internal class EmployeeGetAllRequestHandler : IRequestHandler<EmployeeGetAllRequest, IEnumerable<ResumeUser>>
    {
        private readonly IResumeUserRepository resumeUserRepository;

        public EmployeeGetAllRequestHandler(IResumeUserRepository resumeUserRepository)
        {
            this.resumeUserRepository = resumeUserRepository;
        }
        public async Task<IEnumerable<ResumeUser>> Handle(EmployeeGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = await resumeUserRepository.GetAll().ToListAsync(cancellationToken);
         
            return data;
        }
    }
}
