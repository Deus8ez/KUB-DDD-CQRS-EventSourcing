//using KUB.Core.Models;
//using KUB.SharedKernel.DTOModels.Participant.Responses;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using KUB.Infrastructure.Data.QueryExtensions;
//using KUB.SharedKernel.DTOModels.Participant.Requests;

//namespace KUB.Infrastructure.Data
//{
//    public static class ParticipantRepositoryExtension
//    {
//        public static async Task<List<ParticipantGetResponse>> GetParticipantList(this IBaseRepository<Participant> repository)
//        {
//            var result = await repository.GetDbContext().Participants.GetParticipantList().ToListAsync();

//            return result;
//        }
//    }
//}
