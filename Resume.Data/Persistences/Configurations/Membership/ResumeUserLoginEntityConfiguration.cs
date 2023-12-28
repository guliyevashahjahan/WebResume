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
    internal class ResumeUserLoginEntityConfiguration : IEntityTypeConfiguration<ResumeUserLogin>
    {
        public void Configure(EntityTypeBuilder<ResumeUserLogin> builder)
        {
            builder.ToTable("UserLogins", "Membership");
        }
    }
}
