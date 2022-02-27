using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class AddParticipantsCommand : Command<Tournament>, ICommand
    {
        public Tournament Tournament { get; set; }
        public List<ParticipantInTournament> ParticipantsInTournament { get; set; }
        public AddParticipantsCommand(Tournament tournament, List<ParticipantInTournament> participantsInTournament)
        {
            Tournament = tournament;
            ParticipantsInTournament = participantsInTournament;
            Event = new BaseEvent();
            Event.SetEvent(tournament.Id, "AddParticipantsToTournament", participantsInTournament);
        }
    }
}
