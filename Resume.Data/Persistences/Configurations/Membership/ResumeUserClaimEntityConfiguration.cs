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
    internal class ResumeUserClaimEntityConfiguration : IEntityTypeConfiguration<ResumeUserClaim>
    {
        public void Configure(EntityTypeBuilder<ResumeUserClaim> builder)
        {
            builder.ToTable("UserClaims", "Membership");
        }
    }
}
