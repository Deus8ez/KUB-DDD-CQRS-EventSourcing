using KUB.Core.Interfaces;
using KUB.Core.Models;
using KUB.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Infrastructure.Data.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ManagementGamesDB _context;
        IBaseWriteRepository _writeRepository;
        IEventRepository _eventRepository;
        IBaseWriteRepository _baseWriteRepository;
        public UnitOfWork(ManagementGamesDB context)
        {
            _context = context;
            _writeRepository = new BaseWriteRepository(_context);
            _eventRepository = new EventRepository(_context);
            _baseWriteRepository = new BaseWriteRepository(_context);
        }

        public IBaseWriteRepository WriteRepository()
        {
            return _writeRepository;
        }

        public IEventRepository EventRepository()
        {
            return _eventRepository;
        }
        public IBaseWriteRepository BaseWriteRepository()
        {
            return _baseWriteRepository;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
