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
    }
}
