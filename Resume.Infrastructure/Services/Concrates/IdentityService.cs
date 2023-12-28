using Microsoft.AspNetCore.Mvc.Infrastructure;
using Resume.Infrastructure.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Services.Concrates
{
    public class IdentityService : IIdentityService
    {
        private readonly IActionContextAccessor ctx;

        public IdentityService(IActionContextAccessor ctx)
        {
            this.ctx = ctx;
        }
        public int? GetPrincipalId()
        {
            var userIdStr = ctx.ActionContext.HttpContext.User.Claims.FirstOrDefault(m => m.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
            if (string.IsNullOrWhiteSpace(userIdStr))
            {
                return null;
            }

            return Convert.ToInt32(userIdStr);
        }
    }
}
