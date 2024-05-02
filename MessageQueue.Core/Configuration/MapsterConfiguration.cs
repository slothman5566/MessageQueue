using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MessageQueue.Core.Configuration
{
    public static class MapsterConfiguration
    {
        public static IServiceCollection AddMapsterConfiguration(this IServiceCollection services,params Assembly[] assembly)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(assembly);
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }
    }
}
