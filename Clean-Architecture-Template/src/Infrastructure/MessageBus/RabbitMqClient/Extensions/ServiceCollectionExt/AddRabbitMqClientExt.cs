using Application.MessageBus;
using Infrastructure.Configurations;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Infrastructure.MessageBus.RabbitMqClient.Extensions.ServiceCollectionExt
{
    public static class AddRabbitMqClientExt
    {
        public static void AddRabbitMqClient(this IServiceCollection serviceCollection,
                                             RabbitMqConfigurations rabbitMqConfigurations)
        {
            serviceCollection.AddSingleton<IConnection>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = rabbitMqConfigurations.AMQPHOSTNAME,
                    Port = rabbitMqConfigurations.AMQPPORT,
                    UserName = rabbitMqConfigurations.AMQPUSERNAME,
                    Password = rabbitMqConfigurations.AMQPPASSWORD
                };

                return factory.CreateConnection();
            });

            serviceCollection.AddScoped<IMessagePublisherBuilder, RabbitMqClientMessagePublisherBuilder>();
        }
    }
}