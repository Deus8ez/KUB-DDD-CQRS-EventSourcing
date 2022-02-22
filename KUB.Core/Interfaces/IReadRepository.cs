using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    public interface IReadRepository
    {
        Task<T> GetByIdAsync<T>(Guid id) where T : class;
        Task<List<T>> GetAllAsync<T>() where T : class;
    }
}
