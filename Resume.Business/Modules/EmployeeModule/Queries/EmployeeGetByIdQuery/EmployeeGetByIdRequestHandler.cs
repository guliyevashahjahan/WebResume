using MediatR;
using Resume.Infrastructure.Entities.Membership;
using Resume.Infrastructure.Repositories.Membership;

namespace Resume.Business.Modules.EmployeeModule.Queries.EmployeeGetByIdQuery
{
    internal class EmployeeGetByIdRequestHandler : IRequestHandler<EmployeeGetByIdRequest, ResumeUser>
    {
        private readonly IResumeUserRepository resumeUserRepository;

        public EmployeeGetByIdRequestHandler(IResumeUserRepository resumeUserRepository)
        {
            this.resumeUserRepository = resumeUserRepository;
        }
        public async Task<ResumeUser> Handle(EmployeeGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = resumeUserRepository.Get(m => m.Id == request.Id );
            return entity;
        }
    }
}
