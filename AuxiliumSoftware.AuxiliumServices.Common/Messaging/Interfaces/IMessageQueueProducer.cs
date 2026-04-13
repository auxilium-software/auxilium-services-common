using AuxiliumSoftware.AuxiliumServices.Common.Messaging.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Messaging.Interfaces
{
    public interface IMessageQueueProducer : IAsyncDisposable
    {
        Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : QueueMessage;
    }
}
