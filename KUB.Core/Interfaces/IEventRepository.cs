using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    public interface IEventRepository
    {
        Task<int> EventsCountAsync(Guid aggregateId);

        Task<IEnumerable<BaseEvent>> EventsAsync(Guid aggregateId);

        Task AppendEventAsync(BaseEvent eventModel);
    }
}
