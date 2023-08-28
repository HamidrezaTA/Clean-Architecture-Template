using Application.MessageBus;
using DotNetCore.CAP;

namespace Infrastructure.MessageBus.CAP
{
    public class CapMessagePublisherBuilder : IMessagePublisherBuilder
    {
        private string _queueName;
        private string _exchangeName;
        private string _routingKey;
        private readonly ICapPublisher _capPublisher;

        public CapMessagePublisherBuilder(ICapPublisher capPublisher)
        {
            _capPublisher = capPublisher;

        }
        public async Task PublishAsync(object message)
        {
            await _capPublisher.PublishAsync(_routingKey, message);
        }

        public IMessagePublisherBuilder QueueBindToExchange(string routingKey)
        {
            _routingKey = routingKey;
            return this;
        }

        public IMessagePublisherBuilder SetExchange(string exchangeName, string exchangeType, bool durable)
        {
            _exchangeName = exchangeName;
            return this;

        }

        public IMessagePublisherBuilder SetQueue(string queueName, bool durable, bool autoDelete)
        {
            _queueName = queueName;
            return this;
        }
    }
}