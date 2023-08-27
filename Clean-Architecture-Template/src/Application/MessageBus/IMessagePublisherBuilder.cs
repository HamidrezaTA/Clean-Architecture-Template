using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.MessageBus
{
    public interface IMessagePublisherBuilder
    {
        IMessagePublisherBuilder SetQueue(string queueName, bool durable, bool autoDelete);
        IMessagePublisherBuilder SetExchange(string exchangeName, string exchangeType, bool durable);
        IMessagePublisherBuilder QueueBindToExchange(string routingKey);
        Task Publish(object message);
    }
}