using MediatR;
using Resume.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.AccountModule.Commands.SignInCommand
{
    public class SignInRequest : IRequest<ResumeUser>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    
}
