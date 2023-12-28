using Microsoft.AspNetCore.Identity;
using Resume.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Entities.Membership
{
    public class ResumeUserToken : IdentityUserToken<int>
    {
        public TokenType Type { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
