
using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Databases;
using AuxiliumSoftware.AuxiliumServices.Common.Messaging.Interfaces;
using AuxiliumSoftware.AuxiliumServices.Common.Messaging.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AuxiliumSoftware.AuxiliumServices.Common.Messaging
{
    public static class MessagingServiceExtensions
    {
        public static IServiceCollection AddRabbitMqCore(
            this IServiceCollection services,
            RabbitMQConfigurationSection configuration)
        {
            services.AddSingleton(configuration);
            services.AddSingleton<IRabbitMqConnectionManager, RabbitMqConnectionManager>();

            return services;
        }

        public static IServiceCollection AddRabbitMqProducer(this IServiceCollection services)
        {
            services.AddSingleton<IMessageQueueProducer, RabbitMqProducer>();
            return services;
        }

        public static IServiceCollection AddRabbitMqConsumer<TMessage, THandler>(
            this IServiceCollection services,
            string queueConfigKey,
            string routingKey
        )
            where TMessage : QueueMessage
            where THandler : class, IMessageHandler<TMessage>
        {
            services.AddScoped<IMessageHandler<TMessage>, THandler>();

            services.AddHostedService(sp =>
            {
                var connectionManager = sp.GetRequiredService<IRabbitMqConnectionManager>();

                if (!connectionManager.Configuration.Queues.TryGetValue(queueConfigKey, out var queueName))
                    throw new InvalidOperationException(
                        $"Queue key '{queueConfigKey}' not found in RabbitMQ configuration. " +
                        $"Available keys: {string.Join(", ", connectionManager.Configuration.Queues.Keys)}");

                return new RabbitMqConsumerService<TMessage>(
                    sp.GetRequiredService<IRabbitMqConnectionManager>(),
                    sp.GetRequiredService<IServiceScopeFactory>(),
                    sp.GetRequiredService<ILogger<RabbitMqConsumerService<TMessage>>>(),
                    queueName,
                    routingKey);
            });

            return services;
        }
    }
}
