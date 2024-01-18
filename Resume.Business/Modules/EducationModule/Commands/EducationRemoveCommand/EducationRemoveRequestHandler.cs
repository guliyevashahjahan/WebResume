using MediatR;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.EducationModule.Commands.EducationRemoveCommand
{
    internal class EducationRemoveRequestHandler : IRequestHandler<EducationRemoveRequest>
    {
        private readonly IEducationRepository educationRepository;

        public EducationRemoveRequestHandler(IEducationRepository educationRepository)
        {
            this.educationRepository = educationRepository;
        }
        public async Task Handle(EducationRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = educationRepository.Get(m => m.Id == request.Id);
            educationRepository.Remove(entity);
            educationRepository.Save();
        }
    }
}
