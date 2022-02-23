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

        public async Task AddParticipant(ParticipantInTournament participantInTournament)
        {
            await _commandHandler.Handle(new AddParticipantCommand(participantInTournament));
        }

        public async Task RemoveParticipant(ParticipantInTournament participantInTournament)
        {
            await _commandHandler.Handle(new RemoveParticipantCommand(participantInTournament));
        }

        public async Task PostAsync<TEntity>(TEntity item)
            where TEntity : BaseEntity, new()
        {
            await _commandHandler.Handle(new CreateCommand(item, "Create" + typeof(TEntity).Name));
        }

        public async Task PutAsync<TEntity>(TEntity item)
            where TEntity : BaseEntity, new()
        {
            await _commandHandler.Handle(new UpdateCommand(item, "Update" + typeof(TEntity).Name));
        }

        public async Task DeleteAsync<TEntity>(Guid id)
            where TEntity : BaseEntity, new()
        {
            await _commandHandler.Handle(new DeleteCommand(id, "Delete" + typeof(TEntity).Name));
        }
    }
}
