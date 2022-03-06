using KUB.Core.Models;
using KUB.SharedKernel;
using KUB.SharedKernel.DTOModels.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    public interface IService 
    {
        Task<IEnumerable<BaseEvent>> GetEventsAsync(Guid id);
        
        /* Commands */
        // Create Item
        Task PostAsync<TEntity>(TEntity item) where TEntity : BaseEntity, new();
        // Update Full Item
        Task PutAsync<TEntity>(TEntity item) where TEntity : BaseEntity, new();
        // Delete Item
        Task DeleteAsync<TEntity>(Guid id) where TEntity : BaseEntity, new();
    }
    public interface ITournamentService : IService
    {
        Task UpdateTournament(Tournament tournament, List<ParticipantInTournament> participantInTournaments);
        Task AddParticipant(ParticipantInTournament participantInTournament);
        Task AddParticipants(Tournament tournament, List<ParticipantInTournament> participantInTournaments);
        Task RemoveParticipant(ParticipantInTournament participantInTournament);
    }

    public interface ISchoolService : IService
    {
    }

    public interface IParticipantService : IService
    {
        Task RegisterParticipant(Participant participant, Guid? schoolId);
        Task UpdateParticipant(Participant participant, Guid? schoolId);
    }
}
