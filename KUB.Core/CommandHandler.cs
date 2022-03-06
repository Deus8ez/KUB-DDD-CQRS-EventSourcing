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
    public class CommandHandler : IBaseCommandHandler
    {
        IUnitOfWork _unitOfWork;
        private IBaseWriteRepository _writeRepository;
        private IEventRepository _eventRepository;
        public CommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _writeRepository = unitOfWork.BaseWriteRepository();
            _eventRepository = unitOfWork.EventRepository();

        }

        public async Task Handle<T>(CreateCommand<T> command)
            where T : BaseEntity, new()
        {
            await _writeRepository.InsertAsync(command.Aggregate);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle<T>(UpdateCommand<T> command)
            where T : BaseEntity, new()
        {
            _writeRepository.Update(command.Aggregate);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle<T>(DeleteCommand<T> command)
            where T : BaseEntity, new()
        {
            await _writeRepository.Delete<T>(command.AggregateId);
            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle(UpdateTournamentCommand command)
        {
            var entity = await _writeRepository.GetEntityByIdAsync<Tournament>(command.Tournament.Id);

            entity.Date = command.Tournament.Date;
            entity.EndTime = command.Tournament.EndTime;
            entity.Address = command.Tournament.Address;
            entity.City = command.Tournament.City;
            entity.StartTime = command.Tournament.StartTime;
            entity.TournamentFormatId = command.Tournament.TournamentFormatId;
            entity.TournamentGridId = command.Tournament.TournamentGridId;
            entity.TournamentTypeId = command.Tournament.TournamentTypeId;
            entity.TournamentName = command.Tournament.TournamentName;

            foreach (var item in command.ParticipantsInTournament)
            {
                entity.AddParticipant(item);
            }

            _writeRepository.Update(entity);

            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle(AddParticipantsCommand command)
        {
            var entity = await _writeRepository.InsertAsync<Tournament>(command.Tournament);

            foreach(var item in command.ParticipantsInTournament)
            {
                entity.AddParticipant(item);
            }

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

        public async Task Handle(RegisterParticipant command)
        {
            command.Participant.AddToSchool(command.SchoolId);
            await _writeRepository.InsertAsync(command.Participant);
            await _unitOfWork.SaveAsync();
        }

        public async Task Handle(UpdateParticipant command)
        {
            var participant = command.Participant;
            var entity = await _writeRepository.GetEntityByIdAsync<Participant>(participant.Id);

            entity.CanBeAJury = participant.CanBeAJury;
            entity.BlitzGameRank = participant.BlitzGameRank;
            entity.ClassicGameRank = participant.ClassicGameRank;
            entity.DateOfBirth = participant.DateOfBirth;
            entity.Name = participant.Name;
            entity.Patronym = participant.Patronym;
            entity.Surname = participant.Surname;
            entity.ParticipantInSchool.SchoolId = command.SchoolId;

            _writeRepository.Update(entity);

            await _eventRepository.AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }
    }
}
