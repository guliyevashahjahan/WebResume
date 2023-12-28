using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Infrastructure.Entities;
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
            builder.Property(x => x.Title).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Body).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.ImagePath).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Slug).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(x => x.PublishedAt).HasColumnType("datetime");
            builder.Property(x => x.PublishedBy).HasColumnType("int");



            builder.ConfigureAsAuditable();

            builder.HasKey(x => x.Id);
          
            builder.HasIndex(x => x.Slug).IsUnique();

            builder.ToTable("BlogPosts");
        }
    }
}
