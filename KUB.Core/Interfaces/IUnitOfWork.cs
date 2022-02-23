using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseWriteRepository BaseWriteRepository();
        public IEventRepository EventRepository();
        Task SaveAsync();
    }
}
