using MediatR;
using Microsoft.AspNetCore.Identity;
using Resume.Infrastructure.Entities.Membership;
using Resume.Infrastructure.Extensions;
using Resume.Infrastructure.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Modules.AccountModule.Commands.EmailConfirmCommand
{
    internal class EmailConfirmRequestHandler : IRequestHandler<EmailConfirmRequest>
    {
        private readonly UserManager<ResumeUser> userManager;
        private readonly ICryptoService cryptoService;

        public EmailConfirmRequestHandler(UserManager<ResumeUser> userManager, ICryptoService cryptoService)
        {
            this.userManager = userManager;
            this.cryptoService = cryptoService;
        }
        public async Task Handle(EmailConfirmRequest request, CancellationToken cancellationToken)
        {
            var token = cryptoService.Decrypt(request.Token);
            var tokenInfo = token.RegisterConfirmToken();
            var user = await userManager.FindByEmailAsync(tokenInfo.email);
            await userManager.ConfirmEmailAsync(user, tokenInfo.token);
        }
    }
}
