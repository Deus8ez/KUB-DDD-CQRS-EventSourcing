﻿using KUB.Core.Interfaces;
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
    public class TournamentService : IService<TournamentDto, Tournament>
    {
        private IReadRepository<TournamentDto> _readRepository;
        private IEventRepository<BaseEvent> _eventRepository;
        private ITournamentCommandHandler _commandHandler;

        public TournamentService(
                IReadRepository<TournamentDto> readRepository,
                IEventRepository<BaseEvent> eventRepository,
                ITournamentCommandHandler commandHandler
            )
        {
            _commandHandler = commandHandler;
            _readRepository = readRepository;
            _eventRepository = eventRepository;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
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
            await _commandHandler.Handle(new TournamentCreateCommand(item));
        }

        public Task PostAsync(TournamentDto item)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(TournamentRegistrationPostRequest item)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(Tournament item)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(TournamentDto item)
        {
            throw new NotImplementedException();
        }
    }
}