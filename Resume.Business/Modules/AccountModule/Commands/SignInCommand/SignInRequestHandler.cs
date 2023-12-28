using MediatR;
using Microsoft.AspNetCore.Identity;
using Resume.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.AccountModule.Commands.SignInCommand
{
    internal class SignInRequestHandler : IRequestHandler<SignInRequest, ResumeUser>
    {
        private readonly UserManager<ResumeUser> userManager;
        private readonly SignInManager<ResumeUser> signInManager;

        public SignInRequestHandler(UserManager<ResumeUser> userManager
            ,SignInManager<ResumeUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<ResumeUser> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.UserName);
            if (user == null)
            {
                throw new Exception($"{request.UserName} not found.");
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, true);
            if (!result.Succeeded)
            {
                throw new Exception("Username or password is incorrect!");
            }

            return user;
        }
    }
}
