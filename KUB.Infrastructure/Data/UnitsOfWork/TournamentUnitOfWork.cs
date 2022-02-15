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
    public class TournamentUnitOfWork : IUnitOfWork<Tournament, BaseEvent>
    {
        protected ManagementGamesDB _context;
        IWriteRepository<Tournament> _writeRepository;
        IEventRepository<BaseEvent> _eventRepository;
        public TournamentUnitOfWork(ManagementGamesDB context)
        {
            _context = context;
            _writeRepository = new TournamentWriteRepository(_context);
            _eventRepository = new EventRepository(_context);
        }

        public IWriteRepository<Tournament> WriteRepository()
        {
            return _writeRepository;
        }

        public IEventRepository<BaseEvent> EventRepository()
        {
            return _eventRepository;
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
