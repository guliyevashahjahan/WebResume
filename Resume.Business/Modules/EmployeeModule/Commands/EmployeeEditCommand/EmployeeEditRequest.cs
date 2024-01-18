using Resume.Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Infrastructure.Entities.Membership;

namespace Resume.Business.Modules.EmployeeModule.Commands.EmployeeEditCommand
{
    public class EmployeeEditRequest : IRequest<ResumeUser>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public string Location { get; set; }
        public string ShortLocation { get; set; }
        public string EducationDegree { get; set; }
        public string CareerLevel { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public IFormFile File  { get; set; }

    }
}
