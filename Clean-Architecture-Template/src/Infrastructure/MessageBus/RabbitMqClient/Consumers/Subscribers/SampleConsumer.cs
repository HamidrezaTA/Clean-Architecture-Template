using System.Text;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Infrastructure.MessageBus.RabbitMqClient.Consumers.Subscribers
{
    public class SampleConsumer : AbstractMessageConsumer
    {
        private readonly ILogger<SampleConsumer> _logger;

        public SampleConsumer(IConnection connection,
                               string queueName,
                               bool durable,
                               bool exclusive,
                               bool autoDelete,
                               bool autoAck) : base(connection, queueName, durable, exclusive, autoDelete, autoAck)
        {

        }

        public override void Subscribe(byte[]? messageAsArray)
        {
            var message = Encoding.UTF8.GetString(messageAsArray);
            Console.WriteLine("Consumed {0}", message);
        }
    }
}