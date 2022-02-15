using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    public interface IWriteRepository<T> where T : class
    {
        Task InsertAsync(T obj);
        void Update(T obj);
        Task Delete(Guid id);
    }
}
