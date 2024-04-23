using MessageQueue.Core.Options;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MessageQueue.Book.Service
{
    public class RabbitMqCartDirectConsumerService : BackgroundService
    {
        private readonly MessageQueueConnection _config;
        private readonly BooksCartMessageBroker _broker;
        private readonly ILogger<RabbitMqCartDirectConsumerService> _logger;
        private readonly IDistributedCache _distributedCache;
        public RabbitMqCartDirectConsumerService(IOptions<MessageQueueConnection> options,
            IOptions<BooksCartMessageBroker> borkerConfig,
            IDistributedCache cache,
            ILogger<RabbitMqCartDirectConsumerService> logger)
        {
            _distributedCache = cache;
            _config = options.Value;
            _broker = borkerConfig.Value;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factor = new ConnectionFactory()
            {
                HostName = _config.HostName,
                Password = _config.Password,
                UserName = _config.UserName,
            };
            var connection = factor.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(_broker.RoutingKey, false, false, false, null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                _logger.LogInformation(content);
                _distributedCache.SetString($"Log:{DateTime.UtcNow.Ticks}", content);
                channel.BasicAck(ea.DeliveryTag, false);
            };

            channel.BasicConsume(_broker.RoutingKey, false, consumer);
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
       
    }
}
