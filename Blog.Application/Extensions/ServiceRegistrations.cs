using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Blog.Application.Behaviors;
namespace Blog.Application.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            // Fix: Ensure the correct extension method is available by including the necessary namespace
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
