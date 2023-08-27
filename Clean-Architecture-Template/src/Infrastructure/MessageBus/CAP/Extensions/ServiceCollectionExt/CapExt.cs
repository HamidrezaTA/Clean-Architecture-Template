using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.MessageBus;
using DotNetCore.CAP.Messages;
using Infrastructure.Configurations;
using Infrastructure.MessageBus.CAP.Extensions.CapOptionsExt;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.MessageBus.CAP.Extensions.ServiceCollectionExt
{
    public static class CapExt
    {
        public static void AddCapExt(this IServiceCollection services, RabbitMqConfigurations rabbitMqConfigurations)
        {
            services.AddCap(capOptions =>
            {
                capOptions.ConsumerThreadCount = 1;
                capOptions.UseInMemoryStorage();
                capOptions.UseDashboard();
                capOptions.UseRabbitMQ(rabbitMqOptions =>
                {
                    rabbitMqOptions.HostName = rabbitMqConfigurations.AMQPHOSTNAME;
                    rabbitMqOptions.UserName = rabbitMqConfigurations.AMQPUSERNAME;
                    rabbitMqOptions.Password = rabbitMqConfigurations.AMQPPASSWORD;
                    rabbitMqOptions.VirtualHost = rabbitMqConfigurations.AMQPVIRTUALHOST;
                    rabbitMqOptions.ExchangeName = rabbitMqConfigurations.AMQPEXCHANGENAME;
                    rabbitMqOptions.CustomHeaders = e => new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>(Headers.MessageId, Guid.NewGuid().ToString()),
                        new KeyValuePair<string, string>(Headers.MessageName, e.RoutingKey),
                    };
                });
                capOptions.AddFailedThresholdCallbackExt();
            });

            services.AddScoped<IMessagePublisherBuilder, CapMessagePublisherBuilder>();
        }
    }
}