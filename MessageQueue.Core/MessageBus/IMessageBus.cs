using MessageQueue.Core.Options;

namespace MessageQueue.Core.MessageBus
{
    public interface IMessageBus
    {
        public void Publish(Object message,BaseMessageBroker messageBroker);
    }
}
