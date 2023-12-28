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
    internal class ResumeUserTokenEntityConfiguration : IEntityTypeConfiguration<ResumeUserToken>
    {
        public void Configure(EntityTypeBuilder<ResumeUserToken> builder)
        {
            builder.Property(m => m.Type).HasColumnType("tinyint").IsRequired();
            builder.Property(m => m.ExpireDate).HasColumnType("datetime");
            builder.Property(m => m.Value).HasColumnType("nvarchar").HasMaxLength(450).IsRequired();


            builder.HasKey(m => new { m.UserId, m.LoginProvider, m.Type, m.Value });
            builder.ToTable("UserTokens", "Membership");
        }
    }
}
