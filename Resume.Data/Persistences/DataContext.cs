using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.Entities;
using Resume.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data.Persistence
{
    public class DataContext : IdentityDbContext<ResumeUser, ResumeRole, int, ResumeUserClaim, ResumeUserRole, ResumeUserLogin, ResumeRoleClaim, ResumeUserToken>
    {
        
        public DataContext(DbContextOptions options)
            :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }

    }
}
