using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class TournamentUpdateCommand : Command, ICommand
    {
        public Tournament TournamentAggregate { get; set; }

        public TournamentUpdateCommand(Tournament data)
        {
            TournamentAggregate = data;
            Event = new BaseEvent();
            Event.SetEvent(TournamentAggregate.Id, "UpdateTournament", TournamentAggregate);
        }
    }
}
