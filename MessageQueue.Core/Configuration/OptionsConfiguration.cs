using MessageQueue.Core.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static MessageQueue.Core.Options.BaseMessageBroker;

namespace MessageQueue.Core.Configuration
{
    public static class OptionsConfiguration
    {

        public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<MessageQueueConnection>().Bind(configuration.GetSection(MessageQueueConnection.Key));
            services.AddOptions<BooksCartMessageBroker>().Bind(configuration.GetSection(BooksCartMessageBroker.Key));
            return services;
        }


    }
}
