﻿using KUB.Core.Commands;
using KUB.Core.Interfaces;
using KUB.Core;
using KUB.Core.Models;
using KUB.SharedKernel;
using KUB.SharedKernel.CQRS.Interfaces;
using KUB.SharedKernel.DTOModels.Tournament;
using KUB.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core
{
    public class TournamentCommandHandler : ITournamentCommandHandler
    {
        IUnitOfWork<Tournament, BaseEvent> _unitOfWork;
        private IBaseWriteRepository _writeRepository;
        private IEventRepository<BaseEvent> _eventRepository;
        public TournamentCommandHandler(IUnitOfWork<Tournament, BaseEvent> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _writeRepository = unitOfWork.BaseWriteRepository();
            _eventRepository = unitOfWork.EventRepository();

        }

        public async Task Handle(CreateCommand command)
        {
            await _writeRepository.InsertAsync(command.Aggregate);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle(UpdateCommand command)
        {
            _writeRepository.Update(command.Aggregate);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle(DeleteCommand command)
        {
            await _writeRepository.Delete<Tournament>(command.AggregateId);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle(AddParticipantCommand command)
        {
            var participantInTournament = command.ParticipantInTournament;
            var tournament = await _writeRepository.GetEntityByIdAsync<Tournament>(command.ParticipantInTournament.TournamentId);
            tournament.AddParticipant(command.ParticipantInTournament);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle(RemoveParticipantCommand command)
        {
            var participantInTournament = command.ParticipantInTournament;
            var tournament = await _writeRepository.GetTournamentWithParticipants(participantInTournament.TournamentId);
            tournament.RemoveParticipant(command.ParticipantInTournament);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }
    }
}
