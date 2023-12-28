using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resume.Data.Persistence;
using Resume.Infrastructure.Entities.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http;
using Resume.Infrastructure.Commons.Abstracts;

namespace Resume.Data
{
    public static class DataServiceInjection
    {
        public static IServiceCollection InstallDataServices(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<DbContext, DataContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("cString"),
                    opt =>
                    {
                        opt.MigrationsHistoryTable("Migrations");
                    }); 
            });

            //services.AddIdentityCore<ResumeUser>()
            //    .AddRoles<ResumeRole>()
            //    .AddEntityFrameworkStores<DataContext>();

            services.AddIdentity<ResumeUser, ResumeRole>()
              // .AddUserManager<AppUserManager>()
               .AddEntityFrameworkStores<DataContext>()
               .AddDefaultTokenProviders();

            services.AddScoped<UserManager<ResumeUser>>();
          //  services.AddScoped<IUserManager, AppUserManager>();
            services.AddScoped<RoleManager<ResumeRole>>();
            services.AddScoped<SignInManager<ResumeUser>>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            var repoInterfaceType = typeof(IRepository<>);

            var concretRepositoryAssembly = typeof(DataServiceInjection).Assembly;

            var repositoryPairs = repoInterfaceType.Assembly
                                     .GetTypes()
                                     .Where(m => m.IsInterface
                                             && m.GetInterfaces()
                                                 .Any(i => i.IsGenericType
                                                     && i.GetGenericTypeDefinition() == repoInterfaceType))
                                     .Select(m => new
                                     {
                                         AbstactRepository = m,
                                         ConcrateRepository = concretRepositoryAssembly.GetTypes()
                                                              .FirstOrDefault(r => r.IsClass && m.IsAssignableFrom(r)),
                                     })
                                     .Where(m => m.ConcrateRepository != null);

            foreach (var item in repositoryPairs)
            {
                services.AddScoped(item.AbstactRepository, item.ConcrateRepository!);
            }
            return services;
        }
    }
}
