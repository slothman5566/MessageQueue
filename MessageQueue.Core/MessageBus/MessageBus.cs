using MessageQueue.Core.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace MessageQueue.Core.MessageBus
{
    internal class MessageBus : IMessageBus
    {
        private readonly MessageQueueConnection _config;
        private IConnection _connection;
        public MessageBus(IOptions<MessageQueueConnection> config)
        {
            _config = config.Value;
            var factor = new ConnectionFactory()
            {
                HostName = _config.HostName,
                Password = _config.Password,
                UserName = _config.UserName,
            };
            _connection = factor.CreateConnection();
        }
        public void Publish(object message, BaseMessageBroker messageBroker)
        {
            using var channel = _connection.CreateModel();
            
            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: messageBroker.Exchange, routingKey: messageBroker.RoutingKey, null, body: body);
        }


    }
}
