using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    public interface IUnitOfWork<T1, T2> : IDisposable
    where T1 : BaseEntity, new()
    where T2 : BaseEvent, new()
    {
        public IWriteRepository<T1> WriteRepository();
        public IBaseWriteRepository BaseWriteRepository();
        public IEventRepository<T2> EventRepository();
        Task SaveAsync();
    }
}
