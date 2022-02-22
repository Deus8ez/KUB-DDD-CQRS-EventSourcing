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

namespace KUB.Core
{
    public class Service : ITournamentService<TournamentDto, Tournament>
    {
        private IReadRepository<TournamentDto> _readRepository;
        private IEventRepository<BaseEvent> _eventRepository;
        private ITournamentCommandHandler _commandHandler;

        public Service(
                IReadRepository<TournamentDto> readRepository,
                IEventRepository<BaseEvent> eventRepository,
                ITournamentCommandHandler commandHandler
            )
        {
            _commandHandler = commandHandler;
            _readRepository = readRepository;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<TournamentDto>> GetAllAsync()
        {
            var result = await _readRepository.GetAllAsync();

            return result;
        }

        public async Task<TournamentDto> GetAsync(Guid id)
        {
            var result = await _readRepository.GetByIdAsync(id);

            return result;
        }

        public async Task<IEnumerable<BaseEvent>> GetEventsAsync(Guid id)
        {
            var result = await _eventRepository.EventsAsync(id);

            return result;
        }

        public async Task PostAsync(Tournament item)
        {
        }

        public async Task PutAsync(Tournament item)
        {
        }

        public async Task DeleteAsync(Guid id)
        {
            await _commandHandler.Handle(new DeleteCommand(id, "DeleteTournament"));
        }

        public async Task AddParticipant(ParticipantInTournament participantInTournament)
        {
            await _commandHandler.Handle(new AddParticipantCommand(participantInTournament));
        }

        public async Task RemoveParticipant(ParticipantInTournament participantInTournament)
        {
            await _commandHandler.Handle(new RemoveParticipantCommand(participantInTournament));
        }

        public Task<IEnumerable<TEntityDto>> GetAllAsync<TEntityDto>()
        {
            throw new NotImplementedException();
        }

        public Task<TEntityDto> GetAsync<TEntityDto>(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task PostAsync<TEntity>(TEntity item)
            where TEntity : BaseEntity, new()
        {
            await _commandHandler.Handle(new CreateCommand(item, "Create" + typeof(TEntity).Name);
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
