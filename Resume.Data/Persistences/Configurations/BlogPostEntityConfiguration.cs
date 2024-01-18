using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data.Persistences.Configurations
{
    internal class BlogPostEntityConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
            builder.Property(x => x.UserId).HasColumnType("int").IsRequired();
            builder.Property(x => x.Title).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Body).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.ImagePath).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();


            builder.ConfigureAsAuditable();

            builder.HasKey(x => x.Id);

            builder.HasOne<ResumeUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("BlogPosts");
        }
    }
}
