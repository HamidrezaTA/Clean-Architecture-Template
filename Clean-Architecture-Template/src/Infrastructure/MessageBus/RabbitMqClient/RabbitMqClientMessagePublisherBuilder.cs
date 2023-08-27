using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.MessageBus;
using RabbitMQ.Client;
using StackExchange.Redis;

namespace Infrastructure.MessageBus.RabbitMqClient
{
    public class RabbitMqClientMessagePublisherBuilder : IMessagePublisherBuilder
    {
        private string _queueName;
        private string _exchangeName;
        private string _routingKey;
        private readonly IConnection _rabbitMqConnection;
        private readonly IModel _channel;

        public RabbitMqClientMessagePublisherBuilder(IConnection rabbitMqConnection)
        {
            _rabbitMqConnection = rabbitMqConnection;
            _channel = _rabbitMqConnection.CreateModel();
        }

        public Task Publish(object message)
        {
            var body = Encoding.UTF8.GetBytes(message.ToString());
            _channel.BasicPublish(exchange: _exchangeName, routingKey: _routingKey, basicProperties: null, body: body);

            return Task.CompletedTask;
        }

        public IMessagePublisherBuilder SetQueue(string queueName, bool durable, bool autoDelete)
        {
            _queueName = queueName;
            _channel.QueueDeclare(queue: queueName, durable: durable, exclusive: false, autoDelete: autoDelete, arguments: null);
            return this;
        }

        public IMessagePublisherBuilder SetExchange(string exchangeName, string exchangeType, bool durable)
        {
            _exchangeName = exchangeName;
            _channel.ExchangeDeclare(exchange: exchangeName, type: exchangeType, durable: durable);
            return this;
        }

        public IMessagePublisherBuilder QueueBindToExchange(string routingKey)
        {
            _routingKey = routingKey;
            _channel.QueueBind(queue: _queueName, exchange: _exchangeName, routingKey: routingKey);
            return this;
        }
    }
}