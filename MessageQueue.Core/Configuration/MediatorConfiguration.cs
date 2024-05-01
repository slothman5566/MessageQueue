using MessageQueue.Core.CQRS.Behavior;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MessageQueue.Core.Configuration
{
    public static class MediatorConfiguration
    {

        public static IServiceCollection AddMediatorConfiguration(this IServiceCollection services, Assembly? assembly)
        {
            services.AddMediatR(config =>
            {
                if (assembly != null)
                {
                    config.RegisterServicesFromAssembly(assembly);
                }
                config.AddOpenBehavior(typeof(LogBehavior<,>));
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            });

            return services;
        }
    }
}
