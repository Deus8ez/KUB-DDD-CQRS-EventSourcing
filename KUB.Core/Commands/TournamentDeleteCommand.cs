using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class TournamentDeleteCommand : Command, ICommand
    {
        public Guid TournamentId { get; set; }

        public TournamentDeleteCommand(Guid TournamentId)
        {
            Event = new BaseEvent();
            Event.SetEvent(TournamentId, "DeleteTournament", TournamentId);
        }
    }
}
