using KUB.Core.Models;
using KUB.SharedKernel.DTOModels.Participant.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Infrastructure.Data.QueryExtensions
{
    public static class ParticipantFilterExtension
    {
        public static IQueryable<ParticipantGetResponse> GetParticipantList(this IQueryable<Participant> query)
        {
            return query.Select(e => new ParticipantGetResponse 
            { 
                BlitzGameRank = e.BlitzGameRank,
                CanBeAJury = e.CanBeAJury,
                ClassicGameRank = e.ClassicGameRank,
                DateOfBirth = e.DateOfBirth,    
                Name = e.Name,
                Patronym = e.Patronym,
                Surname = e.Surname,
            });
        }
    }
}
