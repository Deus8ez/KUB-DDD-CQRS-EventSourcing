using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    /// <summary>
    /// Stores model events for all models
    /// </summary>
    public interface IEventStore
    {
        Task<int> EventsCountAsync(Guid aggregateId);

        //Task<IEnumerable<IdT>> AllIdsSync();

        Task<int> ModelEventsCountAsync(Guid aggregateId);

		Task<IEnumerable<BaseEvent>> EventsAsync(Guid aggregateId);

        Task<int> AppendEventAsync(BaseEvent eventModel);
    }
}
