using AuxiliumSoftware.AuxiliumServices.Common.Messaging.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Messaging.Models
{
    public class EmailQueueMessage : QueueMessage
    {
        public override string RoutingKey => "email.send";

        public required string To { get; set; }
        public string? Cc { get; set; }
        public string? Bcc { get; set; }
        public required string Subject { get; set; }
        public required string TemplateName { get; set; }
        public Dictionary<string, string> TemplateData { get; set; } = new();
        public EmailPriorityEnum Priority { get; set; } = EmailPriorityEnum.Normal;
    }
}
