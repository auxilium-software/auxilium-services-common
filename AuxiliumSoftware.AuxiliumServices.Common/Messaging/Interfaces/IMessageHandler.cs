using AuxiliumSoftware.AuxiliumServices.Common.Messaging.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Messaging.Interfaces
{
    public interface IMessageHandler<in T> where T : QueueMessage
    {
        Task HandleAsync(T message, CancellationToken cancellationToken = default);
    }
}
