using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Infrastructure.Commons.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data.Persistences.Configurations
{
    internal static class ConfigurationHelper
    {
        public static EntityTypeBuilder<T> ConfigureAsAuditable<T>(this EntityTypeBuilder<T> builder)
           where T : AuditableEntity
        {
            builder.Property(x => x.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.LastModifiedBy).HasColumnType("int");
            builder.Property(x => x.LastModifiedAt).HasColumnType("datetime");
            builder.Property(x => x.DeletedBy).HasColumnType("int");
            builder.Property(x => x.DeletedAt).HasColumnType("datetime");


            return builder;
        }
    }
}
