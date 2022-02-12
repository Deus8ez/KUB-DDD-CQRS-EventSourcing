//using KUB.Core.Models;
//using KUB.Infrastructure.Data.QueryExtensions;
//using KUB.SharedKernel.DTOModels;
//using KUB.SharedKernel.DTOModels.Tournament.Requests;
//using KUB.SharedKernel.DTOModels.Tournament.Responses;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KUB.Infrastructure.Data
//{
//    public static class TournamentRepositoryExtension
//    {
//        public static async Task<List<TournamentGetResponse>> GetTournaments(this IBaseRepository<Tournament> repository)
//        {
//            var result = await repository.GetDbContext().Tournaments.GetTournamentList().ToListAsync();

//            return result;
//        }

//        public static async Task<OperationStatus> AddParticipant(this IBaseRepository<Tournament> repository, ParticipantRegistrationPostRequest data)
//        {
//            var dbContext = repository.GetDbContext();

//            var participant = await dbContext.Participants.FirstOrDefaultAsync(e => e.ParticipantId == data.ParticipantId);

//            var role = await dbContext.Roles.FirstOrDefaultAsync(e => e.RoleId == data.RoleId);

//            var tournament = await dbContext.Tournaments.FirstOrDefaultAsync(e => e.Id == data.Id);

//            var participantInTournament = new ParticipantInTournament{};

//            var participantCanBeRegistered = participantInTournament.SetParticipantInTournament(participant, role, tournament);

//            if (participantCanBeRegistered)
//            {
//                tournament.AddParticipant(participantInTournament);
//                await dbContext.SaveChangesAsync();
//                return new OperationStatus { Success = true, Message = "Participant registered" };

//            }

//            return new OperationStatus { Success = true, Message = "Participant can not be registered because of business logic conflict" };
//        }

//        public static async Task RemoveParticipant(this IBaseRepository<Tournament> repository, ParticipantRegistrationPostRequest data)
//        {
//            var dbContext = repository.GetDbContext();

//            var participantInTournament = await dbContext.ParticipantInTournaments.FirstOrDefaultAsync(e => e.ParticipantInId == data.ParticipantId);

//            var tournament = await repository.GetByIdAsync(data.Id);

//            tournament.RemoveParticipant(participantInTournament);

//            await dbContext.SaveChangesAsync();
//        }
//    }
//}
