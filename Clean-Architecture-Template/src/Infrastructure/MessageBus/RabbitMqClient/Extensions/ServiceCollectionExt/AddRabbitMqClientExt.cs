using Application.MessageBus;
using Infrastructure.Configurations;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Infrastructure.MessageBus.RabbitMqClient.Extensions.ServiceCollectionExt
{
    public static class AddRabbitMqClientExt
    {
        public static IServiceCollection AddRabbitMqClient(this IServiceCollection services,
                                             RabbitMqConfigurations rabbitMqConfigurations)
        {
            services.AddSingleton<IConnection>(sp =>
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

            services.AddScoped<IMessagePublisherBuilder, RabbitMqClientMessagePublisherBuilder>();

            return services;
        }

        public static IServiceCollection AddConsumer<T>(this IServiceCollection services,
                                                        string queueName,
                                                        bool durable,
                                                        bool exclusive,
                                                        bool autoDelete,
                                                        bool autoAck) where T : AbstractMessageConsumer
        {
            services.AddSingleton<MessageConsumersFactory<T>>();
            services.AddHostedService(provider =>
            {
                var factory = provider.GetRequiredService<MessageConsumersFactory<T>>();
                return factory.Create(queueName, durable, exclusive, autoDelete, autoAck);
            });

            return services;
        }
    }
}