using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using AuxiliumSoftware.AuxiliumServices.Common.Messaging.Interfaces;
using AuxiliumSoftware.AuxiliumServices.Common.Messaging.Models;

namespace AuxiliumSoftware.AuxiliumServices.Common.Messaging
{
    public class RabbitMqConsumerService<T> : BackgroundService where T : QueueMessage
    {
        private readonly IRabbitMqConnectionManager _connectionManager;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<RabbitMqConsumerService<T>> _logger;
        private readonly string _queueName;
        private readonly string _routingKey;

        private IChannel? _channel;

        public RabbitMqConsumerService(
            IRabbitMqConnectionManager connectionManager,
            IServiceScopeFactory scopeFactory,
            ILogger<RabbitMqConsumerService<T>> logger,
            string queueName,
            string routingKey)
        {
            _connectionManager = connectionManager;
            _scopeFactory = scopeFactory;
            _logger = logger;
            _queueName = queueName;
            _routingKey = routingKey;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Starting consumer for queue {Queue} with routing key {RoutingKey}",
                _queueName, _routingKey);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await ConsumeAsync(stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Consumer error on queue {Queue}, reconnecting in 5s", _queueName);
                    await Task.Delay(5000, stoppingToken);
                }
            }
        }

        private async Task ConsumeAsync(CancellationToken stoppingToken)
        {
            var connection = await _connectionManager.GetConnectionAsync(stoppingToken);
            _channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);

            var exchangeName = _connectionManager.Configuration.ExchangeName;

            await _channel.ExchangeDeclareAsync(
                exchange: exchangeName,
                type: ExchangeType.Topic,
                durable: true,
                autoDelete: false,
                cancellationToken: stoppingToken);

            await _channel.QueueDeclareAsync(
                queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                cancellationToken: stoppingToken);

            await _channel.QueueBindAsync(
                queue: _queueName,
                exchange: exchangeName,
                routingKey: _routingKey,
                cancellationToken: stoppingToken);

            // Process one at a time — keeps it simple, avoids overwhelming SMTP
            await _channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false, cancellationToken: stoppingToken);

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.ReceivedAsync += async (_, ea) =>
            {
                try
                {
                    var json = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var message = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    if (message is null)
                    {
                        _logger.LogWarning("Failed to deserialise message {MessageId}, sending to dead letter", ea.BasicProperties.MessageId);
                        await _channel.BasicNackAsync(ea.DeliveryTag, multiple: false, requeue: false);
                        return;
                    }

                    _logger.LogDebug("Processing message {MessageId} from queue {Queue}", message.MessageId, _queueName);

                    using var scope = _scopeFactory.CreateScope();
                    var handler = scope.ServiceProvider.GetRequiredService<IMessageHandler<T>>();
                    await handler.HandleAsync(message, stoppingToken);

                    await _channel.BasicAckAsync(ea.DeliveryTag, multiple: false);

                    _logger.LogDebug("Successfully processed message {MessageId}", message.MessageId);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to process message {MessageId}", ea.BasicProperties.MessageId);
                    await _channel.BasicNackAsync(ea.DeliveryTag, multiple: false, requeue: true);
                }
            };

            await _channel.BasicConsumeAsync(
                queue: _queueName,
                autoAck: false,
                consumer: consumer,
                cancellationToken: stoppingToken);

            // Keep alive until cancellation
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping consumer for queue {Queue}", _queueName);

            if (_channel is { IsOpen: true })
            {
                await _channel.CloseAsync(cancellationToken);
                _channel.Dispose();
            }

            await base.StopAsync(cancellationToken);
        }
    }
}
