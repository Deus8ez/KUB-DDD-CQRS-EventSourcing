using KUB.Core.Commands;
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
        private IWriteRepository<Tournament> _writeRepository;
        private IEventRepository<BaseEvent> _eventRepository;
        public TournamentCommandHandler(IUnitOfWork<Tournament, BaseEvent> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _writeRepository = unitOfWork.WriteRepository();
            _eventRepository = unitOfWork.EventRepository();

        }

        public async Task Handle(TournamentCreateCommand command)
        {
            await _writeRepository.InsertAsync(command.TournamentAggregate);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle(TournamentUpdateCommand command)
        {
            _writeRepository.Update(command.TournamentAggregate);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle(TournamentDeleteCommand command)
        {
            await _writeRepository.Delete(command.TournamentId);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle(TournamentAddParticipantCommand command)
        {
            var tournament = await _writeRepository.GetEntityByIdAsync(command.ParticipantInTournament.TournamentId);
            var role = await _writeRepository.
            tournament.AddParticipant(command.ParticipantInTournament);
            _writeRepository.Update(tournament);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle(TournamentRemoveParticipantCommand command)
        {
            var tournament = await _writeRepository.GetEntityByIdAsync(command.ParticipantInTournament.TournamentId);
            tournament.RemoveParticipant(command.ParticipantInTournament);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }
    }
}
