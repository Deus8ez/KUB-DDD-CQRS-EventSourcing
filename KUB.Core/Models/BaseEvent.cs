using KUB.SharedKernel.DTOModels.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KUB.Core.Models
{
    public class BaseEvent
    {
        public Guid Id { get; set; }
        public Guid AggregateId { get; set; }

        public DateTime Timestamp { get; set; }

        public string EventName { get; set; }

        public string EventData { get; set; }

        public void SetEvent(Guid aggregateId, string eventName, object aggregate)
        {
            AggregateId = aggregateId;
            Timestamp = DateTime.Now;
            EventName = eventName;
            EventData = JsonSerializer.Serialize(aggregate);
        }
    }
}
