using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resume.Data.Persistence;
using Resume.Infrastructure.Entities.Membership;
using System.Security.Claims;

namespace Resume.Business.Modules.AccountModule.Commands.BindClaimsCommand
{
    internal class BindCLaimsRequestHandler : IRequestHandler<BindClaimsRequest>
    {
        private readonly DataContext db;
        private readonly UserManager<ResumeUser> userManager;

        public BindCLaimsRequestHandler(DataContext db, UserManager<ResumeUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public async Task Handle(BindClaimsRequest request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(request.Identity.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value);

            var user = await db.Set<ResumeUser>().FirstOrDefaultAsync(m => m.Id == userId, cancellationToken);

            request.Identity.AddClaim(new Claim(ClaimTypes.GivenName, $"{user.Name} {user.Surname}"));

            var roles = await userManager.GetRolesAsync(user);
            foreach (var item in roles)
            {
                request.Identity.AddClaim(new Claim(ClaimTypes.Role, item));
            }


            var claims = await (from uc in db.Set<ResumeUserClaim>()
                                where uc.UserId == userId && uc.ClaimValue.Equals("1")
                                select uc.ClaimType).
                        Union(from rc in db.Set<ResumeRoleClaim>()
                              join ur in db.Set<ResumeUserRole>()
                              on rc.RoleId equals ur.RoleId
                              where ur.UserId == userId && rc.ClaimValue.Equals("1")
                              select rc.ClaimType).Distinct().ToArrayAsync(cancellationToken);
            foreach (var item in claims)
            {
                request.Identity.AddClaim(new Claim(item, "1"));
            }
        }
    }
}
