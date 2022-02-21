using KUB.Core.Interfaces;
using KUB.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Infrastructure.Data.Repositories
{
    public class BaseWriteRepository : IBaseWriteRepository
    {
        protected ManagementGamesDB _context;
        public BaseWriteRepository(ManagementGamesDB context)
        {
            _context = context;
        }

        public async Task Delete<T>(Guid id)
            where T : class
        {
            DbSet<T> table = _context.Set<T>();
            var item = await table.FindAsync(id);
            table.Remove(item);
        }

        public async Task<T> GetEntityByIdAsync<T>(Guid id)
            where T : class
        {
            DbSet<T> table = _context.Set<T>();
            var item = await table.FindAsync(id);
            return item;
        }

        public async Task InsertAsync<T>(T obj)
            where T : class
        {
            DbSet<T> table = _context.Set<T>();
            await table.AddAsync(obj);
        }

        public void Update<T>(T obj)
            where T : class
        {
            DbSet<T> table = _context.Set<T>();

            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<Tournament> GetTournamentWithParticipants(Guid id)
        {
            return await _context.Tournaments.Include(e => e.ParticipantInTournaments).FirstOrDefaultAsync(e => e.Id == id);  
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

    public class TournamentWriteRepository : IWriteRepository<Tournament>
    {
        public ManagementGamesDB _context;
        public TournamentWriteRepository(ManagementGamesDB context)
        {
            _context = context;
        }

        public async Task<Tournament> GetEntityByIdAsync(Guid id)
        {
            var item = await _context.Tournaments.FindAsync(id);
            return item;
        }

        public async Task Delete(Guid id)
        {
            var item = await _context.Tournaments.FindAsync(id);
            _context.Tournaments.Remove(item);
        }

        public async Task InsertAsync(Tournament obj)
        {
            await _context.Tournaments.AddAsync(obj);
        }

        public void Update(Tournament obj)
        {
            _context.Tournaments.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
