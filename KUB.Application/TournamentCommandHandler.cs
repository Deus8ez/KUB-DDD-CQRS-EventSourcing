using KUB.Application.Commands;
using KUB.Application.Interfaces;
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

namespace KUB.Application
{
    public class TournamentCommandHandler : ITournamentCommandHandler
    {
        IWriteRepository<Tournament> _writeRepository;
        IEventRepository<BaseEvent> _eventRepository;

        public TournamentCommandHandler(
                IWriteRepository<Tournament> writeRepository,
                IEventRepository<BaseEvent> eventRepository
            )
        {
            _eventRepository = eventRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(TournamentCreateCommand command)
        {
            await _writeRepository.InsertAsync(command.TournamentAggregate);
            await _eventRepository.AppendEventAsync(command.Event);
        }
    }
}
