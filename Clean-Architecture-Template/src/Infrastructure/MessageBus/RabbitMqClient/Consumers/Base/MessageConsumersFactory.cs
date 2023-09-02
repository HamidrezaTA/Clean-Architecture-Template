using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Infrastructure.MessageBus.RabbitMqClient
{
    public class MessageConsumersFactory<T> where T : AbstractMessageConsumer
    {
        private readonly IConnection _connection;
        public MessageConsumersFactory(IConnection connection)
        {
            _connection = connection;
        }

        public T Create(string queueName, bool durable, bool exclusive, bool autoDelete, bool autoAck)
        {
            return (T)Activator.CreateInstance(typeof(T), _connection, queueName, durable, exclusive, autoDelete, autoAck);
        }
    }
}