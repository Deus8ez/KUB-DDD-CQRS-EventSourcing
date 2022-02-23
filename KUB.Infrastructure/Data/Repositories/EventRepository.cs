using KUB.Core.Interfaces;
using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Infrastructure.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        ManagementGamesDB _context;
        public EventRepository(ManagementGamesDB context)
        {
            _context = context;
        }
        public async Task AppendEventAsync(BaseEvent eventModel)
        {
            await _context.Events.AddAsync(eventModel);
        }

        public Task<IEnumerable<BaseEvent>> EventsAsync(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public Task<int> EventsCountAsync(Guid aggregateId)
        {
            throw new NotImplementedException();
        }
    }
}
