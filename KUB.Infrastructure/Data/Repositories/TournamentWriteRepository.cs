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
    public class TournamentWriteRepository : IWriteRepository<Tournament>
    {
        ManagementGamesDB _context;
        public TournamentWriteRepository(ManagementGamesDB context)
        {
            _context = context;
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

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(Tournament obj)
        {
            _context.Tournaments.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            throw new NotImplementedException();
        }
    }
}
