using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Entities.Membership
{
    public class ResumeUser : IdentityUser<int>
    {
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
        public string ImagePath { get; set; }
    }
}
