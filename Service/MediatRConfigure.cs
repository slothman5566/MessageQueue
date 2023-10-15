using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Service
{
    public static class MediatRConfigure
    {
        public static IServiceCollection AddMediatRConfig(this IServiceCollection services)
        {

            services.AddMediatR(cfg =>
            {
                cfg.Lifetime = ServiceLifetime.Scoped;
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
