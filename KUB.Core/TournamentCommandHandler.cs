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
        public TournamentCommandHandler(IUnitOfWork<Tournament, BaseEvent> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TournamentCreateCommand command)
        {
            await _unitOfWork.WriteRepository().InsertAsync(command.TournamentAggregate);
            await _unitOfWork.EventRepository().AppendEventAsync(command.Event);
            await _unitOfWork.SaveAsync();
        }
    }
}
