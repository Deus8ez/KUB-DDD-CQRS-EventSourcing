using KUB.Core.Interfaces;
using KUB.Core.Commands;
using KUB.SharedKernel.CQRS.Interfaces;
using KUB.SharedKernel.DTOModels.Tournament.Requests;
using KUB.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KUB.Core.Models;
using KUB.SharedKernel;
using KUB.SharedKernel.DTOModels.Tournament;
using KUB.Core.Interfaces;
using KUB.SharedKernel.DTOModels.Participant;

namespace KUB.Core
{
    public class Service : ITournamentService, IParticipantService, ISchoolService
    {
        private IEventRepository _eventRepository;
        private IBaseCommandHandler _commandHandler;

        public Service(
                IEventRepository eventRepository,
                IBaseCommandHandler commandHandler
            )
        {
            _commandHandler = commandHandler;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<BaseEvent>> GetEventsAsync(Guid id)
        {
            var result = await _eventRepository.EventsAsync(id);

            return result;
        }

        public async Task RegisterParticipant(Participant participant, List<ParticipantInTournament> participantInTournaments)
        {
            await _commandHandler.Handle(new RegisterParticipantWithTournamentsCommand(participant, participantInTournaments));
        }

        public async Task UpdateTournament(Tournament tournament, List<ParticipantInTournament> participantInTournaments)
        {
            await _commandHandler.Handle(new UpdateTournamentCommand(tournament, participantInTournaments));
        }
        
        public async Task AddParticipant(ParticipantInTournament participantInTournament)
        {
            await _commandHandler.Handle(new AddParticipantCommand(participantInTournament));
        }

        public async Task AddParticipants(Tournament tournament, List<ParticipantInTournament> participantInTournaments)
        {
            await _commandHandler.Handle(new AddParticipantsCommand(tournament, participantInTournaments));
        }

        public async Task RemoveParticipant(ParticipantInTournament participantInTournament)
        {
            await _commandHandler.Handle(new RemoveParticipantCommand(participantInTournament));
        }

        public async Task PostAsync<TEntity>(TEntity item)
            where TEntity : BaseEntity, new()
        {
            await _commandHandler.Handle<TEntity>(new CreateCommand<TEntity>(item, "Create" + typeof(TEntity).Name));
        }

        public async Task PutAsync<TEntity>(TEntity item)
            where TEntity : BaseEntity, new()
        {
            await _commandHandler.Handle(new UpdateCommand<TEntity>(item, "Update" + typeof(TEntity).Name));
        }

        public async Task DeleteAsync<TEntity>(Guid id)
            where TEntity : BaseEntity, new()
        {
            await _commandHandler.Handle(new DeleteCommand<TEntity>(id, "Delete" + typeof(TEntity).Name));
        }
    }
}
