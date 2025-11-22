using Blog.Application.Abstracts.Persistence;
using Blog.Domain.Entities;
using Blog.Persistence.Concrete;
using Blog.Persistence.Context;
using Blog.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Persistence.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            // Here you can add your persistence related service registrations
            // For example, registering the DbContext
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlCon"));
                options.AddInterceptors(new AuditDbContextInterceptor());
                options.UseLazyLoadingProxies();
            });
            services.AddIdentity<AppUser, AppRole>(opt=>
            {
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof (IGenericRepository<>),typeof (GenericRepository<>));
        }
    }
}
