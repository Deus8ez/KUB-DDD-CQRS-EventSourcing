using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KUB.Application.Interfaces
{
    public interface IReadRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveAsync();
    }

    public interface IWriteRepository<T> where T : class
    {
        Task InsertAsync(T obj);
        Task Update(T obj);
        Task Delete(object id);
        Task SaveAsync();
    }

    public interface IEventRepository<TEvent>
        where TEvent : BaseEvent
    {
        Task<int> EventsCountAsync(Guid aggregateId);

        Task<IEnumerable<TEvent>> EventsAsync(Guid aggregateId);

        Task AppendEventAsync(TEvent eventModel);
    }
}
