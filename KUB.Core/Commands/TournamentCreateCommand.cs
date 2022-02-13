using KUB.Core;
using KUB.Core.Models;
using KUB.SharedKernel;
using KUB.SharedKernel.CQRS.Interfaces;
using KUB.SharedKernel.DTOModels.Tournament.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class TournamentCreateCommand : Command, ICommand
    {
        public Tournament TournamentAggregate { get; set; }

        public TournamentCreateCommand(Tournament data)
        {
            TournamentAggregate = data;
            TournamentAggregate.Id = Guid.NewGuid();
            Event = new BaseEvent();
            Event.SetEvent(TournamentAggregate.Id, "CreateTournament", TournamentAggregate);
        }
    }
}
