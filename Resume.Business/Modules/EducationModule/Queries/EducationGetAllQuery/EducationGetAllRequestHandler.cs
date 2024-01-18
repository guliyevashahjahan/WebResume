using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.EducationModule.Queries.EducationGetAllQuery
{
    internal class EducationGetAllRequestHandler : IRequestHandler<EducationGetAllRequest, IEnumerable<Education>>
    {
        private readonly IEducationRepository educationRepository;

        public EducationGetAllRequestHandler(IEducationRepository educationRepository)
        {
            this.educationRepository = educationRepository;
        }
        public async Task<IEnumerable<Education>> Handle(EducationGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = educationRepository.GetAll(m => m.DeletedBy == null);
            return await data.ToListAsync(cancellationToken);
        }
    }
}
