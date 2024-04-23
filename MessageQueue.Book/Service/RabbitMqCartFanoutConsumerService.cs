
using MessageQueue.Core.Dto;
using MessageQueue.Core.Options;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using static MessageQueue.Core.Options.BaseMessageBroker;

namespace MessageQueue.Book.Service
{
    public class RabbitMqCartFanoutConsumerService : BackgroundService
    {
        private readonly MessageQueueConnection _config;
        private readonly BooksCartLogBroker _logConfig;
        private readonly ILogger<RabbitMqCartFanoutConsumerService> _logger;
        public RabbitMqCartFanoutConsumerService(IOptions<MessageQueueConnection> options,
            IOptions<BooksCartLogBroker> logConfig,
            ILogger<RabbitMqCartFanoutConsumerService> logger)
        {
            _config = options.Value;
            _logConfig = logConfig.Value;
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
            channel.ExchangeDeclare(_logConfig.Exchange, ExchangeType.Fanout);
            for (var i = 0; i < 10; i++)
            {
                var queueName = $"{_logConfig.RoutingKey}_{i}";
                channel.QueueDeclare(queueName, false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (ch, ea) =>
                {
                    var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                    _logger.LogInformation($"{ea.Exchange}_{ea.RoutingKey}:{content}");
                    channel.BasicAck(ea.DeliveryTag, false);
                };
                channel.BasicConsume(queueName, false, consumer);
                channel.QueueBind(queueName, _logConfig.Exchange, queueName);
            }


            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

    }
}
