using KUB.Core.Models;
using KUB.SharedKernel.DTOModels.Tournament.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Infrastructure.Data.QueryExtensions
{
    public static class TournamentFilterExtension
    {
        public static IQueryable<TournamentGetResponse> GetTournamentList(this IQueryable<Tournament> query)
        {
            return query.Select(e => new TournamentGetResponse
            {
                Date = e.Date,
                EndTime = e.EndTime,
                StartTime = e.StartTime,
                TournamentFormat = e.TournamentFormat.Format,
                TournamentName = e.TournamentName,
                TournamentGrid = e.TournamentGrid.Type,
                TournamentType = e.TournamentType.Type,
                Id = e.Id,
            });
        }
    }
}
