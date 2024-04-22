using MessageQueue.Core.MessageBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessageQueue.Core.Configuration
{
    public static class MessageBrokerConfiguration
    {
        public static IServiceCollection AddMessageBrokerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMessageBus, MessageBus.MessageBus>();
            return services;
        }
    }
}
