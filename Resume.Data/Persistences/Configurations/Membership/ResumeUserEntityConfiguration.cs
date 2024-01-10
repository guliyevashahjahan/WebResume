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

            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Surname).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Age).HasColumnType("tinyint").IsRequired();
            builder.Property(x => x.Location).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.ShortLocation).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.EducationDegree).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
            builder.Property(x => x.CareerLevel).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Phone).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.About).HasColumnType("nvarchar").HasMaxLength(500).IsRequired();
            builder.Property(x => x.ImagePath).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.ToTable("Users", "Membership");
        }
    }
}
