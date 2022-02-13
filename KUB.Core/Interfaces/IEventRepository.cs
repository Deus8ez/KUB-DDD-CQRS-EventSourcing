using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    public interface IEventRepository<TEvent>
        where TEvent : BaseEvent
    {
        Task<int> EventsCountAsync(Guid aggregateId);

        Task<IEnumerable<TEvent>> EventsAsync(Guid aggregateId);

        Task AppendEventAsync(TEvent eventModel);
    }
}
