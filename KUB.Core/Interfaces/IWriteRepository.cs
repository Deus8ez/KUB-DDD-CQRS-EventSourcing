using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    public interface IBaseWriteRepository
    {
        Task<T> GetEntityByIdAsync<T>(Guid id) where T : class;
        Task<T> GetEntityByAnyAsync<T>(string property, object value) where T : BaseEntity, new();
        Task<T> InsertAsync<T>(T obj) where T : class;
        void Update<T>(T obj) where T : class;
        Task Delete<T>(Guid id) where T : class;
        Task SaveAsync();
        Task<Tournament> GetTournamentWithParticipants(Guid id);
    }
}
