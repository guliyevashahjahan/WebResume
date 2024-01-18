using Ganss.Xss;
using MediatR;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Entities.Membership;
using Resume.Infrastructure.Repositories.Membership;
using Resume.Infrastructure.Services.Abstracts;

namespace Resume.Business.Modules.EmployeeModule.Commands.EmployeeEditCommand
{
    internal class EmployeeEditRequestHandler : IRequestHandler<EmployeeEditRequest, ResumeUser>
    {
        private readonly IResumeUserRepository resumeUserRepository;
        private readonly IFileService fileService;
        private readonly IIdentityService identityService;

        public EmployeeEditRequestHandler(IResumeUserRepository resumeUserRepository,IFileService fileService,IIdentityService identityService)
        {
            this.resumeUserRepository = resumeUserRepository;
            this.fileService = fileService;
            this.identityService = identityService;
        }
        public async Task<ResumeUser> Handle(EmployeeEditRequest request, CancellationToken cancellationToken)
        {
            var sanitizer = new HtmlSanitizer();
            var entity = resumeUserRepository.Get(m => m.Id == request.Id);
            entity.Name = request.Name;
            entity.Surname = request.Surname;
            entity.Age = request.Age;
            entity.Location = request.Location;
            entity.Location = request.Location;
            entity.ShortLocation = request.ShortLocation;
            entity.EducationDegree = request.EducationDegree;
            entity.CareerLevel = request.CareerLevel;
            entity.Phone = request.Phone;
            entity.Email = request.Email;
            entity.About = sanitizer.Sanitize(request.About);
            entity.ImagePath = fileService.ChangeFile(request.File,entity.ImagePath);
            resumeUserRepository.Save();

            return entity;
        }
    }
}
