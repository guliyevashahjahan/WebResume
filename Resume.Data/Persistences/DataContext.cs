using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.Commons.Abstracts;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Entities.Membership;
using Resume.Infrastructure.Services.Abstracts;
using Resume.Infrastructure.Services.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data.Persistence
{
    public class DataContext : IdentityDbContext<ResumeUser, ResumeRole, int, ResumeUserClaim, ResumeUserRole, ResumeUserLogin, ResumeRoleClaim, ResumeUserToken>
    {
        private readonly IIdentityService identityService;
        private readonly IDateTimeService dateTimeService;

        public DataContext(DbContextOptions options,IIdentityService identityService,IDateTimeService dateTimeService)
            :base(options)
        {
            this.identityService = identityService;
            this.dateTimeService = dateTimeService;
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
        public override int SaveChanges()
        {
            var changes = this.ChangeTracker.Entries<IAuditableEntity>();
            if (changes != null)
            {
                foreach (var entry in changes.Where(m => m.State == EntityState.Added || m.State == EntityState.Modified || m.State == EntityState.Deleted))

                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedAt = dateTimeService.ExecutingTime;
                            entry.Entity.CreatedBy = identityService.GetPrincipalId();
                            break;
                        case EntityState.Modified:
                            entry.Entity.LastModifiedAt = dateTimeService.ExecutingTime;
                            entry.Entity.LastModifiedBy = identityService.GetPrincipalId();
                            entry.Property(m => m.CreatedBy).IsModified = false;
                            entry.Property(m => m.CreatedAt).IsModified = false;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.Entity.DeletedAt = dateTimeService.ExecutingTime;
                            entry.Entity.DeletedBy = identityService.GetPrincipalId();
                            entry.Property(m => m.CreatedBy).IsModified = false;
                            entry.Property(m => m.CreatedAt).IsModified = false;
                            entry.Property(m => m.LastModifiedAt).IsModified = false;
                            entry.Property(m => m.LastModifiedBy).IsModified = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

    }
}
