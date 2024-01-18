using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.Commons.Concrates;
using Resume.Infrastructure.Entities.Membership;
using Resume.Infrastructure.Repositories.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data.Repositories.Membership
{
    class ResumeUserRepository : GeneralRepository<ResumeUser>, IResumeUserRepository
    {
        public ResumeUserRepository(DbContext db) : base(db)
        {
        }
    }
}
