using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data.Persistences.Configurations.Membership
{
    internal class ResumeUserEntityConfiguration : IEntityTypeConfiguration<ResumeUser>
    {
        public void Configure(EntityTypeBuilder<ResumeUser> builder)
        {
            builder.ToTable("Users", "Membership");
        }
    }
}
