using Application.MessageBus;

namespace Infrastructure.MessageBus.CAP
{
    public class CapMessagePublisherBuilder : IMessagePublisherBuilder
    {
        public Task Publish(object message)
        {
            throw new NotImplementedException();
        }

        public IMessagePublisherBuilder QueueBindToExchange(string routingKey)
        {
            throw new NotImplementedException();
        }

        public IMessagePublisherBuilder SetExchange(string exchangeName, string exchangeType, bool durable)
        {
            throw new NotImplementedException();
        }

        public IMessagePublisherBuilder SetQueue(string queueName, bool durable, bool autoDelete)
        {
            throw new NotImplementedException();
        }
    }
}