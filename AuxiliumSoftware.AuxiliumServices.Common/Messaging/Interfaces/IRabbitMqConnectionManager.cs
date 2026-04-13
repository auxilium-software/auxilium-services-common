using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Databases;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Messaging.Interfaces
{
    public interface IRabbitMqConnectionManager : IAsyncDisposable
    {
        RabbitMQConfigurationSection Configuration { get; }
        Task<IConnection> GetConnectionAsync(CancellationToken cancellationToken = default);
    }
}
