using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    public interface IWriteRepository<T> 
        where T : class
    {
        Task<T> GetEntityByIdAsync(Guid id);
        Task InsertAsync(T obj);
        void Update(T obj);
        Task Delete(Guid id);
    }

    public interface IBaseWriteRepository
    {
        Task<T> GetEntityByIdAsync<T>(Guid id) where T : class;
        Task InsertAsync<T>(T obj) where T : class;
        void Update<T>(T obj) where T : class;
        Task Delete<T>(Guid id) where T : class;
        Task SaveAsync();
        Task<Tournament> GetTournamentWithParticipants(Guid id);
    }
}
