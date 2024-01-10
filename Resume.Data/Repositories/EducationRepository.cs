using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.Commons.Concrates;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data.Repositories
{
    internal class EducationRepository : GeneralRepository<Education>, IEducationRepository
    {
        public EducationRepository(DbContext db)
            :base(db)
        {
            
        }
    }
}
